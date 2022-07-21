#r @"nuget: FParsec"

open FParsec

let test p str = 
    match run p str with
    | Success(result, _,_) -> printfn "Success: %A" result
    | Failure(error, _,_) -> printfn "Failure: %A" error

type MeasureFraction = Half | Quarter | Eighth | Sixteenth | Thirtysecondth
type Length = { fraction: MeasureFraction; extended: bool}
type Note = A | ASharp | B | C | CSharp | D | DSharp | E | F | FSharp | G | GSharp
type Octave = One | Two | Three
type Sound = Rest | Tone of note: Note * octave: Octave
type Token = { length: Length; sound: Sound}

let aspiration = "32.#d3"

let pmeasurefraction = 
    (stringReturn "2" Half)
    <|> (stringReturn "4" Quarter)
    <|> (stringReturn "8" Eighth)
    <|> (stringReturn "16" Sixteenth)
    <|> (stringReturn "32" Thirtysecondth)

let pextended = (stringReturn "." true) <|> (stringReturn "" false)

let plength =
    pipe2 pmeasurefraction pextended (fun t e -> { fraction = t; extended = e})

test plength "16"
test plength "32."
test plength aspiration
test plength "asdf"

let pdull = anyOf "be" |>> (function 
    | 'b' -> B
    | 'e' -> E
    | unknown -> sprintf "Unknown note %c" unknown |> failwith)

let psharp = (stringReturn "#" true) <|> (stringReturn "" false)

let pnoteorsharp = 
    pipe2 
        psharp
        (anyOf "acdfg")
        (fun isSharp note -> 
            match (isSharp, note) with
                (false, 'a') -> A
                | (true, 'a') -> ASharp
                | (false, 'c') -> C
                | (true, 'c') -> CSharp
                | (false, 'd') -> D
                | (true, 'd') -> DSharp
                | (false, 'f') -> F
                | (true, 'f') -> FSharp
                | (false, 'g') -> G
                | (true, 'g') -> GSharp
                | (_, unknown) -> sprintf "Unknown note %c" unknown |> failwith)

let pnote = pdull <|> pnoteorsharp    

test pnote aspiration
test pnote "a"
test pnote "#a"
test pnote "#b"
    
let poctave = 
    (stringReturn "1" One)
    <|> (stringReturn "2" Two)
    <|> (stringReturn "3" Three)

test poctave aspiration

let prest = (stringReturn "-" Rest)

let ptone = pipe2 pnote poctave (fun n o -> Tone(n, o))

let psound = prest <|> ptone
test psound "#d3"

let ptoken = pipe2 plength psound (fun l s -> {length = l; sound = s})

test ptoken aspiration

let pscore = sepBy ptoken (pstring " ")

test pscore "2- 16a1 16- 16a1 8a1 16- 4a2 16g2 16- 2g2 16- 4- 8- 16g2 16- 16g2 16- 16g2 8g2 16-"