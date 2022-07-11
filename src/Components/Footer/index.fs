module App.Components

open Feliz
open Fss
open type Html
open type prop

let private styles = App.Components.Footer.styles

[<ReactComponent>]
let Footer () =
    footer [
        fss styles.footer
        children [
            p [
                fss styles.text
                text "2022 - Desenvolvido por Alura."
            ]
        ]
    ]
