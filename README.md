<h1 align="center">Luno API</h1>

<h4 align="center">.NET client for <a href="https://www.luno.com/en/api">Luno bitcoin exchange API</a></h4>
<p align="center">
    <a href="https://www.nuget.org/packages/luno-api/">
        <img src="https://img.shields.io/nuget/v/luno-api.svg" alt="NuGet Package">
    </a>
</p>


# Getting Started

## Install

```
Install-Package luno-api
```

## Usage

```csharp
using luno_api;
```

```csharp
var client = new LunoClient(_privateKey, _publicKey);

var response = await client.GetTickers();
foreach (var ticker in response.Tickers.Entities)
{
    Console.WriteLine(ticker.Bid);
}
```
## Missing

Still need to implement the methods for Sending bitcoin and for creating quotes

