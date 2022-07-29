module App.Components

open Feliz
open Feliz.UseMediaQuery
open Fss
open App.Design
open App.Components
open App.MediaQueries

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
let Scaffold (backgroundColor: string) (hasPaws: bool) (vectorPosition: VectorPosition) (children: ReactElement) =
    Html.div [
        prop.fss (styles.container backgroundColor)
        prop.children [
            Html.div [
                prop.fss styles.vectorBox
                prop.draggable false
                prop.children [
                    Html.img [
                        prop.src "img/Forma 1.svg"
                        prop.fss styles.vector1
                    ]
                    if hasPaws then
                        Html.img [
                            prop.src "img/Patas.svg"
                            prop.fss styles.paws
                        ]
                    match vectorPosition with
                    | VectorLeft ->
                        Html.img [
                            prop.src "img/Forma 2.svg"
                            prop.fss styles.vector2Inverse
                        ]
                    | VectorRight ->
                        Html.img [
                            prop.src "img/Forma 2.svg"
                            prop.fss styles.vector2
                        ]
                    | VectorNone -> Html.none
                ]
            ]
            Header()
            Html.div [
                prop.fss styles.content
                prop.children children
            ]
            Footer()
        ]
    ]

[<ReactComponent>]
let InitialScreenScaffold children =
    Scaffold Colors.Blue false VectorRight children

[<ReactComponent>]
let UserFormScaffold children =
    let vector = mobileVector VectorLeft

    Scaffold Colors.White true vector children

[<ReactComponent>]
let CommonScaffold children =
    let vector = mobileVector VectorNone

    Scaffold Colors.White false vector children
