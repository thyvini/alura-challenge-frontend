module App.Screens

open Feliz
open Fss
open Components
open Screens.SignIn.State
open App
open Dtos.LoginUserFormDto
open Errors
open Browser.Types

open type Html
open type prop

let private styles = Screens.SignIn.styles

let private location =
    Browser.Dom.window.location

[<ReactComponent>]
let SignIn () =
    let state, dispatch =
        React.useReducer (updateState, LoginUserFormDto.create "" "")

    let errors, setErrors = React.useState []

    let handleSubmit (event: Event) =
        event.preventDefault ()

        let pipelineWithErrorUpdate =
            pipeline setErrors

        Ok state |> pipelineWithErrorUpdate |> ignore

    let emailInputProps =
        (true, "Email", "Email", "Insira seu email", state.Email, (dispatch << Email), None)

    let passwordInputProps =
        ("Senha", "Senha", "Crie uma senha", state.Password, (dispatch << Password), None)

    UserFormScaffold(
        div [
            fss styles.container
            children [
                BlueLogo()
                p [
                    fss GlobalStyles.Description
                    text "Já tem conta? Faça seu login:"
                ]
                if errors.Length > 0 then
                    p [
                        fss GlobalStyles.ErrorMessage
                        text "E-mail e/ou senha incorretos"
                    ]
                Html.form [
                    onSubmit handleSubmit
                    children [
                        div [
                            fss styles.formBox
                            children [
                                StringFormInput emailInputProps
                                PasswordFormInput passwordInputProps
                            ]
                        ]
                        a [
                            fss styles.resetPassword
                            text "Esqueci minha senha"
                        ]
                        div [
                            fss styles.buttonWrapper
                            children [
                                button [
                                    fss styles.button
                                    type' "submit"
                                    text "Entrar"
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    )
