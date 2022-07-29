module App.Components

open Feliz
open Feliz.Router
open Fss
open App.LocalRepositoryContext

let private styles =
    App.Components.Footer.styles

[<ReactComponent>]
let Footer () =
    let repository =
        React.useContext localRepositoryContext

    let isLogged = repository.IsLoggedIn()

    Html.footer [
        prop.fss styles.footer
        prop.children [
            Html.p [
                prop.fss styles.text
                prop.text "2022 - Desenvolvido por Alura."
            ]
            if isLogged then
                Html.a [
                    prop.fss styles.logout
                    prop.text "Logout"
                    prop.onClick (fun _ ->
                        repository.Logout()
                        Router.navigate "")
                ]
        ]
    ]
