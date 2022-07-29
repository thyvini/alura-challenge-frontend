module App.Screens

open Browser.Types
open Feliz
open Fss
open App.Components
open App.Screens.SignIn.State
open App.Dtos.LoginUserFormDto
open App.LocalRepositoryContext
open App.GlobalStyles

let private styles = Screens.SignIn.styles

let private location =
    Browser.Dom.window.location

[<ReactComponent>]
let SignIn () =
    let repository =
        React.useContext localRepositoryContext

    let state, dispatch =
        React.useReducer (updateState, LoginUserFormDto.create "" "")

    let errors, setErrors = React.useState []

    let handleSubmit (event: Event) =
        event.preventDefault ()

        let pipeline =
            makePipeline repository setErrors

        Ok state |> pipeline |> ignore

    let emailInputProps =
        (true, "Email", "Email", "Insira seu email", state.Email, (dispatch << Email), None)

    let passwordInputProps =
        ("Senha", "Senha", "Crie uma senha", state.Password, (dispatch << Password), None)

    UserFormScaffold(
        Html.div [
            prop.fss styles.container
            prop.children [
                BlueLogo()
                Html.p [
                    prop.fss GlobalStyles.Description
                    prop.text "Já tem conta? Faça seu login:"
                ]
                if errors.Length > 0 then
                    Html.p [
                        prop.fss GlobalStyles.ErrorMessage
                        prop.text "E-mail e/ou senha incorretos"
                    ]
                Html.form [
                    prop.onSubmit handleSubmit
                    prop.children [
                        Html.div [
                            prop.fss styles.formBox
                            prop.children [
                                StringFormInput emailInputProps
                                PasswordFormInput passwordInputProps
                            ]
                        ]
                        Html.a [
                            prop.fss styles.resetPassword
                            prop.text "Esqueci minha senha"
                        ]
                        Html.div [
                            prop.fss styles.buttonWrapper
                            prop.children [
                                Html.button [
                                    prop.fss styles.button
                                    prop.type' "submit"
                                    prop.text "Entrar"
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    )
