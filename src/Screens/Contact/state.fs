﻿module App.Screens.Contact.State

open Feliz.Router
open App.Dtos.ContactFormDto
open App.Validations
open App.Errors
open App.Railway

type Msg =
    | Name of string
    | Phone of string
    | Animal of string
    | Message of string

let updateState (state: ContactFormDto) =
    function
    | Name input -> { state with Name = input }
    | Phone input -> { state with Phone = input }
    | Animal input -> { state with Animal = input }
    | Message input -> { state with Message = input }

let createName name =
    if Validation.name name then
        Ok name
    else
        Error [ MissingName ]

let createPhone phone =
    if Validation.phone phone then
        Ok phone
    else
        Error [ MissingPhone ]

let createAnimal animalName =
    if Validation.name animalName then
        Ok animalName
    else
        Error [ MissingAnimal ]

let createMessage message =
    if Validation.nonEmptyString message then
        Ok message
    else
        Error [ MissingMessage ]

let createContactResult (state: ContactFormDto) =
    let nameResult = createName state.Name
    let phoneResult = createPhone state.Phone
    let animalResult = createAnimal state.Animal

    let messageResult =
        createMessage state.Message

    ContactFormDto.create <!> nameResult
    <*> phoneResult
    <*> animalResult
    <*> messageResult

let forward _ = Router.navigate "home"

let makePipeline errorDispatcher =
    bind createContactResult
    >> map (tee forward)
    >> mapError errorDispatcher
