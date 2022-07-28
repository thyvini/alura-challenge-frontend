module App.Repository

open Browser.WebStorage
open Fable.SimpleJson
open JsModules.BcryptJs
open Domain
open Dtos.RegisterUserDto

type LocalRepository() =
    let usersStorageKey = "users"
    let currentUserStorageKey = "currentUser"

    do
        if localStorage.getItem usersStorageKey = null then
            localStorage.setItem (usersStorageKey, Json.stringify [])

    let mutable users =
        localStorage.getItem usersStorageKey
        |> Json.parseAs<User list>

    member this.GetUsers() = users

    member this.UserExists userEmail =
        users
        |> List.exists (fun user -> user.Email = userEmail)

    member this.TryGetUser userEmail userPassword =
        users
        |> List.tryFind (fun user -> user.Email = userEmail)
        |> function
            | Some user ->
                if bcrypt.compareSync (Some userPassword, user.PasswordHash) then
                    Some user
                else
                    None
            | None -> None
    
    member this.AddUser(registerUserDto: RegisterUserDto) =
        let salt = bcrypt.genSaltSync 8

        let user =
            { Name = registerUserDto.Name
              Email = registerUserDto.Email
              PasswordHash = bcrypt.hashSync (Some registerUserDto.Password, salt) }

        users <- users @ [ user ]
        localStorage.setItem (usersStorageKey, Json.stringify users)

        user

    member this.SetCurrentUser user =
        localStorage.setItem (currentUserStorageKey, Json.stringify user)
