namespace fsharp.console1

module Utils = 
    let rec quicksort = function
        | [] -> []
        | x :: xs ->
            let smaller = xs |> List.filter ((>) x) |> quicksort
            let larger = xs |> List.filter ((<=) x) |> quicksort
            smaller @ [x] @ larger

    let rec quicksort2 = function
        | [] -> []
        | [x] -> [x]
        | x :: xs ->
            let smaller = xs |> List.filter ((>) x) |> quicksort
            let larger = xs |> List.filter ((<=) x) |> quicksort
            smaller @ [x] @ larger

    let rec quicksortb1 = function
        | [] -> []
        | [x] -> [x]
        | x :: xs ->
            let l, r = List.partition ((>) x) xs
            let ls = quicksortb1 l
            let rs = quicksortb1 r
            ls @ (x::rs)

    let quicksortb2 list = 
        let rec loop list =
            match list with
            | [] -> []
            | [x] -> [x]
            | x :: xs ->
                let l, r = List.partition ((>) x) xs
                let ls = quicksortb1 l
                let rs = quicksortb1 r
                ls @ (x::rs)
        loop list

    let quicksortb3 list = 
        let rec loop list cont =
            match list with
            | [] -> cont []
            | [x] -> cont []
            | x :: xs ->
                let l, r = List.partition ((>) x) xs
                loop l (fun ls -> 
                loop r (fun rs -> 
                cont (ls @ (x::rs))))
        loop list (fun x -> x)

    type ContinuationBuilder() =
        member this.Bind (m, f) = fun c -> m (fun a -> f a c)
        member this.Return x = fun k -> k x

    let cont = ContinuationBuilder()

    let quicksortb4 list = 
        let rec loop list =
            cont {
                match list with
                | [] -> return []
                | x::xs -> 
                    let l, r = List.partition ((>) x) xs
                    let! ls = loop l
                    let! rs = loop r
                    return (ls @ (x::rs))
            }
        loop list (fun x -> x)

    let quicksortb5 list = 
        let rec loop list acc =
            match list with 
            | [] -> acc
            | x::[] -> x::acc
            | x::xs -> 
                let l, r = List.partition ((>) x) xs
                let rs = loop r acc
                loop l (x::xs)
        loop list []

    let quicksortb6 list = 
        let rec loop list acc cont =
            match list with 
            | [] -> cont acc
            | x::[] -> cont (x::acc)
            | x::xs -> 
                let l, r = List.partition ((>) x) xs
                loop r acc (fun rs -> 
                loop l (x :: rs) cont)
        loop list [] (fun x -> x)

    let quicksortb7 list = 
        let rec loop list acc =
            cont {
                match list with 
                | [] -> return acc
                | x::[] -> return x::acc
                | x::xs -> 
                    let l, r = List.partition ((>) x) xs
                    let! rs = loop r acc
                    let! s = loop l (x::rs)
                    return s
            }
        loop list [] (fun x -> x)
    
    let square x = x * x
    
    let squaref (x: float) = x * x
    let squaref32 (x: float32) = x * x
    
    // inline - static typed generic
    let inline sq x = x * x
