module App.Screens.Contact

open Fss
open App.GlobalStyles
open App.MediaQueries

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

let private content = GlobalStyles.FormBox

let private input =
    GlobalStyles.FormBoxTextInput

let styles =
    {| container = container
       description = description
       content = content
       input = input |}
