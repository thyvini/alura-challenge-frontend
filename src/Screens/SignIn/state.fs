module App.Screens.SignIn.State

open Feliz.Router
open App.Dtos.LoginUserFormDto
open App.Repository
open App.Validations
open App.Errors
open App.Railway
open App.Domain

type Msg =
    | Email of string
    | Password of string

let updateState (state: LoginUserFormDto) =
    function
    | Email input -> { state with Email = input }
    | Password input -> { state with Password = input }

let createUserEmail email =
    if Validation.email email then
        Ok email
    else
        Error [ InvalidEmail ]

let createUserPassword password =
    if Validation.password password then
        Ok password
    else
        Error [ InvalidPassword ]

let createUserResult (state: LoginUserFormDto) =
    let emailResult =
        createUserEmail state.Email

    let passwordResult =
        createUserPassword state.Password

    LoginUserFormDto.create <!> emailResult
    <*> passwordResult

let tryLoginUser (repository: LocalRepository) (state: LoginUserFormDto) =
    let user =
        repository.TryGetUser state.Email state.Password

    match user with
    | Some user -> Ok user
    | None -> Error [ UserNotFound ]

let login (repository: LocalRepository) (user: User) =
    repository.SetCurrentUser user
    Router.navigate "home"

let makePipeline repository errorDispatcher =
    bind createUserResult
    >> bind (tryLoginUser repository)
    >> map (tee <| login repository)
    >> mapError errorDispatcher
