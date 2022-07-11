[<RequireQualifiedAccess>]
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
    [ Padding.value (px 8, px 0)
      FontSize.value (px 16)
      FontWeight.value 600
      FontStyle.normal
      LineHeight.value (px 24)
      BackgroundColor.value (hex Colors.Coral)
      BorderRadius.value (px 6) ]
