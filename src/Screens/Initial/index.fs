module App.Screens

open Feliz
open Feliz.Router
open Feliz.UseMediaQuery
open Fss
open App.Components
open App.MediaQueries

let private styles =
    App.Screens.Initial.styles

[<ReactComponent>]
let Initial () =
    let isMobile =
        React.useMediaQuery MediaQueries.MobileMediaQueryString

    InitialScreenScaffold(
        Html.div [
            prop.fss styles.container
            prop.children [
                Html.img [
                    prop.src "img/Logo.png"
                    prop.srcset
                        "img/Logo.png 1x,
                        img/Logo@2x.png 2x,
                        img/Logo@3x.png 3x"
                    prop.fss styles.logo
                ]
                Html.h1 [
                    prop.fss styles.title
                    prop.text "Boas-vindas!"
                ]
                Html.main [
                    Html.p [
                        prop.fss styles.content
                        prop.text (
                            if isMobile then
                                "Que tal mudar sua vida adotando seu novo melhor amigo? Vem com a gente!"
                            else
                                "Adotar pode mudar uma vida. Que tal buscar seu novo melhor amigo hoje? Vem com a gente!"
                        )
                    ]
                    Html.div [
                        prop.fss styles.buttonBox
                        prop.children [
                            Html.a [
                                prop.fss styles.button
                                prop.href (Router.format "login")
                                prop.text "Já tenho conta"
                            ]
                            Html.a [
                                prop.fss styles.button
                                prop.href (Router.format "cadastro")
                                prop.text "Quero me cadastrar"
                            ]
                        ]
                    ]
                    Html.img [
                        prop.src "img/Ilustração 1.png"
                        prop.srcset
                            "img/Ilustração%201.png 1x,
                            img/Ilustração%201@2x.png 2x,
                            img/Ilustração%201@3x.png 3x"
                        prop.fss styles.illustration
                    ]
                ]
            ]
        ]
    )
