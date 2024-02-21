using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Domain.Entities
{
    public class NFTData
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? ImageId { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Name { get; set; } = null!;
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Description { get; set; } = null!;
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Collection { get; set; } = null!;        
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Class { get; set; } = null!;        
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Type { get; set; } = null!;        
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Variant { get; set; } = null!;
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string ItemId { get; set; } = null!;
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Rarity { get; set; } = null!;

        public List<NFTAttribute>? Attributes { get; set; }
    }
}
