using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation.Errado
{
    public interface ICadastro
    {
        void ValidarDados();
        void SalvarBanco();
        void EnviarEmail();
    }
}
