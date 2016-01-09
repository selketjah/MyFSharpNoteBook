// create (seq, list, array)
let listOneToFive = [1..5]
let listSixToTen = [6..10]

// append
let listTen =
  List.append listOneToFive listSixToTen
// -> appends listSixToTen to listOneToFive

let listTen2 =
  listOneToFive
  |> List.append listSixToTen
// -> appends listOneToFive to listSixToTen

// average/averageBy
let floatListTen =
  listOneToFive
  |> List.map float
let averageOfListTen = List.average floatListTen
// -> only works with floats

let averageOfListTen2 = List.averageBy (fun elem -> float elem) listOneToFive
// -> for converting to float first use averageBy

// cache


// cast (only seq)
let listIntStrings = [1.0; 2.0; 3.0]
let castedList =
  listIntStrings
  |> Seq.cast<int>
let sum =
  castedList
  |> Seq.fold (+) 0
// -> invalid example: only for loosely-typed seq casting to typed seq (use map here)

// choose
let tryFloat str =
    match System.Single.TryParse(str) with
    | true, i -> Some i
    | false, _ -> None
let floatStringList = ["1.0"; "2.0"; "sthsth"]
let parsedFloats =
  floatStringList
  |> Seq.choose tryFloat
  // -> same as filter but with option

// collect
let seqNr a = a
let listOfLists = [ listOneToFive; listSixToTen]
let flattenedList =
  listOfLists
  |> List.collect id
// -> id is the identity function and is the same as seqNr

// 
