module App.Components

open Design
open App.Components
open Feliz
open Feliz.UseMediaQuery
open Fss
open Fss.Types

open type prop
open type Html

type VectorPosition =
    | VectorLeft
    | VectorRight
    | VectorNone

let private styles = Scaffold.styles

let private mobileVector vector =
    match React.useMediaQuery MediaQueries.MobileMediaQueryString with
    | true -> vector
    | false -> VectorRight

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
                draggable false
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
    let vector = mobileVector VectorLeft
    
    Scaffold Colors.White true vector false children

[<ReactComponent>]
let CommonScaffold children =
    let vector = mobileVector VectorNone
    
    Scaffold Colors.White false vector true children
