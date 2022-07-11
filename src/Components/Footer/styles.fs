module App.Components.Footer

open App.Design
open Fss
open Fss.Types

let private footer =
    [ MaxWidth.value (vw 100)
      Height.value (px 105)
      Position.relative
      Bottom.value (px 0)
      TextAlign.center
      BackgroundColor.hex Colors.Green ]

let private text =
    [ Position.relative
      Top.value (Percent 50)
      Color.white
      Transform.value [
          Transform.translateY (Percent -50)
      ] ]
    
let styles =
    {| footer = footer; text = text |}
