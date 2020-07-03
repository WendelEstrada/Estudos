using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion.Errado
{
    public class Usuario
    {
        public int CodigoUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string ChaveAmericas { get; set; }
        public DateTime DataCadastro { get; set; }

        public bool EhValido()
        {
            return EmailServices.EhValido(Email) && ChaveAmericasService.EhValida(ChaveAmericas);
        }
    }
}
