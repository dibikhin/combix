require 'pp'
require 'ruby-prof'

def count_bits(number, pos_count)
	counter, bit_count = 0, 0
	(0..pos_count).each do # each bit
		bit_count += 1 if number & ( 1 << counter ) > 0
		counter += 1
	end
	bit_count
end

# for 'abc' combinations will be 
#	[['c'], ['b'], ['b', 'c'], ['a'], ['a', 'c'], ['a', 'b'], ['a', 'b', 'c']]
# due to bits of 1 to 7
#	001, 010, 011, 100, 101, 110, 111
# sequentially projected on 'abc'
def find_combinations(source, selection_size)
	RubyProf.start
	combinations = []
	len = 2 ** source.size - 1
	(1..len).each do |number| # each number 1..n
		selection, counter = [], 0
		#puts ("%0" + source.size.to_s + "b") % number
		(0..source.size).each do # each bit
			#if count_bits(number, source.size) == selection_size
				#p [number, counter]
				selection << source[counter] if number & ( 1 << counter ) > 0				
			#end
			counter += 1
		end
		combinations << selection if !selection.empty?
	end
	puts RubyProf::FlatPrinter.new(RubyProf.stop).print(STDOUT)
	combinations
end

#source = ('a'..'b').to_a
source = (1..17).to_a
find_combinations(source, 2)