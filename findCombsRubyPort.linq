<Query Kind="Program" />

void Main()
{
	//Go(new [] { 1, 2, 3 }).Dump();
	Go(Enumerable.Range(1, 3).ToArray()).ToArray().Dump();
}

// Ruby 2.0.0 combinations port
private static IEnumerable<int[]> Go(int[] arr){
	var n = 2;
	var len = arr.Length;
	var stack = new int[len];
	
	var lev = 0;
	stack[0] = -1;
	
	for (;;) {
		for (lev++; lev < n; lev++) {
			stack[lev+1] = stack[lev]+1;
		}
		
		yield return Extract(arr, stack.Where(x => x >= 0).ToArray());
		
		do {
			if (lev == 0) goto Done;
			stack[lev--]++;
		} while (stack[lev+1]+n == len+lev+1);
	}
	Done:
	   ;
}

private static int[] Extract(int[] arr, int[] indList){
	return arr.Zip(indList, (ix, value) => arr[value]).ToArray();
}