<Query Kind="FSharpProgram" />

open System.Linq
open Microsoft.FSharp.Linq

type G = { Num: int; Val: char }

let findCombs vals =
	let len = (pown 2 (List.length vals)) - 1
	seq {
		for num in 0..len do
			for shift in 0..((List.length vals) - 1) do 
			 	if (num &&& (1 <<< shift)) > 0 then yield (num, vals.[shift]) } 
				//{ Num = num; Val = vals.[shift] } }
				 
	|> Seq.groupBy (fun x -> fst x )
	|> Seq.map (fun (k, v) -> v )//|> (fun (a, b) -> b))
	//|> Seq.concat
	
// findCombs [1..17] |> Dump
findCombs ['a'..'c'] |> Dump


//testQuery |> Dump

//let testQuery =
//	query {
//		for comb in findCombs ['a'..'c'] do
//		groupBy (fst(comb)) into g
//		select g
//	}