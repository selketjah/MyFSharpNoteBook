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
// -> commutative -> a x b == b x a
// -> associative -> (a + b) + c == a + (b + c)

// mapFold & mapFoldBack
[-10..10] |> List.mapFold (fun acc i -> i + 1, acc + i) 0
List.mapFoldBack (fun acc i -> i + 1, acc + i) [-10..10] 0
// -> mapFoldBack is right to left && same syntax as foldBack

//scan
[-10..10] |> List.scan (+) 0
// -> same as fold, but traces the steps and returns them

// sum, sumBy
[1..10] |> Seq.sum

let totalAge =
  [("Bob", 19); ("Kate", 18); ("Sarah", 17);("Mattis", 19); ("Wout", 18); ("Eme", 3)]
  |> Seq.sumBy snd

// unfold (?)
