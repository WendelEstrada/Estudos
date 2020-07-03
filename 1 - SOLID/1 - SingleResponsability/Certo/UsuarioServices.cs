using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsability.Certo
{
    public class UsuarioServices
    {
        public string Adicionar(Usuario usuario)
        {
            if (!usuario.EhValido())
                return "Dados inválidos";

            var repositorio = new UsuarioRepository();
            repositorio.Adicionar(usuario);

            EmailServices.Enviar("teste@teste.com.br", usuario.Email, "Bem Vindo", "Parabéns está Cadastrado");

            return "Usuário cadastrado com sucesso!";
        }
    }
}
