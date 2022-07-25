module App.Screens.Contact

open Fss
open Fss.Types
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

let private content =
    let labelStyles =
        [ Color.hex Colors.Blue
          FontSize.value (px 16)
          LineHeight.value (px 24)
          FontWeight.bold ]

    let inputStyles =
        [ Display.block
          Width.value (pct 100)
          BoxSizing.borderBox
          Border.none
          BorderRadius.value (px 6)
          MarginTop.value (px 8)
          MarginBottom.value (px 16)
          Padding.value (px 12, px 16)
          BoxShadow.value (px 0, px 2, px 4, rgba 0 0 0 0.15)
          Resize.none ]

    let buttonStyles =
        [ yield! GlobalStyles.Button
          yield! GlobalStyles.MarginAuto
          Display.block
          Width.value (px 164)
          MarginTop.value (px 32)
          Media.query MediaQueries.Mobile [ Width.value (px 148) ] ]

    [ Margin.value (px 24)
      MarginBottom.value (px 150)
      Padding.value (px 32, px 16)
      BorderRadius.value (px 10)
      BackgroundColor.hex Colors.LightGray
      ! Html.Label labelStyles
      ! Html.Input inputStyles
      ! Html.Textarea inputStyles
      ! Html.Button buttonStyles
      Media.query
          MediaQueries.TabletAndDesktop
          [ yield! GlobalStyles.MarginAuto
            MarginBottom.value (px 150) ]
      Media.query MediaQueries.Tablet [ MaxWidth.value (px 524) ]
      Media.query MediaQueries.Desktop [ MaxWidth.value (px 552) ] ]

let styles =
    {| container = container
       description = description
       content = content |}
