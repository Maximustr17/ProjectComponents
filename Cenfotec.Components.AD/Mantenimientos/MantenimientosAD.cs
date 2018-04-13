using Cenfotec.Components.Entities.Mantenimientos.Entrada;
using Cenfotec.Components.Entities.Mantenimientos.Salida;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotec.Components.AD.Mantenimientos
{
    public class MantenimientosAD
    {
        #region Users
        public SaveUserRes SaveUser(SaveUserReq oReq)
        {
            SaveUserRes oRes = new SaveUserRes();

            ObjectParameter oEstado = new ObjectParameter("ESTADO", "00");
            ObjectParameter oMensaje = new ObjectParameter("MENSAJE", string.Empty);

            try
            {
                using (Modelo.components_bdEntities oModelo = new Modelo.components_bdEntities())
                {
                    oModelo.PA_SAVE_USER(oReq.user_id,
                                          oReq.display_name
                                          , oReq.email
                                          , oReq.spotify_url
                                          , oReq.href
                                          , oReq.id);

                    if (oEstado.Value.ToString().Equals("99"))
                    {
                        oRes.estado = "99";
                        oRes.mensaje = "MENSAJE_ERROR_AD " + oMensaje.Value.ToString();
                    }
                    else if (true)//oEstado.Value.ToString().Equals(Constantes.COD_ERROR_GENERAL))
                    {
                        //oRes.estado = Constantes.COD_ERROR_GENERAL;
                        oRes.mensaje = oMensaje.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                oRes.estado = "99";
                oRes.mensaje = "MENSAJE " + ((ex.InnerException != null) ? Environment.NewLine + ex.InnerException.Message : string.Empty);
                throw;
            }
            finally
            {
                // Liberamos la memoria.
                oEstado = null;
                oMensaje = null;
            }


            return oRes;
        }
        #endregion
    }
}
