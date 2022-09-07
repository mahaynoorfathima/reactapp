using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RIDEAPI.Model
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Destination { get; set; } = null!;

        public string RideType { get; set; } = null!;
    }
}
