module App.Screens

open Fable
open Fable.Core
open Fetch
open Feliz
open Feliz.UseDeferred
open Fss
open App.Components

open type Html

let private styles = Screens.Home.styles

type IAnimal =
    abstract id: int
    abstract name: string
    abstract age: string
    abstract size: string
    abstract temper: string
    abstract location: string

[<ReactComponent>]
let Home () =
    let loadAnimals =
        promise {
            let! response = fetch "http://localhost:3000/animals" []

            return! response.json<IAnimal seq> ()
        }
        |> Async.AwaitPromise

    let animalsDefer, setAnimalsDefer =
        React.useState Deferred.HasNotStartedYet

    let loadData =
        React.useDeferredCallback ((fun () -> loadAnimals), setAnimalsDefer)

    React.useEffectOnce loadData

    CommonScaffold(
        div [
            prop.fss styles.container
            prop.children [
                p [
                    prop.fss styles.description
                    prop.text "Olá! Veja os amigos disponíveis para adoção!"
                ]
                match animalsDefer with
                | Deferred.HasNotStartedYet
                | Deferred.InProgress -> div []
                | Deferred.Failed error -> div []
                | Deferred.Resolved animals ->
                    let image animalName = $"img/animals/{animalName}.png"

                    let sourceSet animalName =
                        let i = image animalName
                        let imageFormat = i.Split('.')

                        let i2 =
                            $"{imageFormat[0]}@2x.{imageFormat[1]}"

                        let i3 =
                            $"{imageFormat[0]}@3x.{imageFormat[1]}"

                        $"{i} 1x,\n{i2} 2x,\n{i3} 3x"

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
                                                        img [
                                                            prop.src "img/ícone mensagem.svg"
                                                        ]
                                                        text "Falar com responsável"
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
