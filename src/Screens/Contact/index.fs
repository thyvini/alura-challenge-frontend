module App.Screens

open Feliz
open Fss
open App.Components

open type Html
open type prop

let private styles = Screens.Contact.styles

[<ReactComponent>]
let Contact (id: int) =
    CommonScaffold(
        div [
            fss styles.container
            children [
                p [
                    fss styles.description
                    text "Envie uma mensagem para a pessoa ou instituição que está cuidando do animal:"
                ]
                div [
                    fss styles.content
                    children [
                        label [ text "Nome" ]
                        input [
                            placeholder "Insira seu nome completo"
                        ]
                        label [ text "Telefone" ]
                        input [
                            placeholder "Insira seu telefone e/ou whatsapp"
                        ]
                        label [ text "Nome do Animal" ]
                        input [
                            placeholder "Por qual animal você se interessou?"
                        ]
                        label [ text "Mensagem" ]
                        textarea [
                            placeholder "Escreva sua mensagem"
                            rows 10
                        ]
                        button [ text "Enviar" ]
                    ]
                ]
            ]
        ]
    )
