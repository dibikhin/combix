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

source = '1234567890asdfgqwert'
puts find_combinations(source).inspect