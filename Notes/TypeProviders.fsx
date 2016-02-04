#I @"..\packages\"
#r @"FSharp.Data\lib\net40\FSharp.Data.dll"
#r @"FSharp.Charting\lib\net40\FSharp.Charting.dll"

#load @"FSharp.Charting\FSharp.Charting.fsx"

open System
open FSharp.Data
open FSharp.Charting

let worldBank = WorldBankData.GetDataContext()

let country name = 
  worldBank.Countries
  |> Seq.find(fun country -> country.Name = name)

let us = country "United States"
let belgium = country "Belgium"

let countries =
  [| us; belgium|]

[ for c in countries do
    yield c.Indicators.``Gross enrolment ratio, tertiary, male (%)``
    yield c.Indicators.``Gross enrolment ratio, tertiary, female (%)`` ]
|> List.map Chart.Line
|> Chart.Combine
