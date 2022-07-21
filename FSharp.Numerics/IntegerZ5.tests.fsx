#load "IntegerZ5.fs"
open FSharp.Numerics

fsi.AddPrinter(fun (z: IntegerZ5) -> z.ToString())

let a = 3Z
let b = 7Z
let x = IntegerZ5.Create(int 3.0)
let y = Z5 (int 3.0)

let z = int 3Z

a + b
b - a

a - b
b - a

a * b
b * a

List.sum [ z5 0; z5 1; z5 2; z5 3; z5 4 ]