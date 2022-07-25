module App.Screens

open Browser.Types
open Browser.Url
open Feliz
open Fss
open App.Components

open type Html
open type prop

let private styles = Screens.Profile.styles

[<ReactComponent>]
let Profile () =
    let avatarUrl, setAvatarUrl =
        React.useState "img/Usuário.png"

    let handleAvatarUrlChange (file: File) =
        file |> URL.createObjectURL |> setAvatarUrl

    CommonScaffold(
        div [
            fss styles.container
            children [
                p [
                    fss styles.description
                    text "Esse é o perfil que aparece para responsáveis ou ONGs que recebem sua mensagem."
                ]
                div [
                    fss GlobalStyles.FormBox
                    children [
                        h2 "Perfil"
                        label [
                            children [
                                Html.text "Foto"
                                img [ fss styles.avatar; src avatarUrl ]
                                p [
                                    fss styles.imageInfo
                                    text "Clique na foto para editar"
                                ]
                                input [
                                    fss styles.imageInput
                                    type' "file"
                                    accept "image/*"
                                    onChange handleAvatarUrlChange
                                ]
                            ]
                        ]
                        label [ text "Nome" ]
                        input [
                            fss GlobalStyles.FormBoxTextInput
                            placeholder "Insira seu nome completo"
                        ]
                        label [ text "Telefone" ]
                        input [
                            fss GlobalStyles.FormBoxTextInput
                            placeholder "Insira seu telefone e/ou whatsapp"
                        ]
                        label [ text "Cidade" ]
                        input [
                            fss GlobalStyles.FormBoxTextInput
                            placeholder "Insira o nome da sua cidade"
                        ]
                        label [ text "Sobre" ]
                        textarea [
                            fss GlobalStyles.FormBoxTextInput
                            placeholder "Insira uma descrição sobre você"
                            rows 9
                        ]
                        button [ text "Salvar" ]
                    ]
                ]
            ]
        ]
    )
