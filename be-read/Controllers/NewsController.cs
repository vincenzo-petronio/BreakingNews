using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace be_read.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IMongoClient mongoClient;
        private readonly IMongoDatabase mongoDb;
        private readonly IMongoCollection<News> mongoCollection;

        public NewsController(IConfiguration config)
        {
            configuration = config;
            mongoClient = new MongoClient(configuration["MongoDb:ConnectionString"]);
            mongoDb = mongoClient.GetDatabase(configuration["MongoDb:DatabaseName"]);
            mongoCollection = mongoDb.GetCollection<News>(configuration["MongoDb:CollectionName"]);
        }

        // GET: api/<NewsController>
        [HttpGet]
        public async Task<List<News>> Get()
        {
            var response = await mongoCollection.FindAsync(n => true);
            return response.ToList();
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public async Task<News> Get(int id)
        {
            var response = await mongoCollection.FindAsync(n => n.IdSql == (ulong)id);
            return response.First();
        }

        // POST api/<NewsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            var response = await mongoCollection.DeleteOneAsync(n => n.IdSql == (ulong)id);
            return response.DeletedCount == 1;
        }
    }
}
