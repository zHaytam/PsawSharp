# PsawSharp

PsawCharp is a simple wrapper around [Pushshift's API](https://pushshift.io/api-parameters/) that supports rate limits and proxies.

## Example:

From the Tests project:

```csharp
var client = new PsawClient(new RequestsManagerOptions
{
    ProxyAddress = "178.217.194.175:49850"
});

var meta = await client.GetMeta();
Assert.Equal("178.217.194.175", meta.SourceIp);
Assert.Equal("PL", meta.ClientRequestHeaders.CfIpCountry);
```

```csharp
var client = new PsawClient();
var submmissions = await client.Search<SubmissionEntry>(new SearchOptions
{
    Subreddit = "game",
    Size = 1
});

Assert.Single(submmissions);
```
