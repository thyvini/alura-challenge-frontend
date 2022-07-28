module App.Railway

let bind = Result.bind

let map = Result.map

let mapError = Result.mapError

let apply fResult xResult =
    match fResult, xResult with
    | Ok f, Ok x -> Ok(f x)
    | Error f, Ok _ -> Error f
    | Ok _, Error x -> Error x
    | Error f, Error x -> Error(List.concat [ f; x ])

let tee (deadEndFunction: 'a -> unit) oneTrackInput =
    deadEndFunction oneTrackInput
    oneTrackInput

let (>>=) twoTrackInput switchFunction = bind switchFunction twoTrackInput
let (<!>) = map
let (<*>) = apply
