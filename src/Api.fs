namespace App.Api

[<RequireQualifiedAccess>]
module Api =

    open Fetch
    open Fable.Core
    open App.JsModules.NodeProcess
    open App.Domain

    let private baseUrl =
        Process.env "SERVER_URL"

    let loadAnimals () =
        promise {
            do! Promise.sleep 1500
            let! response = fetch $"{baseUrl}/animals" []

            let! data = response.json<Animal seq> ()

            return Ok data
        }
        |> Promise.catch Error
        |> Async.AwaitPromise

    let findAnimalById id =
        promise {
            let! response = fetch $"{baseUrl}/animals/{id}" []
            let! data = response.json<Animal> ()
            return Ok data
        }
        |> Promise.catch Error
        |> Async.AwaitPromise
