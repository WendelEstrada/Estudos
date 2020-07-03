using InterfaceSegregation.Certo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation.Certo
{
    public class CadastroCliente : ICadastroCliente
    {
        public void EnviarEmail()
        {
            // Enviar email
        }

        public void SalvarBanco()
        {
            // Salvar no banco
        }

        public void ValidarDados()
        {
            // Validar dados
        }
    }
}
