module App.Components

open Design
open App.Components
open Feliz
open Fss
open Fss.Types

open type prop
open type Html

type VectorPosition =
    | VectorLeft
    | VectorRight
    | VectorNone

let styles = Components.Scaffold.styles

[<ReactComponent>]
let inline Scaffold
    (backgroundColor: string)
    (hasPaws: bool)
    (vectorPosition: VectorPosition)
    (isLogged: bool)
    (children: ReactElement list)
    =
    div [
        fss (styles.container backgroundColor)
        prop.children [
            div [
                fss styles.vectorBox
                prop.children [
                    img [
                        src "img/Forma 1.svg"
                        fss styles.vector1
                    ]
                    match vectorPosition with
                    | VectorLeft ->
                        img [
                            src "img/Forma 2.svg"
                            fss styles.vector2Inverse
                        ]
                    | VectorRight ->
                        img [
                            src "img/Forma 2.svg"
                            fss styles.vector2
                        ]
                    | VectorNone -> Html.none
                ]
            ]
            Header isLogged
            div [
                fss styles.content
                prop.children children
            ]
            Footer()
        ]
    ]

let inline HomeScaffold children =
    Scaffold Colors.Blue false VectorRight false children
    
let inline UserFormScaffold children =
    Scaffold Colors.White true VectorLeft false children
