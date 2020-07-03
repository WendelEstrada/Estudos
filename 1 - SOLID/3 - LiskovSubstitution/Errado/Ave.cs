using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution.Errado
{
    public abstract class Ave
    {
        public virtual void Comer()
        {
            // método para a ave comer
        }
        public virtual void Voar()
        {
            // método para a ave voar
        }
    }
}
