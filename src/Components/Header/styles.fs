module App.Components.Header

open Feliz.style
open Fss

let private container =
    [ Position.relative ]

let private navbarContainer =
    [ Display.flex
      Position.relative
      ZIndex.value 1
      AlignItems.center
      JustifyContent.spaceBetween ]

let private navbar =
    [ MarginLeft.value (px 25) ]

let private navLinkImage =
    [ Width.value (px 20)
      Height.value (px 20)
      Margin.value (px 50, px 30) ]

let private button =
    [ Cursor.pointer; Margin.value (px 40) ]

let private buttonImage =
    [ Width.value (px 40)
      Height.value (px 40) ]

let styles =
    {| container = container
       navbarContainer = navbarContainer
       navbar = navbar
       navLinkImage = navLinkImage
       button = button
       buttonImage = buttonImage |}
