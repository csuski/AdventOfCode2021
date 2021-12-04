open System.IO

let input =
    File.ReadAllLines(@"input.txt") |> Seq.toList

let bits = input.Item(0).Length
let half = input.Length / 2

let countOfOnes = Array.create bits 0

for i in 0 .. input.Length - 1 do
    for j in 0 .. bits - 1 do
        if input[i][j] = '1' then
            Array.set countOfOnes j (countOfOnes[j] + 1)


let countOnes position (list: string list) =
    List.fold
        (fun acc (elem: string) ->
            match elem[position] with
            | '1' -> acc + 1
            | _ -> acc)
        0
        list


let countAllOnes (list: string list) =
    let len = list.Item(0).Length
    let count = Array.create len 0

    for j in 0 .. len - 1 do
        Array.set count j (countOnes j list)

    count



let gammaCheck n = n > half
let epsilonCheck n = n < half
// I guess we are assuming nothing is exactly equal


let gammaRate =
    List.fold
        (fun acc elem ->
            match gammaCheck elem with
            | true -> acc <<< 1 ||| 1
            | false -> acc <<< 1)
        0
        (Seq.toList countOfOnes)

let epsilonRate =
    List.fold
        (fun acc elem ->
            match epsilonCheck elem with
            | true -> acc <<< 1 ||| 1
            | false -> acc <<< 1)
        0
        (Seq.toList countOfOnes)

let result = gammaRate * epsilonRate

printf "Part 1 answer %A\r\n" result


let oxygenBitCriteria index numberOfOnes numberOfValues (value: string) =
    if numberOfOnes * 2 >= numberOfValues then
        (value[index]) = '1'
    else
        (value[index]) <> '1'

let co2BitCriteria index numberOfOnes numberOfValues (value: string) =
    if numberOfOnes * 2 < numberOfValues then
        (value[index]) = '1'
    else
        (value[index]) <> '1'

let rec criteriaFilter (list: string list) index criteria =
    match list.Length with
    | 0 -> list
    | 1 -> list
    | _ ->
        criteriaFilter
            (List.filter (criteria index ((countAllOnes list)[index]) list.Length) list)
            (index + 1) criteria

let toDecimal = List.fold (fun acc elem ->
    match elem = '1' with
    | true -> acc <<< 1 ||| 1
    | false -> acc <<< 1) 0


let oxygen = ((criteriaFilter input 0 oxygenBitCriteria)[0]) |> Seq.toList |> toDecimal
let co2 = ((criteriaFilter input 0 co2BitCriteria)[0]) |> Seq.toList |> toDecimal



printf "Part 2 answer %A\r\n" (oxygen * co2)
