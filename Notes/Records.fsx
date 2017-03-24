type Suit =
  | Spade
  | Heart
  | Diamond
  | Club

type Rank =
  | Seven
  | Eight
  | Nine
  | Jack
  | Queen
  | King
  | Ace
  | Ten

type Card = Card of Suit * Rank



(*let valueOf (card:Rank) =
  match card with
  | Seven
  | Eight
  | Nine -> 0
  | King -> 123
  | _ -> 0

let winnerOf (card1,card2) =
  match (card1,card2) with
  | (Seven,_) -> card2
*)



let sevenSpades = (Suit.Spade, Rank.Seven)
let jackHearts = (Suit.Heart, Rank.Jack)

open System

type Result =
    | Foo of int
    | Bar of string

let data = [ Foo(1); Bar("A"); Foo(2)]

let myArray = [|2;1;4;3|]

let arraySortD (x:'a array) = 
   for j = 2 to x.Length - 1 do
       let key = x.[j]
       let mutable i = j - 1
       while i > 0 && x.[i] > key do
           x.[i+1] <- x.[i]
           i <- i-1
           x.[i+1] <- key


printfn "%A" (arraySortD myArray)

