namespace Notes

module Twitter =
  open System
  open System.Threading
  open System.Threading.Tasks
  open LinqToTwitter

  let appSettings = ConfigurationManager.AppSettings
  let apiKey = appSettings.["apiKey"]
  let apiSecret = appSettings.["apiSecret"]
  let accessToken = appSettings.["accessToken"]
  let accessTokenSecret = appSettings.["accessTokenSecret"]

  let context =
    let credentials = SingleUserInMemoryCredentialStore()
    credentials.ConsumerKey <- apiKey
    credentials.ConsumerSecret <- apiSecret
    credentials.AccessToken <- accessToken
    credentials.AccessTokenSecret <- accessTokenSecret
    let authorizer = SingleUserAuthorizer()
    authorizer.CredentialStore <- credentials
    new TwitterContext(authorizer)

  let trimToTweet (msg:string) =
    if msg.Length > 140
    then msg.Substring(0,134) + " [...]"
    else msg

  let postTweet question =
    let message =
      question
      |> trimToTweet

    let status =
      Task.Run<Status>(fun _ ->
        question
        |> context.TweetAsync)

    let tweet = status.Result
    tweet.StatusID

  let currentID = 706544311714848769UL
  let secondID = 701012113158963200UL

  let grabRepliesOne (id:uint64) =
    let tweets =
      query {
        for tweet in context.Status do
        where (tweet.Type = StatusType.Mentions && tweet.InReplyToStatusID = id)
        select tweet
      }
      |> Seq.toList

    tweets
    |> List.iter(fun t -> printfn "%s with replyID %i, user %s" t.Text t.InReplyToStatusID t.User.Name)

  let grabRepliesTwo (id:uint64) =
    let tweets =
      query {
         for tweet in context.Search do
         where (tweet.Type = SearchType.Search)
         select tweet
      }
      |> Seq.toList

    tweets
