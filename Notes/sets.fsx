(*
Introduction to sets and maps
*)

let proverb = "qui aime bien chatie bien"
let proverb2 = "le mieux est l'ennemi du bien."

let array = proverb.Split ' '

let words = set array

// set is a 'constructor' function
let xs = set [1;2;1;2;3;1;2;3;4]

xs |> Set.count

Set.intersect (set [1..5]) (set [3..10])
Set.union (set [1..5]) (set [3..10])

[ 1 .. 10 ]
|> List.map (fun x -> set [ x .. x + 2 ])
|> Set.unionMany

let europeanCities = set [ "Paris"; "London"; "Brussels"; "Berlin" ]

let answer = "Paris,London,NewYork,Brussels"
let isCorrect (answer:string) =
  answer.Split ','
  |> Set.ofArray
  |> Set.intersect europeanCities
  |> Set.count
  |> fun count -> count >= 3

isCorrect answer

let set1 = set [ 1 .. 5 ]

set1 |> Set.add 42 

// Map ~ dictionary

let m = 
  [ 1, "A"
    2, "B"
  ]  |> Map.ofList

m |> Map.tryFind 42

