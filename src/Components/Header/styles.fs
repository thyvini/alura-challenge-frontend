module App.Components.Header

open Fss
open App.MediaQueries

let private container =
    [ Position.relative ]

let private navbarContainer =
    [ Display.flex
      Position.relative
      ZIndex.value 5
      AlignItems.center
      JustifyContent.spaceBetween ]

let private navbar =
    [ Padding.value (px 50, px 25, px 70)
      Media.query MediaQueries.Tablet [ Padding.value (px 64, px 25, px 140, px 50) ]
      Media.query MediaQueries.Desktop [ Padding.value (px 64, px 25, px 50, px 160) ] ]

let private navbarLogo =
    [ MaxWidth.value (px 128)
      MarginRight.value (px 24)
      Display.inlineBlock
      VerticalAlign.middle
      Media.query MediaQueries.Tablet [ MarginRight.value (px 32) ]
      Media.query MediaQueries.Mobile [ Display.none ] ]

let private navLink =
    [ Margin.value (px 68, px 24)
      Padding.value (px 2)
      VerticalAlign.middle
      Media.query MediaQueries.Tablet [ Margin.value (px 68, px 32) ] ]

let private navLinkImage =
    [ Width.value (px 24)
      Height.value (px 24)
      VerticalAlign.middle ]

let private button =
    [ Cursor.pointer; Margin.value (px 40) ]

let private buttonImage =
    [ Width.value (px 40)
      Height.value (px 40) ]

let styles =
    {| container = container
       navbarContainer = navbarContainer
       navbar = navbar
       navbarLogo = navbarLogo
       navLink = navLink
       navLinkImage = navLinkImage
       button = button
       buttonImage = buttonImage |}
