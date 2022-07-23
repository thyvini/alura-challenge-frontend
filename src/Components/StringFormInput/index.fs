module App.Components

open Feliz
open Fss

open type Html
open type prop

let private styles =
    Components.StringFormInput.styles

[<ReactComponent>]
let StringFormInput
    (isBigOnDesktop: bool)
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
        ]
    ]
