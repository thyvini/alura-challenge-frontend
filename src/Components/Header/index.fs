module App.Components

open Feliz
open Fss.Feliz

open type Html
open type prop

let styles = Components.Header.styles

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
                                href "/"
                                children [
                                    img [
                                        src "img/Casa.svg"
                                        fss styles.navLinkImage
                                    ]
                                ]
                            ]
                            a [
                                href "/mensagem"
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
