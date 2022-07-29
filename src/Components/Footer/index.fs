module App.Components

open Feliz
open Feliz.Router
open Fss
open LocalRepositoryContext

open type Html
open type prop

let private styles =
    App.Components.Footer.styles

[<ReactComponent>]
let Footer () =
    let repository =
        React.useContext localRepositoryContext

    let isLogged = repository.IsLoggedIn()

    footer [
        fss styles.footer
        children [
            p [
                fss styles.text
                text "2022 - Desenvolvido por Alura."
            ]
            if isLogged then
                a [
                    fss styles.logout
                    text "Logout"
                    onClick (fun _ ->
                        repository.Logout()
                        Router.navigate "")
                ]
        ]
    ]
