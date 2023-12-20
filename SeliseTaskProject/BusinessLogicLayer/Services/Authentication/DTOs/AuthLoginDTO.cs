using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Authentication.DTOs
{
    public class AuthLoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
