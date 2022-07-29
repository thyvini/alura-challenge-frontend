module App.Screens.SignUp.State

open App
open Feliz.Router
open Validations
open Railway
open Repository
open Dtos.CreateUserFormDto
open Dtos.RegisterUserDto
open Errors

type Msg =
    | Email of string
    | Name of string
    | Password of string
    | PasswordConfirmation of string

let updateState (state: CreateUserFormDto) =
    function
    | Email input -> { state with Email = input }
    | Name input -> { state with Name = input }
    | Password input -> { state with Password = input }
    | PasswordConfirmation input -> { state with PasswordConfirmation = input }

let initialState =
    CreateUserFormDto.create "" "" "" ""

let createUserEmail email =
    if Validation.email email then
        Ok email
    else
        Error [ CreateUserError.InvalidEmail ]

let createUserName name =
    if Validation.name name then
        Ok name
    else
        Error [ CreateUserError.InvalidName ]

let createUserPassword password =
    if Validation.password password then
        Ok password
    else
        Error [
            CreateUserError.InvalidPassword
        ]

let createUserPasswordConfirmation password passwordConfirmation =
    if Validation.confirmPassword password passwordConfirmation then
        Ok passwordConfirmation
    else
        Error [
            CreateUserError.InvalidPasswordConfirmation
        ]

let createUserResult (state: CreateUserFormDto) =
    let emailResult =
        createUserEmail state.Email

    let nameResult = createUserName state.Name

    let passwordResult =
        createUserPassword state.Password

    let passwordConfirmationResult =
        createUserPasswordConfirmation state.Password state.PasswordConfirmation

    CreateUserFormDto.create <!> emailResult
    <*> nameResult
    <*> passwordResult
    <*> passwordConfirmationResult

let checkIfUserExists (repository: LocalRepository) (state: CreateUserFormDto) =
    if repository.UserExists state.Email |> not then
        Ok state
    else
        Error [ EmailAlreadyExists ]

let saveAndLogin (repository: LocalRepository) (state: CreateUserFormDto) =
    let user =
        { Name = state.Name
          Email = state.Email
          Password = state.Password }

    user
    |> repository.AddUser
    |> repository.SetCurrentUser

let forward (_: CreateUserFormDto) = Router.navigate "home"

let makePipeline repository errorDispatcher =
    bind createUserResult
    >> bind (checkIfUserExists repository)
    >> map (tee <| saveAndLogin repository)
    >> map (tee forward)
    >> mapError errorDispatcher
