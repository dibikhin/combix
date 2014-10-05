<Query Kind="FSharpProgram" />

let findCombs vals =
	let len = (pown 2 (List.length vals)) - 1
	
	len

findCombs [1..3] |> Dump