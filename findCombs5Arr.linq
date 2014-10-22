<Query Kind="FSharpProgram" />

let findCombs size vals =
	let len = (pown 2 (Array.length vals)) - 1
	let cnt = ((Array.length vals) - 1)
	let bitCount = [| 0..cnt |]
	[| 1..len |]
	|> Array.map (fun num ->
		let sel =
			bitCount
			//|> Array.filter (fun ix -> num &&& (1 <<< ix) > 0)			
		sel)
	|> Array.filter (fun arr -> arr |> Array.length = size)
	|> Array.mapi (fun num ixarr -> ixarr |> Array.fold (fun acc ix -> 
		  if num &&& (1 <<< ix) > 0 then Array.append acc [| vals.[ix] |];) [||])
	
	//|> Seq.map (fun ixarr -> ixarr |> Seq.fold (fun acc ix -> Seq.append acc (seq { yield vals.[ix] })) Seq.empty)

//findCombs 2 [| 'a'..'s' |] |> Seq.length |> Dump

findCombs 2 [| 'a'..'c' |] |> Dump