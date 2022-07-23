module App.Components.Footer

open App
open App.Design
open Fss
open Fss.Types

let private footer =
    [ Position.absolute
      Bottom.value (px 0)
      TextAlign.center
      BackgroundColor.hex Colors.Green
      Width.value (vw 100)
      Height.value (px 105)
      Media.query MediaQueries.Desktop [ Height.value (px 80) ] ]

let private text =
    [ Position.relative
      Top.value (Percent 50)
      Color.white
      Transform.value [
          Transform.translateY (Percent -50)
      ] ]

let styles =
    {| footer = footer; text = text |}
