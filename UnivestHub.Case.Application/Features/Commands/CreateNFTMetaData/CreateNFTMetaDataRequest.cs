using UnivestHub.Case.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Commands.CreateNFTMetaData
{
    public class CreateNFTMetaDataRequest : IRequest<bool>
    {
        public List<NFTMetaData> MetaDatas { get; set; } = null!;
    }
}
