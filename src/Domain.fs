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

type Animal =
    { Id: int
      Name: string
      Age: string
      Size: string
      Temper: string
      Location: string }
