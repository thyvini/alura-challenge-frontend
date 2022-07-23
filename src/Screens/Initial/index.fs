module App.Screens

open Feliz
open App.Components
open Feliz.Router
open Fss.Feliz
open Feliz.UseMediaQuery

open type Html
open type prop

let private styles =
    App.Screens.Initial.styles

[<ReactComponent>]
let Initial () =
    let isMobile =
        React.useMediaQuery MediaQueries.MobileMediaQueryString

    InitialScreenScaffold(
        div [
            fss styles.container
            children [
                img [
                    src "img/Logo.png"
                    srcset
                        "img/Logo.png 1x,
                        img/Logo@2x.png 2x,
                        img/Logo@3x.png 3x"
                    fss styles.logo
                ]
                h1 [
                    fss styles.title
                    text "Boas-vindas!"
                ]
                main [
                    p [
                        fss styles.content
                        text (
                            if isMobile then
                                "Que tal mudar sua vida adotando seu novo melhor amigo? Vem com a gente!"
                            else
                                "Adotar pode mudar uma vida. Que tal buscar seu novo melhor amigo hoje? Vem com a gente!"
                        )
                    ]
                    div [
                        fss styles.buttonBox
                        children [
                            a [
                                fss styles.button
                                href (Router.format "login")
                                text "Já tenho conta"
                            ]
                            a [
                                fss styles.button
                                href (Router.format "cadastro")
                                text "Quero me cadastrar"
                            ]
                        ]
                    ]
                    img [
                        src "img/Ilustração 1.png"
                        srcset
                            "img/Ilustração%201.png 1x,
                            img/Ilustração%201@2x.png 2x,
                            img/Ilustração%201@3x.png 3x"
                        fss styles.illustration
                    ]
                ]
            ]
        ]
    )
