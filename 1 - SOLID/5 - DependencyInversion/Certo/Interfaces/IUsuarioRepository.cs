using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion.Certo.Interfaces
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
    }
}
