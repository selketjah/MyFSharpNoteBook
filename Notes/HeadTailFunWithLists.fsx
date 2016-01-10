//session 1 - 8/1/2016
let myList = [ 1 .. 10 ]

let head::tail = myList

let analyze list =
  match list with
  | [] -> "empty"
  | head::tail -> "head + tail"

let rec sumOf total list =
  match list with
  | [] -> total
  | hd::tl ->
    let total' = total + hd
    sumOf total' tl

sumOf 0 myList

let rec take n list =
  if n = 1 then
    let hd::tl = list
    hd
  else
    let hd::tl = list
    take (n-1) tl

take 3 myList

//TODO: check out reduce vs fold
[1..3] |> Seq.reduce (*)
[] |> Seq.fold (*) 1

//head, last, nth
