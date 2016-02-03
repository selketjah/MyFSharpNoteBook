['a' .. 'z']
// alphabet

['0' .. '9']
// numeric char list

['a' .. '9']
// empty list

['a' .. '$']
//empty list

['&' .. '$']
//empty list

[0x7A .. 0x7F]
//122 -> 127

[1 .. 50]
// numbers

[0 .. 5 .. 50]
// multiplication of 5

// -> ranges

[for nr in 1 .. 100 do
  yield nr]
//numbers

[for nr in 1 .. 100 -> nr]
// diff notation without yield, deprecated

[for nr in 1 .. 26 do
 for letter in 'a' .. 'z' do
  yield (nr, letter)
]

[for a in 1 .. 10 do
  yield! [a * 5]]
// multiplication of 5
// yield -> [[5]; [10]; [15]; [20]; [25]; [30]; [35]; [40]; [45]; [50]]
// yield! -> [5; 10; 15; 20; 25; 30; 35; 40; 45; 50]

// -> generator
