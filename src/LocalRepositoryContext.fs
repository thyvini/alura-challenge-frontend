module App.LocalRepositoryContext

open Feliz
open App.Repository

let localRepositoryContext =
    React.createContext<LocalRepository> (name = "LocalRepository")

[<ReactComponent>]
let LocalRepositoryProvider (repository: LocalRepository) (children: ReactElement) =
    React.contextProvider (localRepositoryContext, repository, children)
