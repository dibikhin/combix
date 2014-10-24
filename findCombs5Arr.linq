<Query Kind="FSharpProgram" />

let findCombs size vals =
	let len = (pown 2 (Array.length vals)) - 1
	let cnt = ((Array.length vals) - 1)
	let bitVect = [| 0..cnt |]
	[| 0..len |]
	|> Array.map (fun num -> bitVect)
	|> Array.mapi (fun num ixarr -> 
		ixarr
		|> Array.fold (fun acc ix ->
			if num &&& (1 <<< ix) > 0 then Array.append acc [| vals.[ix] |]
			else Array.append acc [||]) [||])
	|> Array.filter (fun arr -> arr |> Array.length = size)

findCombs 2 [| 'a'..'s' |] |> Seq.length |> Dump

//findCombs 2 [| 'a'..'s' |] |> Dump