let levenshteinDistance (one:string) (two:string) =
  let lengthOne = one.Length 
  let lengthTwo = two.Length 

  let distance = Array2D.zeroCreate<int> (lengthOne + 1) (lengthTwo + 1)

  for i = 0 to lengthOne do distance.[i, 0] <- i
  for j = 0 to lengthTwo do distance.[0, j] <- j

  for j = 1 to lengthTwo do
    for i = 1 to lengthOne do
      if one.[i-1] = two.[j-1] then
        distance.[i, j] <- distance.[i-1, j-1]
      else
        distance.[i, j] <-
          [(distance.[i-1, j  ] + 1); (distance.[i  , j-1] + 1); (distance.[i-1, j-1] + 1)]
          |> List.min

  distance.[lengthOne, lengthTwo]