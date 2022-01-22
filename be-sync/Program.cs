// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, World!");




ServiceBusClient serviceBusClient = new ServiceBusClient("");
ServiceBusProcessor serviceBusProcessor = serviceBusClient.CreateProcessor("BreakingNews", "breakingnews-sub-001", new ServiceBusProcessorOptions());

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
    string body = args.Message.Body.ToString();
    Console.WriteLine($"RECEIVED: {body}");

    await args.CompleteMessageAsync(args.Message);
}

Task ErrorHandler(ProcessErrorEventArgs arg)
{
    Console.WriteLine($"EXCEPTION: {arg.Exception.Message}");
    return Task.CompletedTask;
}