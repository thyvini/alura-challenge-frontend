module App.Components

open Feliz
open type Html
open type prop

let styles = App.Components.Footer.styles

[<ReactComponent>]
let Footer () =
    footer [
        style styles.footer
        children [
            p [
                style styles.text
                text "2022 - Desenvolvido por Alura."
            ]
        ]
    ]
