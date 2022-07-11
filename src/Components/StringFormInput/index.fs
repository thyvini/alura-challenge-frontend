module App.Components

open Feliz
open Fss
open type Html
open type prop

let styles = Components.StringFormInput.styles

[<ReactComponent>]
let StringFormInput
    (labelText: string)
    inputName
    inputPlaceholder
    (inputValue: string)
    (onChange: string -> unit)
    =
    div [
        fss styles.container
        children [
            label [
                fss GlobalStyles.Label
                htmlFor inputName
                text labelText
            ]
            input [
                fss GlobalStyles.Input
                name inputName
                placeholder inputPlaceholder
                type' "text"
                value inputValue
                prop.onChange onChange
            ]
        ]
    ]
