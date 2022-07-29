module App.JsModules.NodeProcess

open Fable.Core

type Process =
    [<Emit("process.env[$0]")>]
    static member env(_: string) : string = jsNative
