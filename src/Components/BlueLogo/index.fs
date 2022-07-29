module App.Components

open Feliz
open Fss
open App.GlobalStyles

[<ReactComponent>]
let BlueLogo () =
    Html.img [
        prop.src "img/Logo2.png"
        prop.srcset
            "img/Logo2.png 1x,
            img/Logo2@2x.png 2x,
            img/Logo2@3x.png 3x"
        prop.fss GlobalStyles.BlueLogo
    ]
