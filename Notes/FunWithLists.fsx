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
let listOfLists = [ listOneToFive; listSixToTen]
let flattenedList =
  listOfLists
  |> List.collect id
// -> id is the identity function and as (fun x -> x) or let id a = a

// compareWith
let firstList =  [1;1;1;1;1;1] //[1;1;2;1;1;1] -> 1
let secondList =  [1;1;1;1;1;1] //[1;1;2;1;1;1] -> -1
let shouldBeZero =
  (firstList, secondList)
  ||> List.compareWith (fun elem1 elem2 -> elem1.CompareTo(elem2))
// -> 0 if equal - -1 if second list is shorter or 1 if first list is shorter
// -> shorter explained: it cuts off the list at first difference
// [1;1;2;1;1;1] -> [1;1]

// concat
let listOfNames1 = ["Emily"; "Bob"; "Kate"; "Sarah"]
let listOfNames2 =  ["Frank"; "Thomas"; "Lien"]
let listOfNames3 =  ["Mattis"; "Wout"; "Eme"]
let listOfNames4 =  ["Mattis"; "Wout"; "Eme"; "Emily"]
let concatedListOfNames =
  [listOfNames1; listOfNames2; listOfNames3; listOfNames4]
  |> Seq.concat
// -> same as append but number of lists > 2

// countBy
let startsWithSList =
  concatedListOfNames
  |> Seq.countBy (fun x -> if x.StartsWith("S") then "wOOt" else "boehhh")
// -> returns seq [("boehhh", 11); ("wOOt", 1)]
// -> general seq[("else", numberOfTimes); ("then", numberOfTimes)]
let groupByAge =
  [("Bob", 19); ("Kate", 18); ("Sarah", 17);("Mattis", 19); ("Wout", 18); ("Eme", 3)]
  |> Seq.countBy snd
// -> can be used with fst & snd if you have list of key-value pairs
// -> seq [(19, 2); (18, 2); (17, 1); (3, 1)]

// delay

// distinct
let distinctNameList =
  concatedListOfNames
  |> Seq.toList
  |> List.distinct

// distinctBy
let distinctByNameList =
   ["Emily"; "Bob"; "Kate"; "Sarah"; "Eme"; "Emily"]
  |> Seq.toList
  |> List.distinctBy (fun name -> name.StartsWith("E"))
