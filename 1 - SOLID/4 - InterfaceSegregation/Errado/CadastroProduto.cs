using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation.Errado
{
    public class CadastroProduto : ICadastro
    {
        public void SalvarBanco()
        {
            // Salvar no banco
        }

        public void ValidarDados()
        {
            // Validar os dados
        }
    }
}
