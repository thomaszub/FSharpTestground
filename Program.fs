open System
open System.IO
open FSharpTestground

[<EntryPoint>]
let main argv =
    DataApp.execute
    PointApp.execute
    0
