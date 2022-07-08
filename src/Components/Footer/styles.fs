module App.Components.Footer

open App.Design
open Feliz
open Feliz.style

open type style
open type length

let footer =
    [ width (percent 100)
      height 105
      position.absolute
      bottom 0
      textAlign.center
      backgroundColor Colors.Green ]

let text = [
    position.relative
    top 50
    transform.translateY (-50 |> percent)
    color color.white
]

let styles =
    {| footer = footer; text = text |}
