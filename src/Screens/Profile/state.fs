module App.Screens.Profile.State

open System
open Browser.Url
open Browser.Types
open App.Dtos.ProfileFormDto
open App.Validations
open App.Errors
open App.Repository
open App.Railway

type Msg =
    | Name of string
    | Image of File option
    | Phone of string
    | City of string
    | Bio of string

let tryEmitString str =
    if not (String.IsNullOrWhiteSpace str) then
        Some str
    else
        None

let updateState (state: ProfileFormDto) =
    function
    | Name input -> { state with Name = input }
    | Image input -> { state with Image = input |> Option.map URL.createObjectURL }
    | Phone input -> { state with Phone = input |> tryEmitString }
    | City input -> { state with City = input |> tryEmitString }
    | Bio input -> { state with Bio = input |> tryEmitString }

let makeInitialState (repository: LocalRepository) =
    let user, userDetails =
        repository.GetCurrentUserWithDetails()

    ProfileFormDto.create user.Email user.Name userDetails.Image userDetails.Phone userDetails.City userDetails.Bio

let createName name =
    if Validation.name name then
        Ok name
    else
        Error [ ProfileEditError.MissingName ]

let createProfileUpdateResult (state: ProfileFormDto) =
    let nameResult = createName state.Name

    ProfileFormDto.create <!> (Ok state.Email)
    <*> nameResult
    <*> (Ok state.Image)
    <*> (Ok state.Phone)
    <*> (Ok state.City)
    <*> (Ok state.Bio)

let save (repository: LocalRepository) (state: ProfileFormDto) = repository.AddOrUpdateUserDetails state

let makePipeline repository (errorDispatcher: ProfileEditError list -> unit) =
    let cleanErrors _ = errorDispatcher []

    bind createProfileUpdateResult
    >> map (tee <| save repository)
    >> map (tee cleanErrors)
    >> mapError errorDispatcher
