//fold & foldBack
[-10..10] |> List.fold (+) 0
List.foldBack (+) [-10..10] 0
// -> any reduce can be written as a fold
// -> foldBack right to left & diff syntax
[3] |> List.fold (+) 0
[] |> List.fold (+) 0

//reduce & reduceBack
[-10..10] |> List.reduce (+)
[-10..10] |> List.reduceBack (+)
// -> reduceBack right to left
[3] |> List.reduce (+)
[] |> List.reduce (+)

// -> error on empty list
// -> not every fold can be written as a recude

[1;2;3;4]
(1+2)+(3+4)=1+(2+3+4)
1+2 = 0 + 1 + 2

//+ on int is a monoid
//average on float is NOT a monoid
// -> commutative -> a x b == b x a
// -> associative -> (a + b) + c == a + (b + c)

let rng = System.Random ()
let xs = [ for i in 0 .. 99 -> rng.Next(0,10)]

// find all places where we have 3 numbers that are increasing
let increasing3 (xs:int[]) = xs.[0] < xs.[1] && xs.[1] < xs.[2]

xs |> Seq.windowed 3 |> Seq.filter increasing3

// http://fsharpforfunandprofit.com/posts/monoids-without-tears/

// mapFold & mapFoldBack
[-10..10] |> List.mapFold (fun acc i -> i + 1, acc + i) 0
List.mapFoldBack (fun acc i -> i + 1, acc + i) [-10..10] 0
// -> mapFoldBack is right to left && same syntax as foldBack

//scan
[-10..10] |> List.scan (+) 0
// -> same as fold, but traces the steps and returns them

// sum, sumBy
[-10..10] |> Seq.sum
[3] |> List.sum
//[] |> List.sum
// -> short for a reduce (+)
// -> shows error

let totalAge =
  [("Bob", 19); ("Kate", 18); ("Sarah", 17);("Mattis", 19); ("Wout", 18); ("Eme", 3)]
  |> Seq.sumBy snd

// unfold (?)
