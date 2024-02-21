

using MongoDB.Bson.Serialization.Attributes;

namespace UnivestHub.Case.Domain.Entities
{
    public class ConfirmationCode
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Code { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
    }
}
