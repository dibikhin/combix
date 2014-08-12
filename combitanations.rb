# for 'abc' combinations will be 
#	[['c'], ['b'], ['b', 'c'], ['a'], ['a', 'c'], ['a', 'b'], ['a', 'b', 'c']]
# due to bits of 1 to 7
#	001, 010, 011, 100, 101, 110, 111
# sequentially projected on 'abc'
def find_combinations(str)
	combs = []
	len = 2 ** str.size - 1
	(1..len).each do |size_num|
		comb, counter = [], 0
		size_num_str = ("%0" + str.size.to_s + "b") % size_num
		size_num_str.each_char do |bit|
			comb << str[counter] if bit == '1'
			counter += 1
		end
		combs << comb
	end
	combs
end

source = 'abc'
puts find_combinations(source).inspect