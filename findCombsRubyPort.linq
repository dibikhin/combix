<Query Kind="Program" />

void Main()
{
	//Go(new [] { 1, 2, 3 }).Dump();
	Go(Enumerable.Range(1, 100).ToArray()).Count().Dump();
}

// Define other methods and classes here
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

private static int[] Extract(int[] arr, int[] ind){
	return arr.Zip(ind, (label, value) => arr[value]).ToArray();
}