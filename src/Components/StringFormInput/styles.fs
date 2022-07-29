module App.Components.StringFormInput

open Fss

let private container =
    [ Display.flex
      FlexDirection.column
      AlignItems.center ]

let styles = {| container = container |}
