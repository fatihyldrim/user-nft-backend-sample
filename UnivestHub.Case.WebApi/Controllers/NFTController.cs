using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnivestHub.Case.WebApi.Attributes;
using UnivestHub.Case.Common.ResponsePattern;
using UnivestHub.Case.Application.Features.Queries.GetNftMetadata;
using UnivestHub.Case.Application.Features.Queries.GetNFT;
using UnivestHub.Case.Domain.Entities;
using UnivestHub.Case.Application.Features.Commands.CreateNFTMetaData;
using UnivestHub.Case.Application.Features.Commands.NFTTransaction;
using UnivestHub.Case.Application.Interfaces;

namespace UnivestHub.Case.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NFTController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMailService _mailService;
        public NFTController(IMediator mediator, IMailService mailService)
        {
            _mediator = mediator;
            _mailService = mailService;
        }

        [HttpGet("GetProfile/{tokenDna}")]
        [ValidModel]
        public async Task<IActionResult> GetProfile(string tokenDna)
        {
            var result = await _mediator.Send(new GetNftMetadataRequest(tokenDna));
            return Ok(new ApiResponse<GetNftMetadataResponse>(result));
        }

        [HttpGet("NFT/{tokenId}")]
        [ValidModel]
        public async Task<NFTMetaData> GetNFT(string tokenId)
        {
            var result = await _mediator.Send(new GetNFTRequest(tokenId));
            return result;
        }

        [HttpPost("CreateNFTMetaData")]
        [ValidModel]
        public async Task<IActionResult> CreateNFTMetaData(CreateNFTMetaDataRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<bool>(result));
        }

        [HttpPost("NFTTransaction")]
        [ValidModel]
        public async Task<IActionResult> NFTTransaction(NFTTransactionRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<NFTTransactionResponse>(result));
        }

    }
}
