using Cenfotec.Components.AD.Mantenimientos;
using Cenfotec.Components.Entities.Mantenimientos.Entrada;
using Cenfotec.Components.Entities.Mantenimientos.Salida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotec.Components.LN.Mantenimientos
{
    public class MantenimientosLN
    {
        public SaveUserRes SaveUser(SaveUserReq oReq)
        {
            MantenimientosAD mantenimientosAD = new MantenimientosAD();
            SaveUserRes oRes = new SaveUserRes();

            try
            {
                oRes = mantenimientosAD.SaveUser(oReq);
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
                mantenimientosAD = null;
            }
            return oRes;
        }
    }
}
