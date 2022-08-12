module App.JsModules.NodeProcess

open Fable.Core

type INodeProcess =
    [<Emit("process.env[$1]")>]
    member this.env(_: string) : string = jsNative

[<Global("process")>]
let nodeProcess : INodeProcess = jsNative
