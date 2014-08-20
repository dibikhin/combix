require 'pp'
require 'ruby-prof'

# for 'abc' combinations will be 
#	[['c'], ['b'], ['b', 'c'], ['a'], ['a', 'c'], ['a', 'b'], ['a', 'b', 'c']]
# due to bits of 1 to 7
#	001, 010, 011, 100, 101, 110, 111
# sequentially projected on 'abc'
def find_combinations(source, selection_size)
	RubyProf.start
	combinations = []
	len = 2 ** source.size - 1
	num_bin_hash = {}
	(1..len).each do |size_num|
		selection, counter = [], 0
		puts ("%0" + source.size.to_s + "b") % size_num
		bit_counter = 0
		(0..source.size).each do |bit_num|
			if size_num & ( 1 << counter ) > 0
				bit_counter += 1
				if bit_counter >= selection_size
					selection << source[counter]				
				end
			end
			counter += 1
		end
		combinations << selection
	end
	puts RubyProf::FlatPrinter.new(RubyProf.stop).print(STDOUT)
	combinations
end

source = (0..2).to_a
pp find_combinations(source, 2)