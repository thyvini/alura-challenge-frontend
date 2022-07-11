module App.Components.StringFormInput

open Fss
open App.Design

let private container =
    [ Display.flex
      FlexDirection.column
      AlignItems.center ]

let styles = {| container = container |}
