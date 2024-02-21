using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Domain.Entities
{
    public class NFTAttiributeResponse
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Trait_Type { get; set; } = null!;
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Value { get; set; }
    }
}
