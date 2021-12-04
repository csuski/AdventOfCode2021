

open System.IO
let input = File.ReadAllLines(@"test.txt") |> Seq.toList

let bits = input.Item(0).Length;
let half = input.Length / 2;


let countOfOnes = Array.create bits 0

for i in 0 .. input.Length - 1 do
    for j in 0 .. bits - 1 do
        if input[i][j] = '1' then Array.set countOfOnes j (countOfOnes[j] + 1)



let gammaCheck n = n > half
let epsilonCheck n = n < half
// I guess we are assuming nothing is exactly equal


let gammaRate = List.fold (fun acc elem -> 
    match gammaCheck elem with
    | true -> acc <<< 1 ||| 1
    | false -> acc <<< 1) 0 (Seq.toList countOfOnes)

let epsilonRate = List.fold (fun acc elem -> 
    match epsilonCheck elem with
    | true -> acc <<< 1 ||| 1
    | false -> acc <<< 1) 0 (Seq.toList countOfOnes)

let result = gammaRate * epsilonRate

printf "Part 1 answer %A\r\n" result


let oxygenBitCriteria index (value:string) = 
    if gammaCheck countOfOnes[index] then value[index] = '1'
    else value[index] <> '1'

let rec oxygenFilter (list:string list) index = 
    match list.Length with 
    | 0 -> list
    | 1 -> list
    | _ -> oxygenFilter (List.filter (oxygenBitCriteria index) list) (index + 1)

    //if list.length = 1 then list
    //else List.filter (oxygenBitCriteria index) list

let oxygenBinary = oxygenFilter input 0

printf "Part 2 answer %A\r\n" oxygenBinary