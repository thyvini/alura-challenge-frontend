module App.Errors

open Microsoft.FSharp.Reflection

type IErrorUnion =
    abstract GetMessage: unit -> string

let getMessage (e: #IErrorUnion) = e.GetMessage()

type CreateUserError =
    | InvalidEmail
    | InvalidName
    | InvalidPassword
    | InvalidPasswordConfirmation
    | EmailAlreadyExists
    interface IErrorUnion with
        member this.GetMessage() =
            match this with
            | InvalidEmail -> "E-mail inválido"
            | InvalidName -> "Nome inválido"
            | InvalidPassword ->
                "A senha deve conter 8 caracteres, incluindo uma letra maiúscula, uma letra minúscula, um número e um caracter especial"
            | InvalidPasswordConfirmation -> "As senhas devem coincidir"
            | EmailAlreadyExists -> "Este e-mail já está cadastrado"

type LoginUserError =
    | InvalidEmail
    | InvalidPassword
    | UserNotFound
    interface IErrorUnion with
        member this.GetMessage() =
            match this with
            | _ -> "E-mail e/ou senha incorretos"

type ProfileEditError =
    | MissingName
    interface IErrorUnion with
        member this.GetMessage() =
            match this with
            | MissingName -> "O nome é obrigatório"

type ContactError =
    | MissingName
    | MissingPhone
    | MissingAnimal
    | MissingMessage
    interface IErrorUnion with
        member this.GetMessage() =
            match this with
            | _ -> "Preencha este campo corretamente"

let printIfError (error: #IErrorUnion option) = error |> Option.map getMessage

let inline getUnionType<'T> (union: ^T) =
    let case, _ =
        FSharpValue.GetUnionFields(union, typeof<'T>)

    case.Name

let inline findMatchingError targetUnion (errorType: #IErrorUnion) = getUnionType errorType = targetUnion

let inline findMatchingErrors targetUnions (errorType: #IErrorUnion) =
    let typeName = getUnionType errorType

    targetUnions
    |> List.exists (fun u -> u = typeName)

let inline findError (errors: #IErrorUnion list) targetErrorName =
    errors
    |> List.tryFind (findMatchingError targetErrorName)

let inline findErrors (errors: #IErrorUnion list) targetErrors =
    errors
    |> List.tryFind (findMatchingErrors targetErrors)
