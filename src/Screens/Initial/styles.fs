module App.Screens.Initial

open App
open Feliz
open Fss
open Fss.Types

open type style

let private container =
    [ TextAlign.center
      Color.white
      MinWidth.value (vw 100)
      MinHeight.value (vh 100) ]

let private logo =
    [ yield! GlobalStyles.MarginAuto
      Display.block
      PaddingTop.value (px 40) ]

let private title =
    [ FontSize.value (px 26)
      FontWeight.value 500
      LineHeight.value (px 48)
      PaddingTop.value (px 30) ]

let private content =
    [ FontSize.value (px 16)
      LineHeight.value (px 24)
      OverflowWrap.normal
      Margin.value (px 0, px 56)
      PaddingTop.value (px 16) ]

let private buttonBox =
    [ Display.flex
      FlexDirection.column
      yield! GlobalStyles.MarginAuto
      Width.value (px 180)
      Height.value (px 96)
      MarginTop.value (px 24)
      JustifyContent.spaceBetween ]

let private button =
    [ yield! GlobalStyles.Button
      Filter.dropShadow (px 2, px 2, px 4, (rgba 0 0 0 0.25)) ]

let private illustration =
    [ Position.absolute
      Bottom.value (px 75)
      Left.value (Percent 45)
      ZIndex.value -1
      Transform.value [
          Transform.translateX (Percent -50)
      ] ]

let styles =
    {| container = container
       logo = logo
       title = title
       content = content
       buttonBox = buttonBox
       button = button
       illustration = illustration |}
