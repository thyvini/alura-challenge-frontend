module App

open Feliz
open Feliz.Router
open App

[<ReactComponent>]
let Router () =
    let currentUrl, updateUrl =
        React.useState (Router.currentUrl ())

    React.router [
        router.onUrlChanged updateUrl
        router.children [
            match currentUrl with
            | [] -> Screens.Initial()
            | [ "cadastro" ] -> Screens.SignUp()
            | [ "login" ] -> Screens.SignIn()
            | [ "home" ] -> Screens.Home()
            | [ "animal"; Route.Int id; "contato" ] -> Screens.Contact id
            | _ -> ()
        ]
    ]
