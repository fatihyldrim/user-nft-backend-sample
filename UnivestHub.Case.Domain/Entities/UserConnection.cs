

using MongoDB.Bson.Serialization.Attributes;

namespace UnivestHub.Case.Domain.Entities
{
    public class UserConnection 
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string CustomId { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? MobileId { get; set; }        
        
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? PlayFabId { get; set; }
        
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? WalletAddress { get; set; }
        
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Email { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime? WebEmailVerificationDate { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime? MobileEmailVerificationDate { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? MobileEmailCode { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? WebEmailCode { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Boolean)]
        public bool IsActive { get; set; } = true;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? ParentId { get; set; }

    }
}
