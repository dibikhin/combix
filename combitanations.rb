require 'pp'
require 'ruby-prof'

# for 'abc' combinations will be 
#	[['c'], ['b'], ['b', 'c'], ['a'], ['a', 'c'], ['a', 'b'], ['a', 'b', 'c']]
# due to bits of 1 to 7
#	001, 010, 011, 100, 101, 110, 111
# sequentially projected on 'abc'
def find_combinations(source, selection_size)
	#RubyProf.start
	combinations = []
	len = 2 ** source.size - 1
	(1..len).each do |number| # each number 1..n
		selection = []
		(0..source.size).each do |ix| # each bit
			if selection.size <= selection_size
				selection << source[ix] if number & ( 1 << ix ) > 0
			end
		end
		combinations << selection if !selection.empty? && selection.size == selection_size
	end
	#puts RubyProf::FlatPrinter.new(RubyProf.stop).print(STDOUT)
	combinations
end

source = ('a'..'s').to_a
#source = (1..17).to_a
t = Time.now
p find_combinations(source, 2).size
p Time.now - t