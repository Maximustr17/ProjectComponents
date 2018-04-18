using Cenfotec.Components.Entities.Consultas.Entrada;
using Cenfotec.Components.Entities.Consultas.Salida;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cenfotec.Components.Modelo;

namespace Cenfotec.Components.AD.Consltas
{
    public class ConsultasAD
    {
        #region Users
        public RetrieveUserXIdRes RetrieveUserXId(RetrieveUserXIdReq oReq)
        {
            RetrieveUserXIdRes oRes = new RetrieveUserXIdRes();

            ObjectParameter oEstado = new ObjectParameter("ESTADO", "00");
            ObjectParameter oMensaje = new ObjectParameter("MENSAJE", string.Empty);

            try
            {
                using (Modelo.components_bdEntities oModelo = new Modelo.components_bdEntities())
                {
                    oRes.User = oModelo.PA_CONS_USER_X_ID(oReq.id, oEstado, oMensaje).ToList();

                    //Se valida el resultado
                    if (oRes.User == null || oEstado.Value.ToString().Equals("99"))
                    {
                        oRes.estado = "99";
                        oRes.mensaje = "MENSAJE_ERROR_AD " + oMensaje.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                oRes.estado = "99";
                oRes.mensaje = "MENSAJE_ERROR_AD " + ((ex.InnerException != null) ? Environment.NewLine + ex.InnerException.Message : string.Empty);
                throw;
            }
            finally
            {
                //Liberamos la memoria.
                oEstado = null;
                oMensaje = null;
            }


            return oRes;
        }
        #endregion

        #region Tracks
        public RetrieveTrackXIdRes RetrieveTrackXId(RetrieveTrackXIdReq oReq)
        {
            RetrieveTrackXIdRes oRes = new RetrieveTrackXIdRes();

            ObjectParameter oEstado = new ObjectParameter("ESTADO", "00");
            ObjectParameter oMensaje = new ObjectParameter("MENSAJE", string.Empty);

            try
            {
                using (Modelo.components_bdEntities oModelo = new Modelo.components_bdEntities())
                {
                    oRes.Track = oModelo.PA_RET_TRACK_X_ID(oReq.id, oEstado, oMensaje).ToList();

                    //Se valida el resultado
                    if (oRes.Track == null || oEstado.Value.ToString().Equals("99"))
                    {
                        oRes.estado = "99";
                        oRes.mensaje = "MENSAJE_ERROR_AD " + oMensaje.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                oRes.estado = "99";
                oRes.mensaje = "MENSAJE_ERROR_AD " + ((ex.InnerException != null) ? Environment.NewLine + ex.InnerException.Message : string.Empty);
                throw;
            }
            finally
            {
                //Liberamos la memoria.
                oEstado = null;
                oMensaje = null;
            }


            return oRes;
        }
        #endregion

    }
}
