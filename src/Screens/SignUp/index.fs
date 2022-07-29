module App.Screens

open Browser.Types
open Feliz
open Feliz.UseMediaQuery
open Fss
open App.Components
open App.Screens.SignUp.State
open App.Errors
open App.LocalRepositoryContext
open App.MediaQueries
open App.GlobalStyles

let private styles = Screens.SignUp.styles

[<ReactComponent>]
let SignUp () =
    let repository =
        React.useContext localRepositoryContext

    let state, dispatch =
        React.useReducer (updateState, initialState)

    let errors, setErrors = React.useState []

    let isMobile =
        React.useMediaQuery MediaQueries.MobileMediaQueryString

    let handleSubmit (event: Event) =
        event.preventDefault ()

        let pipeline =
            makePipeline repository setErrors

        Ok state |> pipeline |> ignore

    let emailInputProps =
        (true,
         "Email",
         "Email",
         "Escolha seu melhor email",
         state.Email,
         (dispatch << Email),
         printIfError (
             findErrors
                 errors
                 [ nameof InvalidEmail
                   nameof EmailAlreadyExists ]
         ))

    let nameInputProps =
        (true,
         "Nome",
         "Nome",
         "Digite seu nome completo",
         state.Name,
         (dispatch << Name),
         printIfError (findError errors (nameof InvalidName)))

    let stringInputs =
        [ emailInputProps; nameInputProps ]
        |> List.map StringFormInput

    let passwordInputProps =
        ("Senha",
         "Senha",
         "Crie uma senha",
         state.Password,
         (dispatch << Password),
         printIfError (findError errors (nameof InvalidPassword)))

    let passwordConfirmationInputProps =
        ("Confirmar Senha",
         "ConfirmarSenha",
         "Repita a senha criada acima",
         state.PasswordConfirmation,
         (dispatch << PasswordConfirmation),
         printIfError (findError errors (nameof InvalidPasswordConfirmation)))

    let passwordInputs =
        [ passwordInputProps
          passwordConfirmationInputProps ]
        |> List.map PasswordFormInput

    UserFormScaffold(
        Html.div [
            prop.fss styles.container
            prop.children [
                BlueLogo()
                Html.p [
                    prop.fss GlobalStyles.Description
                    prop.children [
                        Html.text "Ainda não tem cadastro?"
                        Html.br []
                        if isMobile then Html.br []
                        Html.text "Então, antes de buscar seu melhor amigo, precisamos de alguns dados:"
                    ]
                ]
                Html.form [
                    prop.fss styles.formBox
                    prop.method "POST"
                    prop.onSubmit handleSubmit
                    prop.children [
                        yield! stringInputs
                        yield! passwordInputs
                        Html.div [
                            prop.fss styles.buttonWrapper
                            prop.children [
                                Html.button [
                                    prop.fss styles.button
                                    prop.type' "submit"
                                    prop.text "Cadastrar"
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    )
