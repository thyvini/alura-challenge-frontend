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
                            img [
                                src "img/Logo.png"
                                fss styles.navbarLogo
                            ]
                            a [
                                href (Router.format "")
                                fss styles.navLink
                                children [
                                    img [
                                        src "img/Casa.svg"
                                        fss styles.navLinkImage
                                    ]
                                ]
                            ]
                            a [
                                href (Router.format "mensagem")
                                fss styles.navLink
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
                            href (Router.format "perfil")
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
