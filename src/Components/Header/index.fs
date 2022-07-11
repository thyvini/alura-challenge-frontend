module App.Components

open Feliz
open Feliz.Router
open Fss.Feliz

open type Html
open type prop

let private styles = Components.Header.styles

[<ReactComponent>]
let Header isLogged =
    header [
        fss styles.container
        children [
            div [
                fss styles.navbarContainer
                children [
                    nav [
                        fss styles.navbar
                        children [
                            a [
                                href (Router.format "")
                                children [
                                    img [
                                        src "img/Casa.svg"
                                        fss styles.navLinkImage
                                    ]
                                ]
                            ]
                            a [
                                href (Router.format "mensagem")
                                children [
                                    img [
                                        src "img/Mensagens.svg"
                                        fss styles.navLinkImage
                                    ]
                                ]
                            ]
                        ]
                    ]
                    if isLogged then
                        a [
                            fss styles.button
                            role "button"
                            tabIndex 0
                            children [
                                img [
                                    fss styles.buttonImage
                                    src "img/Usuário.png"
                                ]
                            ]
                        ]
                ]
            ]
        ]
    ]
