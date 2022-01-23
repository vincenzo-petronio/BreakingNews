using MongoDB.Bson;

namespace be_read
{
    public class News
    {
        public ObjectId Id { get; set; }

        public ulong IdSql { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Title { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public DateTime Timestamp { get; set; }
    }
}
