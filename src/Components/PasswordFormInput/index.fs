module App.Components

open Feliz
open Fss
open App.GlobalStyles

let private styles =
    Components.PasswordFormInput.styles

[<ReactComponent>]
let PasswordFormInput
    (
        labelText: string,
        inputName: string,
        inputPlaceholder: string,
        inputValue: string,
        onChange: string -> unit,
        error: string option
    ) =
    let showPassword, setShowPassword =
        React.useState false

    Html.div [
        prop.fss styles.container
        prop.children [
            Html.label [
                prop.fss GlobalStyles.Label
                prop.htmlFor inputName
                prop.text labelText
            ]
            Html.input [
                prop.fss GlobalStyles.Input
                prop.name inputName
                prop.placeholder inputPlaceholder
                prop.type' (
                    if showPassword then
                        "text"
                    else
                        "password"
                )
                prop.value inputValue
                prop.onChange onChange
            ]
            Html.button [
                prop.fss styles.icon
                prop.type' "button"
                prop.tabIndex -1
                prop.children [
                    Html.i [
                        prop.className (
                            if showPassword then
                                "fa-lg fa-regular fa-eye-slash"
                            else
                                "fa-lg fa-regular fa-eye"
                        )
                    ]
                ]
                prop.onClick (fun _ -> setShowPassword (not showPassword))
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
