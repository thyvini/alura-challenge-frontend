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
    [ BorderRadius.value (px 6)
      FontWeight.value 600
      FontStyle.normal
      Color.white
      Border.none
      BackgroundColor.value (hex Colors.Coral)
      TextDecoration.none
      LineHeight.value (px 24)
      FontSize.value (px 16)
      Padding.value (px 8, px 0)
      Cursor.pointer ]

let ResponsiveButton =
    [ yield! Button
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
    [ BoxShadow.value (px 0, px 2, px 2, rgba 0 0 0 0.15)
      Border.none
      BorderRadius.value (px 6)
      BackgroundColor.hex Colors.LightGray
      Color.hex Colors.Gray
      FontSize.value (px 12)
      LineHeight.value (px 16)
      TextAlign.center
      Height.value (px 40)
      Width.value (px 312)
      Media.query MediaQueries.Tablet [ Width.value (px 344) ]
      Media.query MediaQueries.Desktop [ Width.value (px 362) ] ]

let DesktopBigInput =
    [ Media.query MediaQueries.Desktop [ Width.value (px 552) ] ]

let BlueLogo =
    [ yield! MarginAuto
      MarginTop.value (px 20)
      MarginBottom.value (px 24)
      Display.block
      Media.query MediaQueries.Desktop [ MarginTop.value (px 0) ] ]

let Description =
    [ yield! MarginAuto
      TextAlign.center
      Color.hex Colors.Blue
      OverflowWrap.normal
      MarginBottom.value (px 24)
      LineHeight.value (px 26)
      FontSize.value (px 18)
      MaxWidth.value (px 300)
      Media.query
          MediaQueries.Mobile
          [ FontSize.value (px 16)
            LineHeight.value (px 21) ]
      Media.query MediaQueries.Tablet [ MaxWidth.value (px 525) ]
      Media.query MediaQueries.Desktop [ MaxWidth.value (px 552) ] ]
