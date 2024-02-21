using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Queries.GetNftMetadata
{
    public class GetNftMetadataResponse
    {
        public string Dna { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Collection { get; set; }= null!;
        public string Class { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Variant { get; set; } = null!;
        public string Rarity { get; set; } = null!;
        public string? Image { get; set; }
        public string? TumbImage { get; set; }
        public string? ThreeDimension { get; set; }
        public List<NFTMetaAttribute> Attributes { get; set; }
    }

    public class NFTMetaAttribute
    {
        public string TraitType { get; set; } = null!;

        public string Value { get; set; } = null!;
    }
}
