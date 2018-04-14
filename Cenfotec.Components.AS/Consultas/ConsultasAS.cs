using Cenfotec.Components.Entities.Consultas.Entrada;
using Cenfotec.Components.Entities.Consultas.Salida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotec.Components.AS.Consultas
{
    public class ConsultasAS
    {
        public RetrieveUserXIdRes RetrieveUserXId(RetrieveUserXIdReq objReq)
        {
            Cenfotec.Components.WS.Consultas.ConsultasWCF oProxyClient = new WS.Consultas.ConsultasWCF();

            RetrieveUserXIdRes oRes = new RetrieveUserXIdRes();

            try
            {
                oRes = oProxyClient.RetrieveUserXId(objReq);
            }
            catch (Exception ex)
            {
                oRes.estado = "99";
                oRes.mensaje = "MENSAJE_ERROR_AS " + ((ex.InnerException != null) ? Environment.NewLine + ex.InnerException.Message : string.Empty);
                throw;
            }
            finally
            {
                // Liberamos la memoria
                oProxyClient = null;
            }
            return oRes;
        }
    }
}
