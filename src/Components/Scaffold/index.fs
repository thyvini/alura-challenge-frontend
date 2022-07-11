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

let styles = Scaffold.styles

[<ReactComponent>]
let Scaffold
    (backgroundColor: string)
    (hasPaws: bool)
    (vectorPosition: VectorPosition)
    (isLogged: bool)
    (children: ReactElement)
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
                    if hasPaws then
                        img [
                            src "img/Patas.svg"
                            fss styles.paws
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

[<ReactComponent>]
let InitialScreenScaffold children =
    Scaffold Colors.Blue false VectorRight false children
    
[<ReactComponent>]
let UserFormScaffold children =
    Scaffold Colors.White true VectorLeft false children
