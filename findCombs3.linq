<Query Kind="FSharpProgram" />

let findCombs size vals =
	let len = (pown 2 (Seq.length vals)) - 1
	let cnt = ((Seq.length vals) - 1)
	let seqcnt = seq { 0..cnt } 
	seq { 1..len }
	|> Seq.map (fun num ->
		let sel =
			seqcnt
			|> Seq.filter (fun ix -> num &&& (1 <<< ix) > 0)
			|> Seq.map (fun ixn -> Seq.nth ixn vals)
		sel)
		|> Seq.filter (fun x -> x |> Seq.length = size)

//findCombs 2 [1..3] |> Seq.length |> Dump
//findCombs 2 [|'a'..'s'|] |> Seq.length |> Dump // -> 171

findCombs 2 ['a'..'s'] |> Seq.length |> Dump

//findCombs 2 ['a'..'c'] |> Dump

//001
//010
//011
//100
//101
//110
//111