module App.Components

open Feliz
open Fss
open App.Validations

open type Html
open type prop

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
                type' (
                    if showPassword then
                        "text"
                    else
                        "password"
                )
                value inputValue
                prop.onChange onChange
            ]
            button [
                fss styles.icon
                type' "button"
                tabIndex -1
                children [
                    i [
                        className (
                            if showPassword then
                                "fa-lg fa-regular fa-eye-slash"
                            else
                                "fa-lg fa-regular fa-eye"
                        )
                    ]
                ]
                onClick (fun _ -> setShowPassword (not showPassword))
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
