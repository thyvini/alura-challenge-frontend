module App.Screens

open Fable
open Fable.Core
open Feliz.Router
open Fetch
open Feliz
open Feliz.UseDeferred
open Feliz.UseMediaQuery
open Fss
open App.Components
open App.JsModules.NodeProcess

open type Html

let private styles = Screens.Home.styles

type Animal =
    { id: int
      name: string
      age: string
      size: string
      temper: string
      location: string }

let image animalName = $"img/animals/{animalName}.png"

let sourceSet animalName =
    let i = image animalName
    let imageFormat = i.Split('.')

    let i2 =
        $"{imageFormat[0]}@2x.{imageFormat[1]}"

    let i3 =
        $"{imageFormat[0]}@3x.{imageFormat[1]}"

    $"{i} 1x,\n{i2} 2x,\n{i3} 3x"


[<ReactComponent>]
let Home () =
    let url = Process.env "SERVER_URL"

    let loadAnimals =
        promise {
            do! Promise.sleep 2000
            let! response = fetch $"{url}/animals" []

            let! data = response.json<Animal seq> ()

            return Ok data
        }
        |> Promise.catch Error
        |> Async.AwaitPromise

    let animalsDefer, setAnimalsDefer =
        React.useState Deferred.HasNotStartedYet

    let loadData =
        React.useDeferredCallback ((fun () -> loadAnimals), setAnimalsDefer)

    React.useEffectOnce loadData

    let isMobile =
        React.useMediaQuery MediaQueries.MobileMediaQueryString

    CommonScaffold(
        div [
            prop.fss styles.container
            prop.children [
                p [
                    prop.fss styles.description
                    prop.children [
                        Html.text "Olá!"
                        if not isMobile then Html.br []
                        Html.text " Veja os amigos disponíveis para adoção!"
                    ]
                ]
                match animalsDefer with
                | Deferred.HasNotStartedYet
                | Deferred.InProgress -> Loader()
                | Deferred.Failed _
                | Deferred.Resolved (Error _) -> div []
                | Deferred.Resolved (Ok animals) ->
                    div [
                        prop.fss styles.listContainer
                        prop.children (
                            animals
                            |> Seq.map (fun animal ->
                                div [
                                    prop.key animal.id
                                    prop.fss styles.listItem
                                    prop.children [
                                        img [
                                            prop.fss styles.itemImage
                                            prop.src (image animal.name)
                                            prop.srcset (sourceSet animal.name)
                                        ]
                                        div [
                                            prop.fss styles.itemContent
                                            prop.children [
                                                h2 animal.name
                                                p animal.age
                                                p animal.size
                                                p animal.temper
                                                div [
                                                    p animal.location
                                                    a [
                                                        prop.href (Router.format ("animal", animal.id, "contato"))
                                                        prop.children [
                                                            img [
                                                                prop.src "img/ícone mensagem.svg"
                                                            ]
                                                            text "Falar com responsável"
                                                        ]
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                ])
                        )
                    ]
            ]
        ]
    )
