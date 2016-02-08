let hammingDistance (one:string) (two:string) =
  let toCharArray (word:string) = List.ofSeq word |> List.toArray

  let a = toCharArray one
  let b = toCharArray two

  let zipped =
    (a, b)
    ||> Array.zip

  if one.Length <> two.Length then
    failwith "words must have same length"
  else
    zipped
    |> Array.filter(fun (a,b) -> (a <> b))
    |> Array.length