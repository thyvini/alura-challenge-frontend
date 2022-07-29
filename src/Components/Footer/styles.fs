module App.Components.Footer

open App
open App.Design
open Fss
open Fss.Types

let private footer =
    [ Position.absolute
      Bottom.value (px 0)
      Display.flex
      FlexDirection.column
      JustifyContent.center
      TextAlign.center
      BackgroundColor.hex Colors.Green
      Width.value (vw 100)
      Height.value (px 105)
      Media.query MediaQueries.Desktop [ Height.value (px 80) ] ]

let private text = [ Color.white ]

let private logout =
    [ yield! text
      MarginTop.value (px 6)
      TextDecorationLine.underline
      FontSize.value (px 12)
      Cursor.pointer ]

let styles =
    {| footer = footer
       text = text
       logout = logout |}
