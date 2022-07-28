module App.Dtos.CreateUserFormDto

type CreateUserFormDto =
    { Email: string
      Name: string
      Password: string
      PasswordConfirmation: string }
    static member create email name password passwordConfirmation =
        { Name = name
          Email = email
          Password = password
          PasswordConfirmation = passwordConfirmation }
