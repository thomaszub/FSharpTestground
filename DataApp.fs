namespace FSharpTestground

open System
open System.IO

module DataApp =
    let execute =
        let users =
            "/Users/thomaszub/projects/dotnet/FSharpTestground/data.csv"
            |> File.ReadAllLines
            |> Array.skip 1
            |> Array.choose
                (fun l ->
                    try
                        Some(User.fromString l)
                    with
                    | :? FormatException as e ->
                        printfn $"Error: {e.Message}"
                        None)
            |> Array.sortByDescending (fun u -> u.Score)

        let avgScores =
            users
            |> Array.choose
                (fun u ->
                    match u.Score with
                    | Empty -> None
                    | Value v -> Some v)
            |> Array.map float
            |> Array.average

        users
        |> Array.map (fun u -> printfn $"{u}")
        |> ignore

        printfn $"{avgScores}"
