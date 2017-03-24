open Microsoft.FSharp.Reflection

open System.Web
open System
open System.Globalization

type PaypalResponse (timestamp : string, correlationId : string, ack : string, version : string, build : string, errorCode : string, shortMessage : string, longMessage : string, severityCode: string, token : string) =
    
    new() = PaypalResponse(String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)

    member val Timestamp = timestamp with get,set
    member val CorrelationId = correlationId with get,set
    member val Ack = ack with get,set
    member val Version = version with get,set
    member val Build = build with get,set
    member val L_ErrorCode = errorCode with get,set
    member val L_ShortMessage = shortMessage with get,set
    member val L_LongMessage = longMessage with get,set
    member val L_SeverityCode = severityCode with get,set
    member val Token = token with get,set

let querystring = "TIMESTAMP=2017%2d03%2d23T09%3a15%3a15Z&CORRELATIONID=c4ca2730bdc00&ACK=Failure&VERSION=204%2e0&BUILD=31426570&L_ERRORCODE0=10401&L_ERRORCODE1=10426&L_SHORTMESSAGE0=Transaction%20refused%20because%20of%20an%20invalid%20argument%2e%20See%20additional%20error%20messages%20for%20details%2e&L_SHORTMESSAGE1=Transaction%20refused%20because%20of%20an%20invalid%20argument%2e%20See%20additional%20error%20messages%20for%20details%2e&L_LONGMESSAGE0=Order%20total%20is%20invalid%2e&L_LONGMESSAGE1=Item%20total%20is%20invalid%2e&L_SEVERITYCODE0=Error&L_SEVERITYCODE1=Error"

let temp =
  querystring
  |> HttpUtility.UrlDecode
  |> HttpUtility.ParseQueryString

let parse (typeRequest : Type) =
    let properties = typeRequest.GetProperties()
    let instance = Activator.CreateInstance(typeRequest)

    for prop in properties do
        let value = temp.Get(prop.Name)
        prop.SetValue(instance, value)

    instance

let test = parse typeof<PaypalResponse>

test :?> PaypalResponse;;
