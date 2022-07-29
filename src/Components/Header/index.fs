module App.Components

open Feliz
open Feliz.Router
open Fss.Feliz
open App.LocalRepositoryContext

let private styles =
    Components.Header.styles

[<ReactComponent>]
let Header () =
    let repository =
        React.useContext localRepositoryContext

    let user =
        repository.TryGetCurrentUserWithDetails()

    let isLogged = Option.isSome user

    let image =
        match user with
        | Some (_, userDetails) ->
            match userDetails.Image with
            | Some image -> image
            | None -> "img/Usuário.png"
        | None -> "img/Usuário.png"

    Html.header [
        prop.fss styles.container
        prop.children [
            Html.div [
                prop.fss styles.navbarContainer
                prop.children [
                    Html.nav [
                        prop.fss styles.navbar
                        prop.children [
                            Html.img [
                                prop.src "img/Logo.png"
                                prop.fss styles.navbarLogo
                            ]
                            Html.a [
                                prop.href (Router.format "")
                                prop.fss styles.navLink
                                prop.children [
                                    Html.img [
                                        prop.src "img/Casa.svg"
                                        prop.fss styles.navLinkImage
                                    ]
                                ]
                            ]
                            if isLogged then
                                Html.a [
                                    prop.href (Router.format "mensagem")
                                    prop.fss styles.navLink
                                    prop.children [
                                        Html.img [
                                            prop.src "img/Mensagens.svg"
                                            prop.fss styles.navLinkImage
                                        ]
                                    ]
                                ]
                        ]
                    ]
                    if isLogged then
                        Html.a [
                            prop.fss styles.button
                            prop.role "button"
                            prop.tabIndex 0
                            prop.href (Router.format "perfil")
                            prop.children [
                                Html.img [
                                    prop.fss styles.buttonImage
                                    prop.src image
                                ]
                            ]
                        ]
                ]
            ]
        ]
    ]
