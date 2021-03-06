// http://fsharpforfunandprofit.com/posts/list-module-functions/
// https://msdn.microsoft.com/en-us/library/ee353635.aspx

// init /initInifite
let listOneToFive = List.init 5 (fun i -> int (i+1))
let listSixToTen = List.init 5 (fun i -> int (i+6))
let infiniteList = Seq.initInfinite (fun i -> int i)

// append (@) vs concat
let listTen =
  (listOneToFive, listSixToTen)
  ||> List.append
// -> appends listSixToTen to listOneToFive
// -> notice the two | that are being used

listOneToFive @ listSixToTen
// -> same as append

let listTen2 =
  listOneToFive
  |> List.append listSixToTen
// -> appends listOneToFive to listSixToTen

let listOfNames1 = ["Emily"; "Bob"; "Kate"; "Sarah"]
let listOfNames2 =  ["Frank"; "Thomas"; "Lien"]
let listOfNames3 =  ["Mattis"; "Wout"; "Eme"]
let listOfNames4 =  ["Mattis"; "Wout"; "Eme"; "Emily"]
let listOfNames5 =  ["Anna"; "Sanne"; "Magda"; "Rose"]
let concatedListOfNames =
  [listOfNames1; listOfNames2; listOfNames3; listOfNames4]
  |> Seq.concat
// -> same as append but number of lists > 2

// zip vs zip3 vs unzip
let zippedList =
  (listOfNames1, listOfNames4)
  ||> List.zip
// -> lists need to be same length
// -> creates pair instead of appending

let threeZippedList =
  (listOfNames1, listOfNames4, listOfNames5)
  |||> List.zip3
// -> creates tuples of three
// -> notice the three | that are being used

let unzippedList =
  [("Emily", "Mattis"); ("Bob", "Wout"); ("Kate", "Eme"); ("Sarah", "Emily")]
  |> List.unzip
// -> returns two lists

// average/averageBy with map
let floatListTen =
  listOneToFive
  |> List.map float
let averageOfListTen = List.average floatListTen
// -> only works with floats
// -> includes example use of function map

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

// countBy & groupBy
let namesThatStartWithS =
  ["Emily"; "Bob"; "Kate"; "Sarah"]
  |> Seq.groupBy (fun x -> if x.StartsWith("S") then "wOOt" else "boehhh")
// -> [("boehhh", seq ["Emily"; "Bob"; "Kate"]);
//     ("wOOt", seq ["Sarah"])]
// -> general seq[("else", list); ("then", list)]

let numberOfNamesWithStartVowelS =
  ["Emily"; "Bob"; "Kate"; "Sarah"]
  |> Seq.countBy (fun x -> if x.StartsWith("S") then "wOOt" else "boehhh")
// -> returns seq [("boehhh", 3); ("wOOt", 1)]
// -> general seq[("else", numberOfTimes); ("then", numberOfTimes)]

let numberOfPeopleWithSameAge =
  [("Bob", 19); ("Kate", 18); ("Sarah", 17);("Mattis", 19); ("Wout", 18); ("Eme", 3)]
  |> Seq.countBy snd
// -> can be used with fst & snd if you have list of key-value pairs
// -> seq [(19, 2); (18, 2); (17, 1); (3, 1)]

let peopleGroupedByAge =
  [("Bob", 19); ("Kate", 18); ("Sarah", 17);("Mattis", 19); ("Wout", 18); ("Eme", 3)]
  |> Seq.groupBy snd
// -> [(19, seq [("Bob", 19); ("Mattis", 19)]);
//     (18, seq [("Kate", 18); ("Wout", 18)]);
//     (17, seq [("Sarah", 17)]);
//     (3, seq [("Eme", 3)])]

// delay

// distinct
let distinctNameList =
  concatedListOfNames
  |> Seq.toList
  |> List.distinct

// distinctBy
let distinctByNameList =
   ["Emily"; "Bob"; "Kate"; "Sarah"; "Eme"; "Emily"]
  |> List.distinctBy (fun name -> name.StartsWith("E"))
// -> result is ["Emily"; "Bob"] because Emily is true and Bob is false
// -> check out filter

// empty
let emptyStringList = Seq.empty<string>

// exactlyOne vs singleton
let emily =
  ["Emily"]
  |> List.exactlyOne
// -> exactlyOne returns the only value in the list
// -> emily : string = "Emily"

let eme =
  "Eme"
  |> List.singleton
// -> singleton creates a list with one value
// -> string list = ["Eme"]

// exists vs forall
let containsTwo =
  [1;1;1;2;1;1]
  |> Seq.exists (fun nr -> nr = 2)
// -> is there an element in the list that satisfies this condition?
// -> true

let areAllTwo =
  [1;1;1;2;1;1]
  |> Seq.forall (fun nr -> nr = 2)
// do all elements in the list satisfy this condition?
// -> false

// exists2 vs forall2
let haveSameElement =
  ([1;1;1;2;1;1], [1;1;1;1;1;1])
  ||> Seq.exists2 (fun x y -> x = y)
// is there an element in the first list the same (with same index) as an element in the second list
// -> true

let areTheSameList =
  ([1;1;1;2;1;1], [1;1;1;1;1;1])
  ||> Seq.forall2 (fun x y -> x = y)
// are these two lists the same?
// -> false

// filter vs where vs find vs tryFind vs findIndex vs tryFindIndex
let namesThatStartWithE =
  ["Bob"; "Kate"; "Sarah"; "Eme"; "Emily"]
  |> List.filter (fun name -> name.StartsWith("E"))
// -> returns ALL elements that satisfies the condition

let namesThatStartWithB =
  ["Bob"; "Kate"; "Sarah"; "Eme"; "Emily"]
  |> List.where (fun name -> name.StartsWith("B"))
