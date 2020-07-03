using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed.Errado
{
    public class Documento
    {
        public void FormatarTipoDeDocumento(TipoDocumento tipoDoDocumento)
        {
            if (tipoDoDocumento.Equals(TipoDocumento.JSON))
            {
                // Formata em JSON
            }

            if (tipoDoDocumento.Equals(TipoDocumento.XML))
            {
                // Formata em XML
            }

            if (tipoDoDocumento.Equals(TipoDocumento.TXT))
            {
                // Formata em TXT
            }
        }
    }
}
