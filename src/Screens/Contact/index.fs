module App.Screens

open Browser.Types
open Feliz
open Fss
open App.Components
open Screens.Contact.State
open Errors
open LocalRepositoryContext
open Dtos.ContactFormDto
open App.Domain
open App.Api

open type Html

let private styles = Screens.Contact.styles

[<ReactComponent>]
let Contact (id: int) =
    let repository =
        React.useContext localRepositoryContext

    let user, userDetails =
        repository.GetCurrentUserWithDetails()

    let initialState =
        ContactFormDto.create user.Name (userDetails.Phone |> Option.defaultValue "") "" ""

    let state, dispatch =
        React.useReducer (updateState, initialState)

    let errors, setErrors = React.useState []

    React.useEffectOnce (fun () ->
        async {
            if id = 0 then
                ()
            else
                let! animal = Api.findAnimalById id

                match animal with
                | Ok animal -> Animal animal.name |> dispatch
                | Error _ -> ()
        }
        |> Async.Start)

    let handleSubmit (event: Event) =
        event.preventDefault ()

        let pipeline = makePipeline setErrors

        Ok state |> pipeline |> ignore

    let errorToP (errorMessage: string) =
        p [
            prop.fss GlobalStyles.ErrorMessage
            prop.text errorMessage
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
            prop.fss styles.container
            prop.children [
                p [
                    prop.fss styles.description
                    prop.text "Envie uma mensagem para a pessoa ou instituição que está cuidando do animal:"
                ]
                Html.form [
                    prop.onSubmit handleSubmit
                    prop.fss styles.content
                    prop.children [
                        label [ prop.text "Nome" ]
                        input [
                            prop.fss styles.input
                            prop.placeholder "Insira seu nome completo"
                            prop.value state.Name
                            prop.onChange (dispatch << Name)
                        ]
                        nameError
                        label [ prop.text "Telefone" ]
                        InputMask.inputMask [
                            prop.fss styles.input
                            inputMask.mask "(99)99999-9999"
                            prop.placeholder "Insira seu telefone e/ou whatsapp"
                            prop.value state.Phone
                            prop.onChange (dispatch << Phone)
                        ]
                        phoneError
                        label [ prop.text "Nome do Animal" ]
                        input [
                            prop.fss styles.input
                            prop.placeholder "Por qual animal você se interessou?"
                            prop.value state.Animal
                            prop.onChange (dispatch << Animal)
                        ]
                        animalError
                        label [ prop.text "Mensagem" ]
                        textarea [
                            prop.fss styles.input
                            prop.placeholder "Escreva sua mensagem"
                            prop.rows 9
                            prop.value state.Message
                            prop.onChange (dispatch << Message)
                        ]
                        messageError
                        button [
                            prop.text "Enviar"
                            prop.type' "submit"
                        ]
                    ]
                ]
            ]
        ]
    )
