namespace App.Api

open Fable.Core
open Thoth.Fetch
open Thoth.Json
open App.JsModules.NodeProcess
open App.Domain

[<RequireQualifiedAccess>]
module Api =

    let private baseUrl =
        Process.env "SERVER_URL"

    let loadAnimals () =
        promise {
            do! Promise.sleep 1500
            let! response = Fetch.get<_, Animal list>($"{baseUrl}/animals", caseStrategy = CamelCase)
            return Ok response
        }
        |> Promise.catch Error
        |> Async.AwaitPromise

    let findAnimalById id =
        promise {
            let! response = Fetch.get<_, Animal>($"{baseUrl}/animals/{id}", caseStrategy = CamelCase)
            return Ok response
        }
        |> Promise.catch Error
        |> Async.AwaitPromise
