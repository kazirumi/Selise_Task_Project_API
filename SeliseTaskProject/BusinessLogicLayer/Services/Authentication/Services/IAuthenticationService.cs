using BusinessLogicLayer.Services.Authentication.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Authentication.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> Register(AuthRegisterDTO model);

        Task<LoginResponseDTO> Login(AuthLoginDTO model);
    }
}
