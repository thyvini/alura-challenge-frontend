[<RequireQualifiedAccess>]
module App.GlobalStyles

open Fss
open Design
open Fss.Types

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
      Color.hex Colors.DarkGray
      FontSize.value (px 12)
      LineHeight.value (px 16)
      TextAlign.center
      Height.value (px 40)
      Width.value (px 312)
      Placeholder [ Color.hex Colors.Gray ]
      MarginBottom.value (px 12)
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

let FormBox =
    let h2Styles =
        [ Color.hex Colors.DarkGray
          TextAlign.center
          MarginBottom.value (px 16)
          FontWeight.bold
          FontSize.value (px 21)
          LineHeight.value (px 24) ]

    let labelStyles =
        [ Color.hex Colors.Blue
          FontSize.value (px 16)
          LineHeight.value (px 24)
          FontWeight.bold ]

    let buttonStyles =
        [ yield! Button
          yield! MarginAuto
          Display.block
          Width.value (px 164)
          MarginTop.value (px 32)
          Media.query MediaQueries.Mobile [ Width.value (px 148) ] ]

    [ Margin.value (px 24)
      MarginBottom.value (px 150)
      Padding.value (px 32, px 16)
      BorderRadius.value (px 10)
      BackgroundColor.hex Colors.LightGray
      Content.attribute Attribute.Type
      ! Html.H2 h2Styles
      ! Html.Label labelStyles
      ! Html.Button buttonStyles
      Media.query
          MediaQueries.TabletAndDesktop
          [ yield! MarginAuto
            MarginBottom.value (px 150) ]
      Media.query MediaQueries.Tablet [ MaxWidth.value (px 524) ]
      Media.query MediaQueries.Desktop [ MaxWidth.value (px 552) ] ]

let FormBoxTextInput =
    [ Display.block
      Width.value (pct 100)
      BoxSizing.borderBox
      Border.none
      BorderRadius.value (px 6)
      MarginTop.value (px 8)
      MarginBottom.value (px 16)
      Padding.value (px 12, px 16)
      BoxShadow.value (px 0, px 2, px 4, rgba 0 0 0 0.15)
      Resize.none
      Placeholder [ Color.hex Colors.Gray ] ]

let ErrorMessage =
    [ Color.hex Colors.Coral
      FontSize.value (px 12)
      TextAlign.center
      MarginTop.value (px 2)
      MarginBottom.value (px 16) ]
