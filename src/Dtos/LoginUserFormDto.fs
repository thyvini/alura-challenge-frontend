module App.Dtos.LoginUserFormDto

type LoginUserFormDto =
    { Email: string
      Password: string }
    static member create email password = { Email = email; Password = password }
