module App.Screens

open Browser.Types
open Feliz
open Feliz.UseMediaQuery
open Fss
open Components
open Screens.SignUp.State
open Errors
open LocalRepositoryContext

open type Html
open type prop

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
        div [
            fss styles.container
            children [
                BlueLogo()
                p [
                    fss GlobalStyles.Description
                    children [
                        Html.text "Ainda não tem cadastro?"
                        Html.br []
                        if isMobile then Html.br []
                        Html.text "Então, antes de buscar seu melhor amigo, precisamos de alguns dados:"
                    ]
                ]
                Html.form [
                    fss styles.formBox
                    method "POST"
                    onSubmit handleSubmit
                    children [
                        yield! stringInputs
                        yield! passwordInputs
                        div [
                            fss styles.buttonWrapper
                            children [
                                button [
                                    fss styles.button
                                    type' "submit"
                                    text "Cadastrar"
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    )
