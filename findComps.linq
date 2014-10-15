<Query Kind="FSharpProgram" />

open System.Linq
open Microsoft.FSharp.Linq

let extractVals key value fold acc seq =
    seq
	|> Seq.map (fun (key, seq) -> seq |> Seq.map value)
		
let genCombs vals =
	let len = (pown 2 (List.length vals)) - 1
	seq {
		for num in 0..len do
			for shift in 0..((List.length vals) - 1) do 
			 	if (num &&& (1 <<< shift)) > 0 then yield (num, vals.[shift]) } 

let findCombs vals =
	genCombs vals
	|> Seq.groupBy fst
	|> extractVals fst snd (fun acc el -> Seq.concat [acc; el]) Seq.empty
	
//findCombs [1..3] |> Dump
//findCombs ['a'..'c'] |> Seq.length |> Dump
findCombs ['a'..'c'] |> Dump