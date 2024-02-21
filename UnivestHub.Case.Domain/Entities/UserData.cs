using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Domain.Entities
{
    public class UserData
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Email { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? WalletAddress { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? WalletMnemonic { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? WalletPrivateKey { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string ConfirmationCode { get; set; } = null!;

    }
}
