﻿namespace FSharp.Numerics

type IntegerZ5 =
    | Z5 of int
    member z.ToInt32() = 
        let (Z5 n) = z in n
    override z.ToString() = 
        sprintf "%d (mod 5)" (z.ToInt32())

    static member Create(n) = 
        let z5 = n % 5
        Z5(max ((z5 + 5) % 5) z5)

    static member (+) (Z5 a, Z5 b) = IntegerZ5.Create(a + b)
    static member (-) (Z5 a, Z5 b) = IntegerZ5.Create(a - b)
    static member (*) (Z5 a, Z5 b) = IntegerZ5.Create(a * b)
    static member Zero = Z5 0
    static member One = Z5 1

    // not sure if this is correct - mentioned in article but no example given
    static member op_Explicit (Z5 a): byte = byte a
    // int8 = sbyte, interchangeable
    static member op_Explicit (Z5 a): int8 = int8 a
    static member op_Explicit (Z5 a): int16 = int16 a
    static member op_Explicit (Z5 a): uint16 = uint16 a
    static member op_Explicit (Z5 a): int32 = int32 a
    static member op_Explicit (Z5 a): uint32 = uint32 a
    static member op_Explicit (Z5 a): int64 = int64 a
    static member op_Explicit (Z5 a): uint64 = uint64 a

[<AutoOpen>]
module IntegerZ5TopLevelOperations = 
    let inline z5 a = IntegerZ5.Create(int a)    

module NumericLiteralZ = 
    let FromZero () = Z5 0
    let FromOne () = Z5 1
    let FromInt16 a = IntegerZ5.Create(int a % 5)
    let FromInt32 a = IntegerZ5.Create(a % (int 5))
    let FromInt64 a = IntegerZ5.Create(int a % 5)
    let FromByte a = IntegerZ5.Create(int a % 5)