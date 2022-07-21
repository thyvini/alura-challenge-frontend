module App.Screens.Home

open Fss
open Fss.Types
open App
open Design

let private container =
    [ Width.value (vw 100)
      TextAlign.center ]

let private description =
    [ yield! GlobalStyles.Description
      MarginTop.value (px 20)
      MaxWidth.value (px 220)
      MarginBottom.value (px 24) ]

let private listContainer =
    [ Width.value (Percent 100)
      Display.flex
      FlexDirection.column ]

let private listItem =
    [ Display.flex
      BackgroundColor.hex Colors.LightGray
      Margin.value (px 8, px 0)
      AlignItems.center
      LastChild [ MarginBottom.initial ]
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
            !> Html.A [ FontSize.value (px 10) ]
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