// -> returns ALL elements that satisfies the condition
// -> same as filter

let firstNameWithE =
  ["Bob"; "Kate"; "Sarah"; "Eme"; "Emily"]
  |> List.find (fun name -> name.StartsWith("E"))
// -> will return first element that satisfies the condition

let firstNameWithF =
  ["Bob"; "Kate"; "Sarah"; "Eme"; "Emily"]
  |> List.tryFind (fun name -> name.StartsWith("F"))
// -> returns some (first element) if condition was satisfies or none

let firstNameIndexWithE =
  ["Bob"; "Kate"; "Sarah"; "Eme"; "Emily"]
  |> List.findIndex (fun name -> name.StartsWith("E"))
// -> will return the index of the first element that satisfies the condition

let firstNameIndexWithF =
  ["Bob"; "Kate"; "Sarah"; "Eme"; "Emily"]
  |> List.tryFindIndex (fun name -> name.StartsWith("F"))
// -> will return some (index) of the first element that satisfies the condition or none

// choose vs pick vs tryPick
let tryFloat str =
    match System.Single.TryParse(str) with
    | true, i -> Some i
    | false, _ -> None
let floatStringList = ["sthsth"; "1.0"; "2.0"]
let parsedFloats =
  floatStringList
  |> Seq.choose tryFloat
// -> returns all elements that can be parsed as a float
// -> same as filter but with option

let parsedFloatsWithPick =
  floatStringList
  |> List.pick tryFloat
// -> returns the first element that can be parsed as a float
// -> same as find but with option

let possibleParsedFloat =
  ["sthsth"; "f"; "a"]
  |> List.tryPick tryFloat
// -> returns some (first element) or none
// -> same as tryFind

// isEmpty
let hasItems =
  listOneToFive
  |> List.isEmpty

// iter vs iter2 vs iteri
let printList =
  listOneToFive
  |> List.iter (fun i -> printf "%d;" i)

let printListWithIndex =
    listOneToFive
    |> List.iteri (fun nr -> printf "index: %d - nr: %d;" nr)

let printTwoListsSimultaneous =
  (listOneToFive,listSixToTen)
  ||> List.iter2 (fun a b -> printf "first list: %d second list: %d;" a b)

let printTwoListsWithIndexSimultaneous =
  (listOneToFive,listSixToTen)
  ||> List.iteri2 (fun a b -> printf "index: %d - first list: %d - second list: %d;" a b)

// length
let lengthOfList =
  listOneToFive
  |> List.length

// map, mapi
let spanishWord word =
  word + "os"

let spanishNames =
  ["Bob"; "Kate"; "Sarah"; "Eme"; "Emily"]
  |> List.map spanishWord

let spanishNamesWithIndex =
    ["Bob"; "Kate"; "Sarah"; "Eme"; "Emily"]
    |> List.map spanishWord
    |> List.mapi (fun x -> printf "index: %d - spanish name: %s;" x)

// map2, mapi2
let coupleNameWithAge =
  (["Bob"; "Kate"; "Sarah"; "Eme"; "Emily"], [18; 16; 42; 4; 7])
  ||> List.map2 (fun name age -> (name, age))

let printNameAndAge =
  (["Bob"; "Kate"; "Sarah"; "Eme"; "Emily"], [18; 16; 42; 4; 7])
  ||> List.mapi2 (fun name age -> printf "index: %d - name: %s - age: %i;" name age)

// max, min, maxBy, minBy
let lastAlphabeticalPerson =
  [("Bob", 19); ("Kate", 18); ("Sarah", 17); ("Anna", 19); ("Wout", 18); ("Eme", 3)]
  |> List.max

let oldestPerson =
  [("Bob", 19); ("Kate", 18); ("Sarah", 17); ("Anna", 19); ("Wout", 18); ("Eme", 3)]
  |> List.maxBy snd
// -> returns ("Bob", 19) first element of reduced list with the highest age

let firstAlphabeticalPerson =
  [("Bob", 19); ("Kate", 18); ("Sarah", 17); ("Anna", 19); ("Wout", 18); ("Eme", 3)]
  |> List.min

let youngestPerson =
  [("Bob", 19); ("Kate", 18); ("Sarah", 17); ("Anna", 19); ("Wout", 18); ("Eme", 3)]
  |> List.minBy snd

// pairwise, windowed

// readonly

//sort, sortBy
let sortedByName =
  [("Bob", 19); ("Kate", 18); ("Sarah", 17); ("Anna", 19); ("Wout", 18); ("Eme", 3)]
  |> List.sort

let sortedByAge =
  [("Bob", 19); ("Kate", 18); ("Sarah", 17); ("Anna", 19); ("Wout", 18); ("Eme", 3)]
  |> List.sortBy snd
// -> result is [("Eme", 3); ("Sarah", 17); ("Kate", 18); ("Wout", 18); ("Bob", 19);
// -> ("Anna", 19)] because Bob is first in the list

// skip, take, truncate
let skipThree =
  sortedByName
  |> List.skip 3
// -> last three elements of the list (skips the first three elements)

let takeThree =
  sortedByName
  |> List.take 3
// -> first three elements of the list (takes only the first three elements)

let takeSeven =
  sortedByName
  |> List.take 7
// -> this gives you an exception because the list is only 6 long

let firstSevenElements =
  sortedByName
  |> List.truncate 7
// -> in contradiction with take this will not crash but return the entire list

// skipWhile, takeWhile
let peopleOlderThanSeventeen =
  sortedByAge
  |> List.skipWhile (fun (a, b) -> b <= 17)
// -> same as skip but with condition instead

let peopleYoungerThanEighteen =
  sortedByAge
  |> List.takeWhile (fun (a, b) -> b <= 17)
// same as take but with condition instead
