using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace be_sync
{
    internal class News
    {
        public ulong IdSql { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        //[BsonElement("title")]
        public string Title { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        //[BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
