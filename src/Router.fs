module App

open Feliz
open Feliz.Router
open App.LocalRepositoryContext
open App.Screens

type private LoggedIn =
    | Logged
    | NotLogged

[<ReactComponent>]
let private redirectIf (loggedOrNot: LoggedIn) (route: string) (children: ReactElement) =
    let repository =
        React.useContext localRepositoryContext

    let isLogged = repository.IsLoggedIn()

    match loggedOrNot, isLogged with
    | Logged, true
    | NotLogged, false ->
        Router.navigate route
        React.fragment []
    | _, _ -> React.fragment [ children ]

[<ReactComponent>]
let private redirectIfLogged route children = redirectIf Logged route children

[<ReactComponent>]
let private redirectIfNotLogged route children = redirectIf NotLogged route children

[<ReactComponent>]
let Router () =
    let currentUrl, updateUrl =
        React.useState (Router.currentUrl ())

    React.router [
        router.onUrlChanged updateUrl
        router.children [
            match currentUrl with
            | [] -> Initial() |> redirectIfLogged "home"
            | [ "cadastro" ] -> SignUp() |> redirectIfLogged "home"
            | [ "login" ] -> SignIn() |> redirectIfLogged "home"
            | [ "home" ] -> Home() |> redirectIfNotLogged ""
            | [ "mensagem" ] -> Contact 0 |> redirectIfNotLogged ""
            | [ "animal"; Route.Int id; "contato" ] -> Contact id |> redirectIfNotLogged ""
            | [ "perfil" ] -> Profile() |> redirectIfNotLogged ""
            | _ -> ()
        ]
    ]
