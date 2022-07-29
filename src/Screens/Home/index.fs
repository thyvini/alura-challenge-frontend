module App.Screens

open Fable
open Feliz.Router
open Feliz
open Feliz.UseDeferred
open Feliz.UseMediaQuery
open Fss
open App.Components
open App.Domain
open App.Api

open type Html

let private styles = Screens.Home.styles

let imageSrc animalName = $"img/animals/{animalName}.png"

let imageSrcSet animalName =
    let i = imageSrc animalName
    let imageFormat = i.Split('.')

    let i2 =
        $"{imageFormat[0]}@2x.{imageFormat[1]}"

    let i3 =
        $"{imageFormat[0]}@3x.{imageFormat[1]}"

    $"{i} 1x,\n{i2} 2x,\n{i3} 3x"

[<ReactComponent>]
let Home () =
    let animalsDefer, setAnimalsDefer =
        React.useState Deferred.HasNotStartedYet

    let loadData =
        React.useDeferredCallback ((fun () -> Api.loadAnimals ()), setAnimalsDefer)

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
                                            prop.src (imageSrc animal.name)
                                            prop.srcset (imageSrcSet animal.name)
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
