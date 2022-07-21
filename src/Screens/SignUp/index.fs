module App.Screens

open Feliz.Router

type private Msg =
    | Email of string
    | Nome of string
    | Senha of string
    | ConfirmarSenha of string

type private State =
    { Email: string
      Nome: string
      Senha: string
      ConfirmarSenha: string }

let private update (state: State) =
    function
    | Email input -> { state with Email = input }
    | Nome input -> { state with Nome = input }
    | Senha input -> { state with Senha = input }
    | ConfirmarSenha input -> { state with ConfirmarSenha = input }

open Feliz
open Fss
open Components

open type Html
open type prop

let styles = Screens.SignUp.styles

let private location =
    Browser.Dom.window.location

[<ReactComponent>]
let SignUp () =
    let state, dispatch =
        React.useReducer (
            update,
            { Nome = ""
              Email = ""
              Senha = ""
              ConfirmarSenha = "" }
        )

    UserFormScaffold(
        div [
            fss styles.container
            children [
                BlueLogo()
                p [
                    fss GlobalStyles.Description
                    children [
                        Html.text "Ainda não tem cadastro?"
                        Html.br []
                        Html.br []
                        Html.text "Então, antes de buscar seu melhor amigo, precisamos de alguns dados:"
                    ]
                ]
                div [
                    fss styles.formBox
                    children [
                        StringFormInput "Email" "Email" "Escolha seu melhor email" state.Email (fun value ->
                            dispatch (Email value))
                        StringFormInput "Nome" "Nome" "Digite seu nome completo" state.Nome (fun value ->
                            dispatch (Nome value))
                        PasswordFormInput "Senha" "Senha" "Crie uma senha" state.Senha (fun value ->
                            dispatch (Senha value))
                        PasswordFormInput
                            "Confirmar Senha"
                            "ConfirmarSenha"
                            "Repita a senha criada acima"
                            state.ConfirmarSenha
                            (fun value -> dispatch (ConfirmarSenha value))
                    ]
                ]
                div [
                    fss styles.buttonWrapper
                    children [
                        a [
                            fss styles.button
                            href (Router.format "home")
                            type' "submit"
                            text "Cadastrar"
                        ]
                    ]
                ]
            ]
        ]
    )
