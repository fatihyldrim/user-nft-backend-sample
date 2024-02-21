using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Auth.LoginWithEmail
{
    public class LoginWithEmailRequest : IRequest<bool>
    {
        public string Email { get; set; } = null!;

        public string ConfirmationCode { get; set; }
    }
}
