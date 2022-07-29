module Main

open Feliz
open App
open Browser.Dom
open Fable.Core.JsInterop
open Repository
open LocalRepositoryContext

importSideEffects "./styles/global.scss"

let repository = LocalRepository()

ReactDOM.render (
    React.strictMode [
        LocalRepositoryProvider repository (Router())
    ],
    document.getElementById "feliz-app"
)
