module App.Screens

open Feliz
open App.Components
open Fss.Feliz

open type Html
open type prop

let styles = App.Screens.Home.styles

[<ReactComponent>]
let Home () =
    HomeScaffold [
        div [
            fss styles.container
            children [
                img [
                    src "img/Logo.png"
                    srcset "img/Logo.png 1x, img/Logo@2x.png 2x, img/Logo@3x.png 3x"
                    fss styles.logo
                ]
                h1 [
                    fss styles.title
                    text "Boas-vindas!"
                ]
                main [
                    p [
                        fss styles.content
                        text "Que tal mudar sua vida adotando seu novo melhor amigo? Vem com a gente!"
                    ]
                    div [
                        fss styles.buttonBox
                        children [
                            a [
                                fss styles.button
                                text "Já tenho conta"
                            ]
                            a [
                                fss styles.button
                                text "Quero me cadastrar"
                            ]
                        ]
                    ]
                    img [
                        src "img/Ilustração 1.png"
                        srcset "img/Ilustração%201.png 1x, img/Ilustração%201@2x.png 2x, img/Ilustração%201@3x.png 3x"
                        fss styles.illustration
                    ]
                ]
            ]
        ]
    ]
