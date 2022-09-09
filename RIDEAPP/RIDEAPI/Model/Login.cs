using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace RIDEAPI.Model
{
    [BsonIgnoreExtraElements]
    public class Login
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id { get; set; }
        public string Email { get; set; } = null!;
        public string  Password { get; set; } = null!;

    }
}
