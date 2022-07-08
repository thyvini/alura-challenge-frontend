module App.Screens

open Feliz
open App.Components
open Fss.Feliz

open type Html
open type prop

let styles = App.Screens.Home.styles

[<ReactComponent>]
let Home () =
    div [
        fss styles.container
        children [
            Header false
            img [
                fss styles.vetor1
                src "img/Forma 2.svg"
            ]
            img [
                src "img/Logo.png"
                fss styles.logo
            ]
            h1 [
                fss styles.title
                text "Boas-vindas!"
            ]
            main [
                p [
                    fss styles.content
                    text "Que tal mudar sua vida adotando seu novo melhor amigo? Vem com a gente!"
                ]
                a [
                    style []
                ]
            ]
            Footer()
        ]
    ]
