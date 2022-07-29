module App.Components.Scaffold

open Fss
open Fss.Types
open App.MediaQueries

let private container color =
    [ Position.absolute
      BackgroundColor.hex color
      Overflow.hidden
      MinHeight.value (pct 100)
      MaxWidth.value (pct 100)
      ZIndex.value -3 ]

let private vectorBox =
    [ MaxWidth.value (pct 100)
      ! Html.Img [ UserSelect.none ] ]

let private paws =
    [ Position.absolute
      ZIndex.value 2
      Right.value (px 0) ]

let private vector1 =
    [ MaxWidth.value (px 560)
      Width.value (px 560)
      Media.query MediaQueries.Mobile [ MaxWidth.value (vw 95) ]
      Position.absolute
      ZIndex.value 1
      Media.query MediaQueries.Desktop [ ZIndex.value -1 ] ]

let private vector2 =
    [ Position.absolute
      ZIndex.value -2
      Transform.value [
          Transform.translateY (pct -50)
      ]
      Top.value (pct 50)
      Right.value (px 0)
      Media.query MediaQueries.Mobile [ Right.value (px -10) ] ]

let private vector2Inverse =
    [ yield! vector2
      Left.value (px 0)
      Top.value (pct 37)
      Transform.value [
          Transform.matrix (-1, 0, 0, 1, 0, 0)
      ] ]

let private content =
    [ MaxWidth.value (vw 100) ]

let styles =
    {| container = container
       vectorBox = vectorBox
       paws = paws
       vector1 = vector1
       vector2 = vector2
       vector2Inverse = vector2Inverse
       content = content |}
