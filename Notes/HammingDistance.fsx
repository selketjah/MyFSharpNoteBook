let hammingDistance (one:string) (two:string) =
  if one.Length <> two.Length then
    failwith "words must have same length"
  else
    (one, two)
    ||> Seq.zip
    |> Seq.filter(fun (a,b) -> (a <> b))
    |> Seq.length


let hammingDistance2 (one:string) (two:string) =
  if one.Length <> two.Length then
    failwith "words must have same length"
  else
    (one, two)
    ||> Seq.zip
    |> Seq.fold (fun count (a,b) ->
      if a=b
      then count
      else count + 1) 0

  let a x = x * 2
