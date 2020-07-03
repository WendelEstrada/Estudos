using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution.Errado
{
    public class Pinguim : Ave
    {
        public override void Comer()
        {
            base.Comer();
        }

        public override void Voar()
        {
            throw new NotImplementedException();
        }
    }
}
