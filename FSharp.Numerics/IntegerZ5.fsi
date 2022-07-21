



namespace FSharp.Numerics
    
    type IntegerZ5 =
        | Z5 of int
        
        static member ( * ) : IntegerZ5 * IntegerZ5 -> IntegerZ5
        
        static member (+) : IntegerZ5 * IntegerZ5 -> IntegerZ5
        
        static member (-) : IntegerZ5 * IntegerZ5 -> IntegerZ5
        
        static member Create: n: int -> IntegerZ5
        
        static member op_Explicit: IntegerZ5 -> uint64
        
        static member op_Explicit: IntegerZ5 -> int64
        
        static member op_Explicit: IntegerZ5 -> uint32
        
        static member op_Explicit: IntegerZ5 -> int32
        
        static member op_Explicit: IntegerZ5 -> uint16
        
        static member op_Explicit: IntegerZ5 -> int16
        
        static member op_Explicit: IntegerZ5 -> int8
        
        static member op_Explicit: IntegerZ5 -> byte
        
        member ToInt32: unit -> int
        
        override ToString: unit -> string
        
        static member One: IntegerZ5
        
        static member Zero: IntegerZ5
    
    module IntegerZ5TopLevelOperations =
        
        val inline z5:
          a:  ^a -> IntegerZ5 when  ^a: (static member op_Explicit:  ^a -> int)
    
    module NumericLiteralZ =
        
        val FromZero: unit -> IntegerZ5
        
        val FromOne: unit -> IntegerZ5
        
        val FromInt16: a: int -> IntegerZ5
        
        val FromInt32: a: int -> IntegerZ5
        
        val FromInt64: a: int -> IntegerZ5
        
        val FromByte: a: int -> IntegerZ5

