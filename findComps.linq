<Query Kind="FSharpProgram" />

let findCombs vals =
	let len = (pown 2 (List.length vals)) - 1
	seq {
		for num in 0..(len - 1) do
			for shift in 0..((List.length vals) - 1) do 
			 	if (num &&& (1 <<< shift)) > 0 then yield vals.[num] }

findCombs [1..3] |> Dump