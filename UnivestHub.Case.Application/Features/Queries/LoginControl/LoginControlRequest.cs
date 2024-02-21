using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Queries.LoginControl
{
    public class LoginControlRequest : IRequest<bool>
    {
        public string Email { get; set; } = null!;
        public string MobileId { get; set; } = null!;
    }
}
