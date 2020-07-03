using DependencyInversion.Certo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion.Certo
{
    public class Usuario
    {
        private readonly IChaveAmericasService chaveAmericasService;
        private readonly IEmailService emailService;

        public Usuario(
            IChaveAmericasService chaveAmericasService,
            IEmailService emailService)
        {
            this.chaveAmericasService = chaveAmericasService;
            this.emailService = emailService;
        }

        public int CodigoUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string ChaveAmericas { get; set; }
        public DateTime DataCadastro { get; set; }

        public bool EhValido()
        {
            return emailService.EhValido(Email) && chaveAmericasService.EhValida(ChaveAmericas);
        }
    }
}
