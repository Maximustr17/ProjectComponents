using Cenfotec.Components.Entities.Mantenimientos.Entrada;
using Cenfotec.Components.Entities.Mantenimientos.Salida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotec.Components.AS.Mantenimientos
{
    public class MantenimientosAS
    {
        #region Users
        public SaveUserRes SaveUser(SaveUserReq objReq)
        {
            Cenfotec.Components.WS.MantenimientosWCF oProxyClient = new Cenfotec.Components.WS.MantenimientosWCF();

            SaveUserRes oRes = new SaveUserRes();
            
            try
            {
                oRes = oProxyClient.SaveUser(objReq);
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
        #endregion
    }
}
