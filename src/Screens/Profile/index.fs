module App.Screens

open Browser.Types
open Feliz
open Fss
open App.Components
open Screens.Profile.State
open Errors
open LocalRepositoryContext

open type Html
open type prop

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
        div [
            fss styles.container
            children [
                p [
                    fss styles.description
                    text "Esse é o perfil que aparece para responsáveis ou ONGs que recebem sua mensagem."
                ]
                Html.form [
                    onSubmit handleSubmit
                    fss GlobalStyles.FormBox
                    children [
                        h2 "Perfil"
                        label [
                            children [
                                Html.text "Foto"
                                img [
                                    fss styles.avatar
                                    src imageOrDefault
                                ]
                                p [
                                    fss styles.imageInfo
                                    text "Clique na foto para editar"
                                ]
                                input [
                                    fss styles.imageInput
                                    type' "file"
                                    accept "image/*"
                                    onChange (dispatch << Image << Some)
                                ]
                            ]
                        ]
                        label [ text "Nome" ]
                        input [
                            fss GlobalStyles.FormBoxTextInput
                            placeholder "Insira seu nome completo"
                            value state.Name
                            onChange (dispatch << Name)
                        ]
                        if errors.Length > 0 then
                            p [
                                fss GlobalStyles.ErrorMessage
                                text (
                                    printIfError (Some errors[0])
                                    |> Option.defaultValue ""
                                )
                            ]
                        label [ text "Telefone" ]
                        InputMask.inputMask [
                            fss GlobalStyles.FormBoxTextInput
                            placeholder "Insira seu telefone e/ou whatsapp"
                            inputMask.mask "(99)99999-9999"
                            value (state.Phone |> strOrDefault)
                            onChange (dispatch << Phone)
                        ]
                        label [ text "Cidade" ]
                        input [
                            fss GlobalStyles.FormBoxTextInput
                            placeholder "Insira o nome da sua cidade"
                            value (state.City |> strOrDefault)
                            onChange (dispatch << City)
                        ]
                        label [ text "Sobre" ]
                        textarea [
                            fss GlobalStyles.FormBoxTextInput
                            placeholder "Insira uma descrição sobre você"
                            rows 9
                            value (state.Bio |> strOrDefault)
                            onChange (dispatch << Bio)
                        ]
                        button [ text "Salvar"; type' "submit" ]
                    ]
                ]
            ]
        ]
    )
