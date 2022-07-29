module App.Screens.Home

open Fss
open Fss.Types
open App.Design
open App.GlobalStyles
open App.MediaQueries

let private container =
    [ Width.value (vw 100)
      TextAlign.center ]

let private description =
    [ yield! GlobalStyles.Description
      MarginTop.value (px 20)
      MarginBottom.value (px 24)
      Media.query MediaQueries.Mobile [ MaxWidth.value (px 220) ] ]

let private listContainer =
    [ yield! GlobalStyles.MarginAuto
      Custom "display" "inline-grid"
      GridTemplateColumns.repeat (1, fr 1)
      GridGap.value (px 16)
      Media.query MediaQueries.Mobile [ Margin.initial ]
      Media.query MediaQueries.Tablet [ GridTemplateColumns.repeat (2, ContentSize.FitContent(px 364)) ]
      Media.query MediaQueries.Desktop [ GridTemplateColumns.repeat (3, ContentSize.FitContent(px 364)) ] ]

let private listItem =
    [ Display.flex
      BackgroundColor.hex Colors.LightGray
      AlignItems.center
      MaxHeight.value (px 196)
      LastChild [
          MarginBottom.value (px 150)
      ]
      !> Html.All [ FlexGrow.value 1 ] ]

let private itemImage =
    [ MaxWidth.value (pct 50)
      Padding.value (px 24, px 0, px 24, px 24)
      BoxSizing.borderBox ]

let private itemContent =
    [ TextAlign.left
      Color.hex Colors.DarkGray
      PaddingLeft.value (px 16)
      !>
          Html.H2
          [ Color.hex Colors.Blue
            FontSize.value (px 16)
            FontWeight.value 600
            LineHeight.value (px 20)
            MarginBottom.value (px 8) ]
      !>
          Html.P
          [ FontSize.value (px 14)
            LineHeight.value (px 20) ]
      !>
          Html.Div
          [ MarginTop.value (px 30)
            !>
                Html.P
                [ FontSize.value (px 12)
                  LineHeight.value (px 16) ]
            !>
                Html.A
                [ FontSize.value (px 10)
                  TextDecoration.none
                  Color.hex Colors.DarkGray ]
            !
                Html.Img
                [ Width.value (px 18)
                  Height.value (px 18)
                  PaddingRight.value (px 8)
                  Transform.value [
                      Transform.translateY (pct 40)
                  ] ] ] ]

let styles =
    {| container = container
       description = description
       listContainer = listContainer
       listItem = listItem
       itemImage = itemImage
       itemContent = itemContent |}
