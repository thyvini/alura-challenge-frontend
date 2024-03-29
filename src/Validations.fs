﻿module App.Validations

open System
open System.Text.RegularExpressions

[<RequireQualifiedAccess>]
module Validation =
    let email (email: string) =
        let pattern =
            Regex "^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$"

        String.IsNullOrWhiteSpace email |> not
        && email |> pattern.IsMatch

    let password (password: string) =
        let pattern =
            Regex "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"

        password |> pattern.IsMatch

    let confirmPassword (password': string) (confirmPassword: string) =
        password' = confirmPassword
        && (password confirmPassword)

    let name (name: string) =
        name.Length > 1
        && (String.IsNullOrWhiteSpace name |> not)

    let phone (phone: string) =
        let pattern = Regex "\(\d{2}\)\d{5}-\d{4}"

        String.IsNullOrWhiteSpace phone |> not
        && phone |> pattern.IsMatch
    
    let nonEmptyString (str: string) =
        String.IsNullOrWhiteSpace str |> not
