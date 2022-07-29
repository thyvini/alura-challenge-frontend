module App.Dtos.ProfileFormDto

type ProfileFormDto =
    { Email: string
      Name: string
      Image: string option
      Phone: string option
      City: string option
      Bio: string option }
    static member create email name image phone city bio =
        { Email = email
          Name = name
          Image = image
          Phone = phone
          City = city
          Bio = bio }
