module App.Components

open Feliz
open Fss
open App.Design
open App.GlobalStyles

let private animation =
    keyframes [
        frame
            0
            [ Transform.value [
                  Transform.rotate (deg 0)
              ] ]
        frame
            100
            [ Transform.value [
                  Transform.rotate (deg 360)
              ] ]
    ]

[<ReactComponent>]
let Loader () =
    Html.div [
        prop.fss [
            yield! GlobalStyles.MarginXAuto (px 20)
            BorderStyle.solid
            BorderWidth.value (px 16)
            BorderColor.hex Colors.Gray
            BorderTopColor.hex Colors.Green
            BorderRadius.value (pct 50)
            Width.value (px 120)
            Height.value (px 120)
            AnimationName.value animation
            AnimationDuration.value (sec 1.5)
            AnimationTimingFunction.linear
            AnimationIterationCount.infinite
        ]
    ]
