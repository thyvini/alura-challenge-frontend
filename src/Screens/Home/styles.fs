module App.Screens.Home

open Feliz
open Feliz.style
open App.Design
open Fss
open Fss.Types

open type style

let private container =
    [ BackgroundColor.hex (Colors.Blue)
      TextAlign.center
      Color.white
      MinWidth.value (vw 100)
      MinHeight.value (vh 100) ]

let private vetor1 =
    [ Position.absolute
      Right.value (px 0)
      Top.value (Percent 50)
      Transform.value [
          Transform.translateY (Percent -50)
      ] ]

let private logo =
    [ MarginTop.value (px 0)
      MarginBottom.value (px 0)
      MarginLeft.auto
      MarginRight.auto
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

let private button =
    [ width 180
      height 40
      backgroundColor Colors.Coral
      borderRadius 6
      custom (":hover", (margin 0)) ]

let styles =
    {| container = container
       vetor1 = vetor1
       logo = logo
       title = title
       content = content
       button = button |}
