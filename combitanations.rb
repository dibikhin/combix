require 'pp'
require 'ruby-prof'

# for 'abc' combinations will be 
#	[['c'], ['b'], ['b', 'c'], ['a'], ['a', 'c'], ['a', 'b'], ['a', 'b', 'c']]
# due to bits of 1 to 7
#	001, 010, 011, 100, 101, 110, 111
# sequentially projected on 'abc'
def find_combinations(source)
	RubyProf.start
	combs = []
	len = 2 ** source.size - 1
	num_bin_hash = {}
	(1..len).each do |size_num|
		comb, counter = [], 0
	    # size_num_str = ("%0" + source.size.to_s + "b") % size_num
		# puts size_num, size_num_str
		# size_num_str.each_char do |bit|
			# comb << source[counter] if bit == '1'
			# counter += 1
		# end
		(0..source.size).each do |bit_num| 
			comb << source[counter] if size_num & ( 1 << counter ) > 0
			counter += 1 
		end
		combs << comb
	end
	puts RubyProf::FlatPrinter.new(RubyProf.stop).print(STDOUT)
	combs
end

source = (0..16).to_a
find_combinations(source)