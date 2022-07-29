module App.Components

open Feliz
open Fss
open App.GlobalStyles

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
    Html.div [
        prop.fss styles.container
        prop.children [
            Html.label [
                prop.fss GlobalStyles.Label
                prop.htmlFor inputName
                prop.text labelText
            ]
            Html.input [
                prop.fss (
                    if isBigOnDesktop then
                        GlobalStyles.Input @ GlobalStyles.DesktopBigInput
                    else
                        GlobalStyles.Input
                )
                prop.name inputName
                prop.placeholder inputPlaceholder
                prop.type' "text"
                prop.value inputValue
                prop.onChange onChange
            ]
            match error with
            | Some e ->
                Html.p [
                    prop.fss GlobalStyles.ErrorMessage
                    prop.text e
                ]
            | None -> Html.none
        ]
    ]
