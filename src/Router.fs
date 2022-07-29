module App

open Feliz
open Feliz.Router
open App
open LocalRepositoryContext

type private LoggedIn =
    | Logged
    | NotLogged

[<ReactComponent>]
let private RedirectIf (loggedOrNot: LoggedIn) (route: string) (children: ReactElement) =
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
let private RedirectIfLogged route children = RedirectIf Logged route children

[<ReactComponent>]
let private RedirectIfNotLogged route children = RedirectIf NotLogged route children

[<ReactComponent>]
let Router () =
    let currentUrl, updateUrl =
        React.useState (Router.currentUrl ())

    React.router [
        router.onUrlChanged updateUrl
        router.children [
            match currentUrl with
            | [] -> RedirectIfLogged "home" (Screens.Initial())
            | [ "cadastro" ] -> RedirectIfLogged "home" (Screens.SignUp())
            | [ "login" ] -> RedirectIfLogged "home" (Screens.SignIn())
            | [ "home" ] -> RedirectIfNotLogged "" (Screens.Home())
            | [ "mensagem" ] -> RedirectIfNotLogged "" (Screens.Contact 0)
            | [ "animal"; Route.Int id; "contato" ] -> RedirectIfNotLogged "" (Screens.Contact id)
            | [ "perfil" ] -> Screens.Profile()
            | _ -> ()
        ]
    ]
