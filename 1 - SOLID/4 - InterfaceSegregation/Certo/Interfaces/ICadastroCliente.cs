using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation.Certo.Interfaces
{
    public interface ICadastroCliente
    {
        void ValidarDados();
        void SalvarBanco();
        void EnviarEmail();
    }
}
