module App.Components.Scaffold

open Fss
open Fss.Types

let private container color =
    [ Position.absolute
      BackgroundColor.hex color
      Overflow.hidden
      MinHeight.value (Percent 100)
      MaxWidth.value (Percent 100)
      ZIndex.value -3 ]

let private vectorBox =
    [ MaxWidth.value (Percent 100) ]

let private paws =
    [ Position.absolute
      ZIndex.value -2
      Right.value (px 0) ]

let private vector1 =
    [ MaxWidth.value (vw 95)
      Position.absolute
      ZIndex.value -2 ]

let private vector2 =
    [ Position.absolute
      Right.value (px -5)
      Top.value (Percent 50)
      ZIndex.value -2
      Transform.value [
          Transform.translateY (Percent -50)
      ] ]

let private vector2Inverse =
    [ yield! vector2
      Left.value (px 0)
      Top.value (Percent 37)
      Transform.value [
          Transform.matrix (-1, 0, 0, 1, 0, 0)
      ] ]

let private content =
    [ MinHeight.value (Percent 100)
      MaxWidth.value (vw 100) ]

let styles =
    {| container = container
       vectorBox = vectorBox
       paws = paws
       vector1 = vector1
       vector2 = vector2
       vector2Inverse = vector2Inverse
       content = content |}
