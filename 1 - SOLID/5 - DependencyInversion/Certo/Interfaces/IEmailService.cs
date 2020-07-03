using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion.Certo.Interfaces
{
    public interface IEmailService
    {
        bool EhValido(string email);
        void Enviar(string de, string para, string assunto, string mensagem);
    }
}
