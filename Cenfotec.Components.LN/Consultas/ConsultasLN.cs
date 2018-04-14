using Cenfotec.Components.AD.Consltas;
using Cenfotec.Components.Entities.Consultas.Entrada;
using Cenfotec.Components.Entities.Consultas.Salida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotec.Components.LN.Consultas
{
    public class ConsultasLN
    {
        public RetrieveUserXIdRes RetrieveUserXId(RetrieveUserXIdReq oReq)
        {
            ConsultasAD consultasAD = new ConsultasAD();
            RetrieveUserXIdRes oRes = new RetrieveUserXIdRes();

            try
            {
                oRes = consultasAD.RetrieveUserXId(oReq);
            }
            catch (Exception ex)
            {
                oRes.estado = "99";
                oRes.mensaje = "MENSAJE_ERROR_LN" + ((ex.InnerException != null) ? Environment.NewLine + ex.InnerException.Message : string.Empty);
                throw;
            }
            finally
            {
                // Liberamos la memoria
                consultasAD = null;
            }
            return oRes;
        }
    }
}
