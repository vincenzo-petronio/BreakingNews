// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;
using be_sync;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

Console.WriteLine("Hello, World!");


//using IHost host = Host.CreateDefaultBuilder(args).Build();

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

ServiceBusClient serviceBusClient = new ServiceBusClient(configuration.GetConnectionString("AzureServiceBus"));
ServiceBusProcessor serviceBusProcessor = serviceBusClient.CreateProcessor("BreakingNews", "breakingnews-sub-001", new ServiceBusProcessorOptions());

IMongoClient mongoClient = new MongoClient(configuration["MongoDb:ConnectionString"]);
IMongoDatabase mongoDb = mongoClient.GetDatabase(configuration["MongoDb:DatabaseName"]);
IMongoCollection<News> mongoCollection = mongoDb.GetCollection<News>(configuration["MongoDb:CollectionName"]);

try
{
    serviceBusProcessor.ProcessMessageAsync += MessageHandler;
    serviceBusProcessor.ProcessErrorAsync += ErrorHandler;
    await serviceBusProcessor.StartProcessingAsync();

    Console.WriteLine("Press any key to end the processing");
    Console.ReadKey();
    await serviceBusProcessor.StopProcessingAsync();
}
finally
{
    await serviceBusProcessor.DisposeAsync();
    await serviceBusClient.DisposeAsync();
}

async Task MessageHandler(ProcessMessageEventArgs args)
{
    string newsJson = args.Message.Body.ToString();
    Console.WriteLine($"RECEIVED: {newsJson}");

    try
    {
        var newsDocument = BsonSerializer.Deserialize<News>(newsJson);

        await mongoCollection.InsertOneAsync(newsDocument);

        await args.CompleteMessageAsync(args.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"EXCEPTION: {ex.Message}");
    }

}

Task ErrorHandler(ProcessErrorEventArgs arg)
{
    Console.WriteLine($"EXCEPTION: {arg.Exception.Message}");
    return Task.CompletedTask;
}

//await host.RunAsync();