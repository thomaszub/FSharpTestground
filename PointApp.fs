namespace FSharpTestground

type Point<'T> = { X: 'T; Y: 'T }

module Point =
    let inline moveBy (dx: 'T) (dy: 'T) (p: Point<'T>) = { X = p.X + dx; Y = p.Y + dy }

module PointApp =
    let execute =
        let pointFloat = { X = 0.5; Y = 0.2 }
        let movedPointFloat = Point.moveBy 0.1 0.4 pointFloat

        let pointInt = { X = 5; Y = 2 }
        let movedPointInt = Point.moveBy 1 4 pointInt

        printfn $"{movedPointFloat}"
        printfn $"{movedPointInt}"
