// read all lines of a file, convert to string list, map to int list
open System.IO
let intList = File.ReadAllLines(@"input.txt") |> Seq.toList |> List.map int