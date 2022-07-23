﻿[<RequireQualifiedAccess>]
module App.GlobalStyles

open Fss
open Design

let inline MarginXAuto (value: 'a) =
    [ MarginTop.value value
      MarginBottom.value value
      MarginRight.auto
      MarginLeft.auto ]

let MarginAuto = MarginXAuto(px 0)

let Button =
    [ BorderRadius.value (px 6)
      FontWeight.value 600
      FontStyle.normal
      Color.white
      Border.none
      BackgroundColor.value (hex Colors.Coral)
      TextDecoration.none
      LineHeight.value (px 24)
      FontSize.value (px 18)
      Padding.value (px 12, px 0)
      Media.query
          MediaQueries.Mobile
          [ FontSize.value (px 16)
            Padding.value (px 8, px 0) ] ]

let Label =
    [ MarginBottom.value (px 4)
      FontSize.value (px 16)
      LineHeight.value (px 24)
      Color.hex Colors.DarkGray ]

let Input =
    [ Width.value (px 312)
      Border.none
      BorderRadius.value (px 6)
      Height.value (px 40)
      BackgroundColor.hex Colors.LightGray
      Color.hex Colors.Gray
      FontSize.value (px 12)
      LineHeight.value (px 16)
      TextAlign.center
      BoxShadow.value (px 0, px 2, px 2, rgba 0 0 0 0.15) ]

let BlueLogo =
    [ yield! MarginAuto
      MarginTop.value (px 20)
      MarginBottom.value (px 24)
      Display.block ]

let Description =
    [ yield! MarginAuto
      TextAlign.center
      Color.hex Colors.Blue
      OverflowWrap.normal
      FontSize.value (px 16)
      LineHeight.value (px 21)
      MarginBottom.value (px 24)
      MaxWidth.value (px 300) ]
