<Query Kind="FSharpProgram" />

let findCombs vals =
	let len = (pown 2 (List.length vals)) - 1
	seq {
		for num in 0..len do
			for shift in 0..((List.length vals) - 1) do 
			 	if (num &&& (1 <<< shift)) > 0 then yield (num, vals.[shift]) } 
	//|> Seq.groupBy fst
	
findCombs [1..17] |> Dump