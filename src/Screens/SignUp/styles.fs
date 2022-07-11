﻿module App.Screens.SignUp

open Fss
open App
open Design

let private container =
    [ Width.value (vw 100)
      MaxWidth.value (vw 100)
      MinHeight.value (vh 80)
      TextAlign.center ]

let private formBox =
    [ yield! GlobalStyles.MarginAuto
      MaxWidth.value (px 312)
      Height.value (px 340)
      MarginBottom.value (px 24)
      Display.flex
      FlexDirection.column
      JustifyContent.spaceBetween ]

let private button =
    [ yield! GlobalStyles.Button
      Width.value (px 148)
      MarginBottom.value (px 105) ]

let styles =
    {| container = container
       formBox = formBox
       button = button |}
