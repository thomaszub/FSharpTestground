namespace FSharpTestground

type Score =
    | Empty
    | Value of int

type User =
    { Surname: string
      Name: string
      Score: Score }

[<RequireQualifiedAccess>]
module User =
    let private parseScore s =
        match s with
        | "" -> Empty
        | _ -> Value(int s)

    let private parseName (s: string) =
        match s.Split(',') with
        | [| surname; name |] ->
            {| Surname = surname.Trim()
               Name = name.Trim() |}
        | [| name |] ->
            {| Surname = "(unknown)"
               Name = name.Trim() |}
        | _ ->
            sprintf $"Invalid name format: {s}"
            |> System.FormatException
            |> raise

    let getUser name score =
        let fullname = parseName name
        let score = parseScore score

        { Surname = fullname.Surname
          Name = fullname.Name
          Score = score }

    let fromString (s: string) =
        s.Split(';')
        |> (fun elems ->
            match elems with
            | [| name; score |] -> getUser name score
            | _ ->
                sprintf $"Invalid format: {s}"
                |> System.FormatException
                |> raise)
