type Suit =
  | Spade
  | Heart
  | Diamond
  | Club

type Rank =
  | Seven
  | Eight
  | Nine
  | Jack of int
  | Queen of int
  | King of int
  | Ace of int
  | Ten of int

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

type Card = Card of Suit * Rank

let sevenSpades = (Suit.Spade, Rank.Seven)
let jackHearts = (Suit.Heart, Rank.Jack(1))
