
type Square = { value:string; column:int; row:int; draw:int }

type Board = { squares:List<Square>}





open System.IO
let input = File.ReadAllLines(@"input.txt")



let numbersDrawn = input[0].Split ',' |> Seq.toList
let boardsInput = input[1..]


let splitSpace (row:string) = row.Split ' '


// while readline !+ null
// read f lines



let result = 0

printf "Part 1 answer %A\r\n" result