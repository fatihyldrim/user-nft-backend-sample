using MongoDB.Bson.Serialization.Attributes;

namespace UnivestHub.Case.Domain.Entities
{
    public class NFTMetaData
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string NFTDataId { get; set; } = null!;
        public NFTData? NFTData { get; set; } = null!;
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Image { get; set; }        
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? ThumbImage { get; set; }        
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? ThreeDimension { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Dna { get; set; } = null!;
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime Date { get; set; }
    }
}
