<Query Kind="FSharpProgram" />

let genCombs vals =
	let len = (pown 2 (Seq.length vals)) - 1
	let cnt = ((Seq.length vals) - 1)
	seq {
		for num in 0..len do
			let sel =
				seq {
					for ix in 0..cnt do 
			 			if num &&& (1 <<< ix) > 0 then 
							yield Seq.nth ix vals }
			yield sel }

let findCombs size vals =
	vals
	|> genCombs
	|> Seq.filter (fun x -> x |> Seq.length = size)
			
//findCombs 2 [1..3] |> Seq.length |> Dump
//findCombs 2 ['a'..'s'] |> Seq.length |> Dump // -> 171
findCombs 2 ['a'..'s'] |> Dump