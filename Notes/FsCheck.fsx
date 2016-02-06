#I @"..\packages\"

#r @"FsCheck\lib\net45\FsCheck.dll"

open FsCheck

let revRevIsOrigin (xs:List<int>) =
  List.rev(List.rev xs) = xs

Check.Quick revRevIsOrigin
Check.Verbose revRevIsOrigin

let revIsOrig (xs:list<int>) =
  List.rev xs = xs

Check.Quick revIsOrig
Check.Verbose revIsOrig

let reverseReverseIsOriginFloat (xs:List<float>) =
  List.rev(List.rev xs) = xs
Check.Quick reverseReverseIsOriginFloat
