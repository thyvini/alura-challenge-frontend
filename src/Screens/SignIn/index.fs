module App.Screens

type private Msg =
    | Email of string
    | Senha of string

type private State = { Email: string; Senha: string }

let private update (state: State) =
    function
    | Email input -> { state with Email = input }
    | Senha input -> { state with Senha = input }

open Feliz
open Fss
open Components

open type Html
open type prop

let private styles = Screens.SignIn.styles

[<ReactComponent>]
let SignIn () =
    let state, dispatch =
        React.useReducer (update, { Email = ""; Senha = "" })

    UserFormScaffold(
        div [
            fss styles.container
            children [
                BlueLogo()
                p [
                    fss GlobalStyles.Description
                    text "Já tem conta? Faça seu login:"
                ]
                div [
                    fss styles.formBox
                    children [
                        StringFormInput "Email" "Email" "Insira seu email" state.Email (fun value ->
                            dispatch (Email value))
                        PasswordFormInput "Senha" "Senha" "Insira sua senha" state.Senha (fun value ->
                            dispatch (Senha value))
                    ]
                ]
                a [
                    fss styles.resetPassword
                    text "Esqueci minha senha"
                ]
                button [
                    fss styles.button
                    type' "submit"
                    text "Entrar"
                ]
            ]
        ]
    )
