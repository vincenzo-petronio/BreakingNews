using Azure.Messaging.ServiceBus;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace be_write.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private const string ServiceBusTopic = "BreakingNews";
        private readonly ILogger<NewsController> logger;
        private readonly IConfiguration configuration;
        private ServiceBusClient serviceBusClient;
        private ServiceBusSender serviceBusSender;

        public NewsController(ILogger<NewsController> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
            serviceBusClient = new ServiceBusClient(configuration.GetConnectionString("AzureServiceBus"));
            serviceBusSender = serviceBusClient.CreateSender(ServiceBusTopic);
        }


        // GET: api/<NewsController>
        [HttpGet]
        public async Task<List<News>> Get()
        {
            List<News> result = new();

            await using var connection = new NpgsqlConnection(configuration.GetConnectionString("PostgreSQL"));

            // Esempio con NPSQL base
            //await using var command = new NpgsqlCommand("SELECT * FROM \"News\"", connection);
            //await connection.OpenAsync();
            //await using var reader = await command.ExecuteReaderAsync();
            //while (reader.Read())
            //{
            //    result.Add(new News
            //    {
            //        Id = (ulong)reader.GetInt64(0),
            //        Title = reader.GetString(1),
            //        Description = reader.GetString(2),
            //        Timestamp = reader.GetDateTime(3),
            //        Author = reader.GetString(4)
            //    });
            //}

            // Esempio con NPSQL e DAPPER
            result = (await connection.QueryAsync<News>("SELECT * FROM \"News\"")).ToList();

            return result;
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NewsController>
        [HttpPost]
        public async Task Post(News value)
        {
            string command = $"SET datestyle = \"ISO, DMY\"; INSERT INTO \"News\" (\"Title\", \"Description\", \"Timestamp\", \"Author\") VALUES ('{value.Title}', '{value.Description}', '{value.Timestamp}', '{value.Author}') RETURNING \"Id\";";
            await using var connection = new NpgsqlConnection(configuration.GetConnectionString("PostgreSQL"));
            ulong id = await connection.QueryFirstAsync<ulong>(command);

            if (id > 0)
            {
                ShortNews news = new()
                {
                    Id = id,
                    Title = value.Title,
                    Timestamp = value.Timestamp
                };
                var newsJson = System.Text.Json.JsonSerializer.Serialize<ShortNews>(news);
                ServiceBusMessage eventMessage = new ServiceBusMessage(newsJson);
                try
                {
                    await serviceBusSender.SendMessageAsync(eventMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    await serviceBusSender.DisposeAsync();
                    await serviceBusClient.DisposeAsync();
                }
            }
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
