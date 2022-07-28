module App.Screens

open Browser.Types
open Fable.Core.JS
open Feliz
open Fss
open App.Components
open Screens.Contact.State
open Errors

open type Html
open type prop

let private styles = Screens.Contact.styles

[<ReactComponent>]
let Contact (id: int) =
    let state, dispatch =
        React.useReducer (updateState, initialState)

    let errors, setErrors = React.useState []

    let handleSubmit (event: Event) =
        event.preventDefault ()

        let pipelineWithErroUpdate =
            pipeline setErrors

        Ok state |> pipelineWithErroUpdate |> ignore

    let errorToP (errorMessage: string) =
        p [
            fss GlobalStyles.ErrorMessage
            text errorMessage
        ]

    let tryFindAndDisplay e =
        printIfError (findError errors e)
        |> Option.map errorToP
        |> Option.defaultValue Html.none

    let nameError =
        tryFindAndDisplay (nameof MissingName)

    let phoneError =
        tryFindAndDisplay (nameof MissingPhone)

    let animalError =
        tryFindAndDisplay (nameof MissingAnimal)

    let messageError =
        tryFindAndDisplay (nameof MissingMessage)

    CommonScaffold(
        div [
            fss styles.container
            children [
                p [
                    fss styles.description
                    text "Envie uma mensagem para a pessoa ou instituição que está cuidando do animal:"
                ]
                Html.form [
                    onSubmit handleSubmit
                    fss styles.content
                    children [
                        label [ text "Nome" ]
                        input [
                            fss styles.input
                            placeholder "Insira seu nome completo"
                            value state.Name
                            onChange (dispatch << Name)
                        ]
                        nameError
                        label [ text "Telefone" ]
                        InputMask.inputMask [
                            fss styles.input
                            inputMask.mask "(99)99999-9999"
                            placeholder "Insira seu telefone e/ou whatsapp"
                            value state.Phone
                            onChange (dispatch << Phone)
                        ]
                        phoneError
                        label [ text "Nome do Animal" ]
                        input [
                            fss styles.input
                            placeholder "Por qual animal você se interessou?"
                            value state.Animal
                            onChange (dispatch << Animal)
                        ]
                        animalError
                        label [ text "Mensagem" ]
                        textarea [
                            fss styles.input
                            placeholder "Escreva sua mensagem"
                            rows 9
                            value state.Message
                            onChange (dispatch << Message)
                        ]
                        messageError
                        button [ text "Enviar"; type' "submit" ]
                    ]
                ]
            ]
        ]
    )
