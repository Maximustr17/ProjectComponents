using Cenfotec.Components.Entities.Consultas.Entrada;
using Cenfotec.Components.Entities.Consultas.Salida;
using Cenfotec.Components.LN.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Cenfotec.Components.WS.Consultas
{
    public class ConsultasWCF : IConsultasWCF
    {
        public RetrieveUserXIdRes RetrieveUserXId(RetrieveUserXIdReq oReq)
        {
            ConsultasLN consultasLN = new ConsultasLN();
            RetrieveUserXIdRes oRes = new RetrieveUserXIdRes();
            try
            {
                oRes = consultasLN.RetrieveUserXId(oReq);
            }
            catch (Exception ex)
            {
                oRes.estado = "99";
                oRes.mensaje = "MENSAJE_ERROR_WCF " + ex.ToString() + ((ex.InnerException != null) ? Environment.NewLine + ex.InnerException.Message : string.Empty);
            }
            finally
            {
                //Liberamos la memoria
                consultasLN = null;
            }
            return oRes;
        }
    }
}
