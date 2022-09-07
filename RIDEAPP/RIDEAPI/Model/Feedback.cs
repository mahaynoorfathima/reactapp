using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RIDEAPI.Model
{
    public class Feedback
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Time { get; set; } = null!;

        public string feedback { get; set; } = null!;
    }
}
