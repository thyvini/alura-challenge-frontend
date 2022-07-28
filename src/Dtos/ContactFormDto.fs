module App.Dtos.ContactFormDto

type ContactFormDto =
    { Name: string
      Phone: string
      Animal: string
      Message: string }
    static member create name phone animal message =
        { Name = name
          Phone = phone
          Animal = animal
          Message = message }
