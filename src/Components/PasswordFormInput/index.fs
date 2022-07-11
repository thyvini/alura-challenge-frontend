module App.Components

open Feliz
open Fss

open type Html
open type prop

let styles =
    Components.PasswordFormInput.styles

[<ReactComponent>]
let PasswordFormInput (labelText: string) inputName inputPlaceholder (inputValue: string) (onChange: string -> unit) =
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
        ]
    ]
