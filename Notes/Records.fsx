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

type Card = Suit * Rank

let sevenSpades = (Suit.Spade, Rank.Seven)
let jackHearts = (Suit.Heart, Rank.Jack(1))
