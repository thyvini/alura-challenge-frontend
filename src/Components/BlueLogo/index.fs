module App.Components

open Feliz
open Fss

open type Html
open type prop

[<ReactComponent>]
let BlueLogo () =
    img [
        src "img/Logo2.png"
        srcset
            "img/Logo2.png 1x,
            img/Logo2@2x.png 2x,
            img/Logo2@3x.png 3x"
        fss GlobalStyles.BlueLogo
    ]
