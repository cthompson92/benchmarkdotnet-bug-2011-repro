let quicksort = function
    | [] -> []
    | x :: xs ->
        let smaller = List.filter ((>) x) xs
        let larger = List.filter ((<=) x) xs
        quicksort smaller @ [x] @ quicksort larger