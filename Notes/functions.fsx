// type inference
let add x y = x + y

// annotation
let addfloat (x:float) y = x + y

let classicAdd (x,y) = x + y

// partial application
let add5 = add 5
let add42 = add 42

add5 1

1
|> add 1
|> add 1
|> add 7

let lowerCase (txt:string) = txt.ToLowerInvariant ()

"HElllo" |> lowerCase

let removeWhitespace (txt:string) = txt.Replace(" ", "")

"Hee lloo    :" |> removeWhitespace

let cleanup txt =
  txt |> lowerCase |> removeWhitespace

cleanup "HeLL   o BelgIUM"

let cleaner = (lowerCase >> removeWhitespace)

cleaner "HeLL   o BelgIUM"

type Cleaner = string -> string

let cleanup2 (txts:string list) =
  txts |> List.map (cleaner)

[ "Abdsfa ";"   sdsaF" ] |> cleanup2


let extensibleCleanup (f:Cleaner) (txts:string list) =
  txts |> List.map f

[ "Abdsfa ";"   sdsaF" ] |> (extensibleCleanup (lowerCase >> removeWhitespace))


  // sprintf "hello world %s %i %.2f %A" "Belgium" 42 123.456789 (System.DateTime.Now)

//let timed = adinene

(*
  let lazyDemo =
    seq { 1 .. 1000000000 }
    |> Seq.filter (fun x -> x % 2 = 0)
    |> Seq.filter (fun x -> x % 2 = 5)
    |> Seq.filter (fun x -> x % 2 = 3)
    |> Seq.length
*)
