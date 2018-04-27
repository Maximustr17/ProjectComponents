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
                                          , oReq.id
                                          , oEstado
                                          , oMensaje
                                          );

                    if (oEstado.Value.ToString().Equals("99"))
                    {
                        oRes.estado = "99";
                        oRes.mensaje = "MENSAJE_ERROR_AD " + oMensaje.Value.ToString();
                    }
                    else if (oEstado.Value.ToString().Equals("98"))
                    {
                        oRes.estado = "98";
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

        #region Tracks
        public SaveTrackXUserRes SaveTrackXUser(SaveTrackXUserReq oReq)
        {
            SaveTrackXUserRes oRes = new SaveTrackXUserRes();

            ObjectParameter oEstado = new ObjectParameter("ESTADO", "00");
            ObjectParameter oMensaje = new ObjectParameter("MENSAJE", string.Empty);

            try
            {
                using (Modelo.components_bdEntities oModelo = new Modelo.components_bdEntities())
                {
                    oModelo.PA_SAVE_TRACK_X_USER(oReq.id_user
                                          , oReq.track_id
                                          , oEstado
                                          , oMensaje
                                          );

                    if (oEstado.Value.ToString().Equals("99"))
                    {
                        oRes.estado = "99";
                        oRes.mensaje = "MENSAJE_ERROR_AD " + oMensaje.Value.ToString();
                    }
                    else if (oEstado.Value.ToString().Equals("98"))
                    {
                        oRes.estado = "98";
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

        public SaveTrackRes SaveTrack(SaveTrackReq oReq)
        {
            SaveTrackRes oRes = new SaveTrackRes();

            ObjectParameter oEstado = new ObjectParameter("ESTADO", "00");
            ObjectParameter oMensaje = new ObjectParameter("MENSAJE", string.Empty);

            try
            {
                using (Modelo.components_bdEntities oModelo = new Modelo.components_bdEntities())
                {
                    oModelo.PA_SAVE_TRACK(oReq.track_id
                                          , oReq.name
                                          , oReq.spotify_url
                                          , oReq.href
                                          , oReq.id
                                          , oReq.preview_url
                                          , oReq.uri
                                          , oReq.image_url
                                          , oEstado
                                          , oMensaje
                                          );

                    if (oEstado.Value.ToString().Equals("99"))
                    {
                        oRes.estado = "99";
                        oRes.mensaje = "MENSAJE_ERROR_AD " + oMensaje.Value.ToString();
                    }
                    else if (oEstado.Value.ToString().Equals("98"))
                    {
                        oRes.estado = "98";
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

        public DeleteTrackByUserRes DeleteTrackByUser(DeleteTrackByUserReq oReq)
        {
            DeleteTrackByUserRes oRes = new DeleteTrackByUserRes();

            ObjectParameter oEstado = new ObjectParameter("ESTADO", "00");
            ObjectParameter oMensaje = new ObjectParameter("MENSAJE", string.Empty);

            try
            {
                using (Modelo.components_bdEntities oModelo = new Modelo.components_bdEntities())
                {
                    oModelo.PA_DEL_TRACK_X_USER(oReq.track_id
                                          , oReq.user_id
                                          , oEstado
                                          , oMensaje
                                          );

                    if (oEstado.Value.ToString().Equals("99"))
                    {
                        oRes.estado = "99";
                        oRes.mensaje = "MENSAJE_ERROR_AD " + oMensaje.Value.ToString();
                    }
                    else if (oEstado.Value.ToString().Equals("98"))
                    {
                        oRes.estado = "98";
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
