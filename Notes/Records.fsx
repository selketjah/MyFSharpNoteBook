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
