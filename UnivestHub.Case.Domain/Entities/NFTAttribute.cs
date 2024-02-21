using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Domain.Entities
{
    public class NFTAttribute
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string DataId { get; set; } = null!;
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string TraitType { get; set; } = null!;
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Value { get; set; }
    }
}
