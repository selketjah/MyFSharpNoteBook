type Color =
  | Red
  | Green
  | Blue

let nameOf color =
  match color with
  | Red -> "RED"
  | Green -> "GREEN"
  | Blue -> "BLUE"

nameOf Blue

let divide x y =
  if y = 0.0 then failwith "problem"
  else x / y

type Result =
  | Success of float
  | Failure of string

let betterdivide x y =
    if y = 0.0
    then Failure("Problem")
    else Success(x / y)

let testDivide x y =
  let z = betterdivide x y
  match z with
  | Failure(msg) -> msg
  | Success(value) -> sprintf "%f" value

type Tree =
  | Leaf of int
  | Branch of (Tree * Tree)

let tree =
  Branch(
      Leaf(1),
      Branch(
        Leaf(2),Leaf(3)))

let rec sum acc tree =
  match tree with
  | Leaf(x) -> acc + x
  | Branch(left,right) ->
    let sumleft = sum acc left
    sum sumleft right

sum 0 tree

let foo = 1,2

type MyTuple = int * float * string
