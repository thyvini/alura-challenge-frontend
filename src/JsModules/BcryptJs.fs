module App.JsModules.BcryptJs

open System
open Fable.Core
open Fable.Core.JS

type IBcryptjs =
    abstract genSaltSync: ?rounds: float * ?minor: string -> string
    abstract genSalt: ?rounds: float * ?callback: (Exception -> string -> unit) -> Promise<string>
    abstract genSalt: ?rounds: float * ?minor: string * ?callback: (Exception -> string -> unit) -> Promise<string>
    abstract genSalt: ?callback: (Exception -> string -> unit) -> Promise<string>
    abstract hashSync: data: obj option * saltOrRounds: string -> string

    abstract hash:
        data: obj option * saltOrRounds: string * ?callback: (Exception -> string -> unit) -> Promise<string>

    abstract compareSync: data: obj option * encrypted: string -> bool
    abstract compare: data: obj option * encrypted: string * ?callback: (Exception -> bool -> unit) -> Promise<bool>
    abstract getRounds: encrypted: string -> float

[<Import("default", "bcryptjs")>]
let bcrypt: IBcryptjs = jsNative
