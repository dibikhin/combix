<Query Kind="Statements" />

var n = 2;
var len = 3;
var stack = new int[len];

var lev = 0;
stack[0] = -1;

for (;;) {
	for (lev++; lev < n; lev++) {
		stack[lev+1] = stack[lev]+1;
	}
	//if(stack.Where(x => x > 0).Count() == n) 
	stack.Dump();
	do {
		if (lev == 0) goto Done;
		stack[lev--]++;
	} while (stack[lev+1]+n == len+lev+1);
}
Done:
   ;