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
open App.MediaQueries

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
        Html.div [
            prop.fss styles.container
            prop.children [
                Html.p [
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
                | Deferred.Failed e -> Html.div e.Message
                | Deferred.Resolved (Error e) -> Html.div e.Message
                | Deferred.Resolved (Ok animals) ->
                    Html.div [
                        prop.fss styles.listContainer
                        prop.children (
                            animals
                            |> Seq.map (fun animal ->
                                Html.div [
                                    prop.key animal.Id
                                    prop.fss styles.listItem
                                    prop.children [
                                        Html.img [
                                            prop.fss styles.itemImage
                                            prop.src (imageSrc animal.Name)
                                            prop.srcset (imageSrcSet animal.Name)
                                        ]
                                        Html.div [
                                            prop.fss styles.itemContent
                                            prop.children [
                                                Html.h2 animal.Name
                                                Html.p animal.Age
                                                Html.p animal.Size
                                                Html.p animal.Temper
                                                Html.div [
                                                    Html.p animal.Location
                                                    Html.a [
                                                        prop.href (Router.format ("animal", animal.Id, "contato"))
                                                        prop.children [
                                                            Html.img [
                                                                prop.src "img/ícone mensagem.svg"
                                                            ]
                                                            Html.text "Falar com responsável"
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
