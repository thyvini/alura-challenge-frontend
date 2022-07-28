module App.Components

open Feliz
open Fss

open type Html
open type prop

let private styles =
    Components.StringFormInput.styles

[<ReactComponent>]
let StringFormInput
    (
        isBigOnDesktop: bool,
        labelText: string,
        inputName: string,
        inputPlaceholder: string,
        inputValue: string,
        onChange: string -> unit,
        error: string option
    ) =
    div [
        fss styles.container
        children [
            label [
                fss GlobalStyles.Label
                htmlFor inputName
                text labelText
            ]
            input [
                fss (
                    if isBigOnDesktop then
                        GlobalStyles.Input @ GlobalStyles.DesktopBigInput
                    else
                        GlobalStyles.Input
                )
                name inputName
                placeholder inputPlaceholder
                type' "text"
                value inputValue
                prop.onChange onChange
            ]
            match error with
            | Some e ->
                p [
                    fss GlobalStyles.ErrorMessage
                    text e
                ]
            | None -> none
        ]
    ]
