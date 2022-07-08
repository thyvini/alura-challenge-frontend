module App.Components

open Feliz

open type Html
open type prop

let styles = Components.Header.styles

[<ReactComponent>]
let Header estaLogado =
    header [
        style styles.container
        children [
            div [
                style styles.backImage
            ]
            div [
                style styles.navbarContainer
                children [
                    nav [
                        style styles.navbar
                        children [
                            a [
                                href "/"
                                children [
                                    img [
                                        src "img/Casa.svg"
                                        style styles.navLinkImage
                                    ]
                                ]
                            ]
                            a [
                                href "/mensagem"
                                children [
                                    img [
                                        src "img/Mensagens.svg"
                                        style styles.navLinkImage
                                    ]
                                ]
                            ]
                        ]
                    ]
                    if estaLogado then
                        a [
                            style styles.button
                            role "button"
                            tabIndex 0
                            children [
                                img [
                                    style styles.buttonImage
                                    src "img/Usuário.png"
                                ]
                            ]
                        ]
                ]
            ]
        ]
    ]
