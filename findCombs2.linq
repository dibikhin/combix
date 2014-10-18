<Query Kind="FSharpProgram" />

let extractVals key value fold acc seq =
    seq
	|> Seq.map (fun (key, seq) -> seq |> Seq.map value)
		
let genCombs vals =
	let len = (pown 2 (List.length vals)) - 1
	seq {
		for num in 0..len do
			for ix in 0..((List.length vals) - 1) do 
			 	if num &&& (1 <<< ix) > 0 then yield (num, vals.[ix]) } 

let findCombs n vals =
	query {
    	for tpl in (genCombs(vals)) do
    	groupBy (fst(tpl)) into g
		where (g.Count() = n) 
    	select (g.Key, g)
    }
	|> extractVals fst snd (fun acc el -> Seq.concat [acc; el]) Seq.empty
	
//findCombs [1..3] |> Dump

findCombs 2 ['a'..'c'] |> Dump

if num &&& (1 <<< ix) > 0 then yield (num, vals.[ix], num &&& (1 <<< ix), ix) } 