using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Queries.GetNftMetadata
{
    public class GetNftMetadataRequest : IRequest<GetNftMetadataResponse>
    {
        public string TokenDna { get; set; }

        public GetNftMetadataRequest(string tokenDna)
        {
            TokenDna = tokenDna;  
        }
    }

}
