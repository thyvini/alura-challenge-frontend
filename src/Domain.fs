module App.Domain

type User =
    { Name: string
      Email: string
      PasswordHash: string }

type UserDetails =
    { Email: string
      Image: string option
      Phone: string option
      City: string option
      Bio: string option }