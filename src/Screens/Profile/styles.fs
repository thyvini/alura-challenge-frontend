module App.Screens.Profile

open Fss
open App
open Design

let private container =
    [ Width.value (vw 100) ]

let private description =
    [ yield! GlobalStyles.Description
      MarginTop.value (px 16)
      Media.query MediaQueries.Mobile [ MaxWidth.value (px 226) ]
      Media.query
          MediaQueries.TabletAndDesktop
          [ FontSize.value (px 18)
            LineHeight.value (px 26) ] ]

let private avatar =
    [ yield! GlobalStyles.MarginAuto
      Display.block
      Cursor.pointer
      MarginTop.value (px 8)
      MarginBottom.value (px 4)
      BorderRadius.value (pct 50)
      Width.value (px 80)
      Height.value (px 80)
      MinWidth.value (px 80)
      MinHeight.value (px 80)
      MaxWidth.value (px 80)
      MaxHeight.value (px 80) ]

let private imageInput = [ Display.none ]

let private imageInfo =
    [ Color.hex Colors.Coral
      FontSize.value (px 12)
      LineHeight.value (px 24)
      FontWeight.normal
      TextAlign.center
      Cursor.pointer
      MarginBottom.value (px 5) ]

let styles =
    {| container = container
       description = description
       avatar = avatar
       imageInput = imageInput
       imageInfo = imageInfo |}
