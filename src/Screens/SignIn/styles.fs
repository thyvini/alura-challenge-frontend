module App.Screens.SignIn

open Fss
open App
open Design
open Fss.Types

let private container =
    [ TextAlign.center
      Width.value (vw 100)
      MaxWidth.value (vw 100)
      Media.query MediaQueries.Mobile [ MinHeight.value (vh 80) ] ]

let private formBox =
    [ yield! GlobalStyles.MarginAuto
      MaxWidth.value (px 312)
      Height.value (px 170)
      MarginBottom.value (px 8)
      Display.flex
      FlexDirection.column
      JustifyContent.spaceBetween ]

let private resetPassword =
    [ Color.hex Colors.Coral
      TextDecorationLine.underline
      Display.block
      FontSize.value (px 12)
      LineHeight.value (px 24)
      MarginBottom.value (px 24) ]

let private buttonWrapper =
    [ yield! GlobalStyles.MarginAuto
      Width.value (px 148)
      Display.flex ]

let private button =
    [ yield! GlobalStyles.Button
      Width.value (pct 100)
      MarginBottom.value (px 48) ]

let styles =
    {| container = container
       formBox = formBox
       resetPassword = resetPassword
       buttonWrapper = buttonWrapper
       button = button |}
