using DependencyInversion.Certo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion.Certo
{
    public class UsuarioServices : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IEmailService emailService;

        public UsuarioServices(
            IUsuarioRepository usuarioRepository,
            IEmailService emailService)
        {
            this.usuarioRepository = usuarioRepository;
            this.emailService = emailService;
        }

        public string Adicionar(Usuario usuario)
        {
            if (!usuario.EhValido())
                return "Dados inválidos";

            usuarioRepository.Adicionar(usuario);

            emailService.Enviar("teste@teste.com.br", usuario.Email, "Bem Vindo", "Parabéns está Cadastrado");

            return "Usuário cadastrado com sucesso!";
        }
    }
}
