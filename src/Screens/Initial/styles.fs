module App.Screens.Initial

open Fss
open App.MediaQueries
open App.GlobalStyles


let private container =
    [ TextAlign.center
      Color.white
      MinWidth.value (vw 100)
      Media.query MediaQueries.Desktop [ Height.initial ] ]

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
    [ yield! GlobalStyles.MarginAuto
      FontSize.value (px 16)
      LineHeight.value (px 24)
      OverflowWrap.normal
      PaddingTop.value (px 16)
      MaxWidth.value (px 248)
      Media.query
          MediaQueries.Tablet
          [ MaxWidth.value (px 344)
            FontSize.value (px 18)
            LineHeight.value (px 26) ]
      Media.query
          MediaQueries.Desktop
          [ MaxWidth.value (px 488)
            FontSize.value (px 18)
            LineHeight.value (px 26) ] ]

let private buttonBox =
    [ yield! GlobalStyles.MarginAuto
      Display.flex
      FlexDirection.column
      JustifyContent.spaceBetween
      MarginTop.value (px 24)
      MarginBottom.value (px 420)
      Height.value (px 96)
      Width.value (px 180)
      Media.query
          MediaQueries.Tablet
          [ Height.value (px 112)
            Width.value (px 344) ]
      Media.query
          MediaQueries.Desktop
          [ Height.value (px 112)
            Width.value (px 362) ] ]

let private button =
    [ yield! GlobalStyles.ResponsiveButton
      Filter.dropShadow (px 2, px 2, px 4, (rgba 0 0 0 0.25)) ]

let private illustration =
    [ Position.absolute
      Bottom.value (px 75)
      ZIndex.value -1
      Left.value (pct 50)
      Transform.value [
          Transform.translateX (pct -50)
      ]
      Media.query MediaQueries.Mobile [ Left.value (pct 45) ]
      Media.query MediaQueries.Desktop [ Bottom.value (px 55) ] ]

let styles =
    {| container = container
       logo = logo
       title = title
       content = content
       buttonBox = buttonBox
       button = button
       illustration = illustration |}
