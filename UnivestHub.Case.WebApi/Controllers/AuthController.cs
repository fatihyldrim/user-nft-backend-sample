using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnivestHub.Case.WebApi.Attributes;
using UnivestHub.Case.Application.Features.Queries.GetProfile;
using UnivestHub.Case.Common.ResponsePattern;

using UnivestHub.Case.Application.Features.Auth.LoginWithEmail;
using UnivestHub.Case.Application.Features.Auth.GenerateMailConfirmationCode;
using UnivestHub.Case.Application.Features.Auth.SaveWallet;

namespace UnivestHub.Case.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// It works both subscribe and login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("LoginWithEmail")]
        public async Task<IActionResult> LoginWithEmail(LoginWithEmailRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<bool>(result));
        }

        /// <summary>
        /// It creates the confirmation code before login.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GenerateMailConfirmationCode")]
        [ValidModel]
        public async Task<IActionResult> GenerateMailConfirmationCode(GenerateMailConfirmationCodeRequest request)
        {
            await _mediator.Send(request);
            return Ok(new ApiResponse<NoContent>());
        }

        /// <summary>
        /// It saves the wallet data when user created.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("SaveWallet")]
        [ValidModel]
        public async Task<IActionResult> SaveWallet(SaveWalletRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<bool>(result));
        }

    }
}
