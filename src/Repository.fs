module App.Repository

open App.Domain
open App.Dtos.ProfileFormDto
open Browser.WebStorage
open Fable.SimpleJson
open JsModules.BcryptJs
open Dtos.RegisterUserDto

type LocalRepository() =
    let usersStorageKey = "users"
    let currentUserStorageKey = "currentUser"
    let usersDetailsStorageKey = "usersDetails"

    do
        if localStorage.getItem usersStorageKey = null then
            localStorage.setItem (usersStorageKey, Json.stringify [])

        if localStorage.getItem usersDetailsStorageKey = null then
            localStorage.setItem (usersDetailsStorageKey, Json.stringify [])

    let mutable users =
        localStorage.getItem usersStorageKey
        |> Json.parseAs<User list>

    let mutable usersDetails =
        localStorage.getItem usersDetailsStorageKey
        |> Json.parseAs<UserDetails list>

    let updateUsers u =
        users <- u
        localStorage.setItem (usersStorageKey, Json.stringify users)

    let updateUsersDetails u =
        usersDetails <- u
        localStorage.setItem (usersDetailsStorageKey, Json.stringify usersDetails)

    member this.IsLoggedIn() =
        localStorage.getItem currentUserStorageKey <> null

    member this.GetUsers() = users

    member this.GetCurrentUser() =
        localStorage.getItem currentUserStorageKey
        |> Json.parseAs<User>


    member this.GetCurrentUserWithDetails() =
        let user = this.GetCurrentUser()

        let userDetails =
            this.TryGetUserDetails user.Email
            |> Option.defaultValue
                { Email = user.Email
                  Image = None
                  Phone = None
                  City = None
                  Bio = None }

        (user, userDetails)

    member this.TryGetCurrentUserWithDetails() =
        if this.IsLoggedIn() then
            Some(this.GetCurrentUserWithDetails())
        else
            None

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

        updateUsers (users @ [ user ])

        user

    member this.SetCurrentUser user =
        localStorage.setItem (currentUserStorageKey, Json.stringify user)

    member this.TryGetUserDetails userEmail =
        usersDetails
        |> List.tryFind (fun u -> u.Email = userEmail)

    member this.AddOrUpdateUserDetails(userWithDetails: ProfileFormDto) =
        let userIndex =
            users
            |> List.findIndex (fun u -> u.Email = userWithDetails.Email)

        if userWithDetails.Name <> users[userIndex].Name then
            let userArray = users |> List.toArray

            let updatedUser =
                { userArray[userIndex] with Name = userWithDetails.Name }

            userArray[userIndex] <- updatedUser
            updateUsers (userArray |> Array.toList)
            this.SetCurrentUser updatedUser

        let userDetailsIndex =
            usersDetails
            |> List.tryFindIndex (fun u -> u.Email = userWithDetails.Email)

        match userDetailsIndex with
        | Some index ->
            let userDetailsArray =
                usersDetails |> List.toArray

            let updatedUserDetails =
                { userDetailsArray[index] with
                    Image = userWithDetails.Image
                    Phone = userWithDetails.Phone
                    City = userWithDetails.City
                    Bio = userWithDetails.Bio }

            userDetailsArray[userIndex] <- updatedUserDetails
            updateUsersDetails (userDetailsArray |> Array.toList)
        | None ->
            updateUsersDetails (
                usersDetails
                @ [ { Email = userWithDetails.Email
                      Image = userWithDetails.Image
                      Phone = userWithDetails.Phone
                      City = userWithDetails.City
                      Bio = userWithDetails.Bio } ]
            )

    member this.Logout() =
        localStorage.removeItem currentUserStorageKey
