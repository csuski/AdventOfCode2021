let countIncrease (x, y) = match x < y with | true -> 1 | false -> 0

let rec countIncreases = function 
    | [] -> 0
    | _::[] -> 0
    | a::b::t -> countIncrease(a, b) + countIncreases(b::t)

// read all lines of a file, convert to string list, map to int list
open System.IO
let intList = File.ReadAllLines(@"input.txt") |> Seq.toList |> List.map int
 
let numberOfIncrease = intList |> countIncreases

printf "Part 1 answer %i\r\n" numberOfIncrease


let rec sumOfThree = function 
    | [] -> []
    | _::[] -> []
    | _::_::[] -> []
    | a::b::c::t -> (a+b+c)::sumOfThree(b::c::t)


let numberofThreeIncreases = intList |> sumOfThree |> countIncreases

printf "Part 2 answer %i\r\n" numberofThreeIncreases


