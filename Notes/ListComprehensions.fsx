['a' .. 'z']
// alphabet

['0' .. '9']
// numeric char list

[ '$' .. '&' ]
// char list = ['$'; '%'; '&']

['9' .. 'a']
// order from ascii table 9 -> a

['$' .. 'a']
// order from ascii table $ -> a

[ 1 .. 2 .. 10]
[ 10 .. -2 .. 1]
char 10
[for c in 10..20 -> char c]

int 'A'

[ for c in (int '$') .. (int '&')  -> char c ]

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
  yield [ for j in 1 .. 5 -> a * (5 * j)]]

[for a in 1 .. 10 do
  yield! [ for j in 1 .. 5 -> a * (5 * j)]]
// multiplication of 5
// yield -> [[5]; [10]; [15]; [20]; [25]; [30]; [35]; [40]; [45]; [50]]
// yield! -> [5; 10; 15; 20; 25; 30; 35; 40; 45; 50]

// -> generator

open System.IO

let root = __SOURCE_DIRECTORY__
Directory.EnumerateDirectories(root) |> Seq.toList

[ for dir in Directory.EnumerateDirectories(root) do
    yield! Directory.EnumerateFiles(dir)
]
