let toTuple = function
    | [|a; b|] -> (a, int b)
    | _ -> failwith "unexpected array"

let parseLine (line:string) = line.Split " " |> toTuple

// read all lines of a file, convert to string list, map to int list
open System.IO
let input = File.ReadAllLines(@"input.txt") |> Seq.toList |> List.map parseLine

let (|Forward|Down|Up|) value =
    if "forward".Equals(value) then Forward
    elif "down".Equals(value) then Down
    elif "up".Equals(value) then Up
    else failwith "unexpected string"

let calcLocation list = List.fold (fun (horiz, depth) (move, amount) ->
    match move with 
    | Forward -> (horiz + amount, depth)
    | Down -> (horiz, depth + amount)
    | Up -> (horiz, depth - amount)) (0, 0) list

let (horiz, depth) = calcLocation input

let result = horiz * depth

printf "Part 1 answer %A\r\n" result


let calcLocation2 list = List.fold (fun (horiz, depth, aim) (move, amount) ->
    match move with 
    | Forward -> (horiz + amount, depth + aim * amount, aim)
    | Down -> (horiz, depth, aim + amount)
    | Up -> (horiz, depth, aim - amount)) (0, 0, 0) list

let (horiz2, depth2, aim) = calcLocation2 input

let result2 = horiz2 * depth2

printf "Part 2 answer %A\r\n" result2