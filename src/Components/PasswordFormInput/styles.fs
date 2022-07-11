module App.Components.PasswordFormInput

open Fss
open App.Design

let private container =
    [ Display.flex
      FlexDirection.column
      AlignItems.center ]

let private icon =
    [ Position.relative
      AlignSelf.end'
      Right.value (px 5)
      Bottom.value (px 30)
      Border.none
      Height.value (px 0)
      BackgroundColor.transparent
      Color.hex Colors.DarkGray ]

let styles =
    {| container = container; icon = icon |}
