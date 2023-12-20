using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Authentication.DTOs
{
    public  class LoginResponseDTO
    {
        public bool Success { get; set; }
        public string Token { get; set; } = "";
    }
}
