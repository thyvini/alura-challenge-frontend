module App.Components.Header

open Feliz
open Feliz.style

open type style
open type length

let private container: IStyleAttribute list = []

let private backImage =
    [ backgroundImageUrl "img/Forma 1.svg"
      backgroundRepeat.noRepeat
      position.absolute
      width (percent 100)
      height (percent 100) ]

let private navbarContainer =
    [ display.flex
      position.relative
      zIndex 2
      alignItems.center
      justifyContent.spaceBetween ]

let private navbar = [ marginLeft 25 ]

let private navLinkImage =
    [ width 20; height 20; margin (50, 30) ]

let private button = [ cursor.pointer; margin 40 ]

let private buttonImage = [ width 40; height 40 ]

let styles =
    {| container = container
       backImage = backImage
       navbarContainer = navbarContainer
       navbar = navbar
       navLinkImage = navLinkImage
       button = button
       buttonImage = buttonImage |}
