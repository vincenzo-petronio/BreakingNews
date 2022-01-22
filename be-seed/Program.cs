using be_seed;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Json;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
    })
    .Build();

var httpClientFactory = host.Services.GetRequiredService<IHttpClientFactory>();
var httpClient = httpClientFactory.CreateClient();

// DEBUG
//var pastNewsResponse = await httpClient.GetAsync("http://localhost:5000/api/News");
//var pastNews = await pastNewsResponse.Content.ReadFromJsonAsync<List<News>>();

var randomNewsPattern = new Faker<News>()
    .RuleFor(n => n.Title, f => f.Lorem.Word())
    .RuleFor(n => n.Description, f => f.Lorem.Sentence(15))
    .RuleFor(n => n.Timestamp, f =>
    {
        DateTime dtPast = new DateTime(2000, 1, 1);
        DateTime dtFuture = DateTime.Now;
        return f.Date.Between(dtPast, dtFuture);
    })
    .RuleFor(n => n.Author, f => f.Name.FullName())
    .FinishWith((f, u) =>
    {
        Console.WriteLine("NEWS!!! {0}", u.Title);
    })
    ;

var randomNews = randomNewsPattern.GenerateBetween(1, 1);

foreach (var n in randomNews)
{
    var response = await httpClient.PostAsJsonAsync("http://localhost:5000/api/News", n);
    Console.WriteLine(response.StatusCode);
}

await host.RunAsync();