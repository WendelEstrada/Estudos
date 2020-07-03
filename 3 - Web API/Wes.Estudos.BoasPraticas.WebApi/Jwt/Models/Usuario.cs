using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wes.Estudos.BoasPraticas.WebApi.Jwt.Models
{
    public class Usuario
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}
