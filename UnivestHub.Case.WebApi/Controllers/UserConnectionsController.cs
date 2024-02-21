using UnivestHub.Case.Application.Features.Commands.CheckEmail;
using UnivestHub.Case.Application.Features.Commands.LoginWithMobile;
using UnivestHub.Case.Application.Features.Queries.GetProfile;
using UnivestHub.Case.Application.Features.Queries.LoginControl;
using UnivestHub.Case.Common.ResponsePattern;
using UnivestHub.Case.WebApi.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UnivestHub.Case.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserConnectionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserConnectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("LoginWithMobile")]
        [ValidModel]
        public async Task<IActionResult> LoginWithMobile(LoginWithMobileRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<LoginWithMobileResponse>(result));
        }

        [HttpGet("GetProfile/{customId}")]
        [Authorize]
        public async Task<IActionResult> GetProfile(string customId)
        {
            var result = await _mediator.Send(new GetProfileRequest(customId));
            return Ok(new ApiResponse<GetProfileResponse>(result));
        }

        [HttpGet("CheckMail/{walletAddress}")]
        public async Task<IActionResult> CheckMail(string walletAddress)
        {
            var result = await _mediator.Send(new CheckEmailRequest(walletAddress));
            return Ok(result);
        }

        [HttpPost("LoginControl")]
        public async Task<IActionResult> LoginControl(LoginControlRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<bool>(result));
        }
    }
}
