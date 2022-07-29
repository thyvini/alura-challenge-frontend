module App.Screens

open Browser.Types
open Feliz
open Fss
open App.Components
open App.Screens.Profile.State
open App.Errors
open App.LocalRepositoryContext
open App.GlobalStyles

let private styles = Screens.Profile.styles

[<ReactComponent>]
let Profile () =
    let repository =
        React.useContext localRepositoryContext

    let state, dispatch =
        React.useReducer (updateState, makeInitialState repository)

    let errors, setErrors = React.useState []

    let imageOrDefault =
        state.Image
        |> Option.defaultValue "img/Usuário.png"

    let strOrDefault str = str |> Option.defaultValue ""

    let handleSubmit (event: Event) =
        event.preventDefault ()

        let pipeline =
            makePipeline repository setErrors

        Ok state |> pipeline |> ignore

    CommonScaffold(
        Html.div [
            prop.fss styles.container
            prop.children [
                Html.p [
                    prop.fss styles.description
                    prop.text "Esse é o perfil que aparece para responsáveis ou ONGs que recebem sua mensagem."
                ]
                Html.form [
                    prop.onSubmit handleSubmit
                    prop.fss GlobalStyles.FormBox
                    prop.children [
                        Html.h2 "Perfil"
                        Html.label [
                            prop.children [
                                Html.text "Foto"
                                Html.img [
                                    prop.fss styles.avatar
                                    prop.src imageOrDefault
                                ]
                                Html.p [
                                    prop.fss styles.imageInfo
                                    prop.text "Clique na foto para editar"
                                ]
                                Html.input [
                                    prop.fss styles.imageInput
                                    prop.type' "file"
                                    prop.accept "image/*"
                                    prop.onChange (dispatch << Image << Some)
                                ]
                            ]
                        ]
                        Html.label [ prop.text "Nome" ]
                        Html.input [
                            prop.fss GlobalStyles.FormBoxTextInput
                            prop.placeholder "Insira seu nome completo"
                            prop.value state.Name
                            prop.onChange (dispatch << Name)
                        ]
                        if errors.Length > 0 then
                            Html.p [
                                prop.fss GlobalStyles.ErrorMessage
                                prop.text (
                                    printIfError (Some errors[0])
                                    |> Option.defaultValue ""
                                )
                            ]
                        Html.label [ prop.text "Telefone" ]
                        InputMask.inputMask [
                            prop.fss GlobalStyles.FormBoxTextInput
                            prop.placeholder "Insira seu telefone e/ou whatsapp"
                            inputMask.mask "(99)99999-9999"
                            prop.value (state.Phone |> strOrDefault)
                            prop.onChange (dispatch << Phone)
                        ]
                        Html.label [ prop.text "Cidade" ]
                        Html.input [
                            prop.fss GlobalStyles.FormBoxTextInput
                            prop.placeholder "Insira o nome da sua cidade"
                            prop.value (state.City |> strOrDefault)
                            prop.onChange (dispatch << City)
                        ]
                        Html.label [ prop.text "Sobre" ]
                        Html.textarea [
                            prop.fss GlobalStyles.FormBoxTextInput
                            prop.placeholder "Insira uma descrição sobre você"
                            prop.rows 9
                            prop.value (state.Bio |> strOrDefault)
                            prop.onChange (dispatch << Bio)
                        ]
                        Html.button [
                            prop.text "Salvar"
                            prop.type' "submit"
                        ]
                    ]
                ]
            ]
        ]
    )
