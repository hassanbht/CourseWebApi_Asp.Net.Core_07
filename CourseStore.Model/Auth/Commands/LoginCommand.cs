using CourseStore.Model.Framework;
using CourseWebApi.Model.Auth.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWebApi.Model.Auth.Commands
{
    public class LoginCommand: IRequest<ApiResult<AuthenticationResponse>>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
