<Query Kind="FSharpProgram" />

//http://theburningmonk.com/2012/04/fsharp-solutions-to-google-codejam-2010-qualification-round-problems/
//http://theburningmonk.com/2012/04/f-solutions-to-google-codejam-2012-qualification-round-questions/
// http://www.fssnip.net/6m
//http://msdn.microsoft.com/ru-ru/vstudio/ee957404
//http://blogs.msdn.com/b/lukeh/archive/2007/03/19/using-linq-to-solve-puzzles.aspx

let findCombs size vals =
	let len = (pown 2 (Array.length vals)) - 1
	let cnt = ((Array.length vals) - 1)
	let bitCount = [| 0..cnt |]
	[| 1..len |]
	|> Array.map (fun num ->
		let sel =
			bitCount
			|> Array.filter (fun ix -> num &&& (1 <<< ix) > 0)			
		sel)
	|> Array.filter (fun arr -> arr |> Array.length = size)
	|> Array.map (fun ixarr -> ixarr |> Array.fold (fun acc ix -> Array.append acc [| vals.[ix] |]) [||])
	
	//|> Seq.map (fun ixarr -> ixarr |> Seq.fold (fun acc ix -> Seq.append acc (seq { yield vals.[ix] })) Seq.empty)

//findCombs 2 [| 'a'..'s' |] |> Seq.length |> Dump

findCombs 2 [| 'a'..'c' |] |> Dump