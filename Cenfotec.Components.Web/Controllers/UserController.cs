using Cenfotec.Components.Entities.Consultas.Entrada;
using Cenfotec.Components.Entities.Consultas.Salida;
using Cenfotec.Components.Entities.Mantenimientos.Entrada;
using Cenfotec.Components.Entities.Mantenimientos.Salida;
using Cenfotec.Components.LN.Consultas;
using Cenfotec.Components.LN.Mantenimientos;
using Cenfotec.Components.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Cenfotec.Components.Web.Controllers
{
    public class UserController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveUser(UserModels modelo)
        {
            string respuesta = "00";

            ConsultasLN consultasLN = null;
            RetrieveUserXIdReq oRetUsuarioReq = null;
            RetrieveUserXIdRes oRetUsuarioRes = null;

            MantenimientosLN mantenimientosLN = null;
            SaveUserReq oSaveUsuarioReq = null;
            SaveUserRes oSaveUsuarioRes = null;

            try
            {               
                if (modelo != null)
                {
                    consultasLN = new ConsultasLN();
                    oRetUsuarioReq = new RetrieveUserXIdReq();
                    oRetUsuarioReq.id = modelo.id;
                    oRetUsuarioRes = consultasLN.RetrieveUserXId(oRetUsuarioReq);

                    if (oRetUsuarioRes != null && oRetUsuarioRes.User != null)
                    {
                        if (oRetUsuarioRes.User.Count > 0)
                        {
                            modelo.user_id = oRetUsuarioRes.User[0].user_id;

                            return Json(new { respuesta = respuesta, resultado = modelo });
                        }
                        else
                        {
                            mantenimientosLN = new MantenimientosLN();
                            oSaveUsuarioReq = new SaveUserReq();    
                            oSaveUsuarioReq.user_id = Guid.NewGuid();
                            oSaveUsuarioReq.display_name = modelo.display_name != null ? modelo.display_name : "";
                            oSaveUsuarioReq.email = modelo.email != null ? modelo.email : "";
                            oSaveUsuarioReq.spotify_url = modelo.spotify_url != null ? modelo.spotify_url : "";
                            oSaveUsuarioReq.href = modelo.href != null ? modelo.href : "";
                            oSaveUsuarioReq.id = modelo.id;

                            oSaveUsuarioRes = mantenimientosLN.SaveUser(oSaveUsuarioReq);

                            if (oSaveUsuarioRes != null && oSaveUsuarioRes.estado.Equals("00"))
                            {
                                modelo.user_id = oSaveUsuarioReq.user_id;
                                return Json(new { respuesta = respuesta, resultado = modelo });
                            }
                            else
                            {
                                return Json(new { respuesta = "99" });
                            }
                        }
                    }
                    else
                    {
                        return Json(new { respuesta = "99" });
                    }
                }
            }

            catch (Exception ex)
            {

            }

            return Json(new { respuesta = "00" });
        }

        [HttpPost]
        public ActionResult SaveTrack(TrackModels modelo)
        {
            string respuesta = "00";

            ConsultasLN consultasLN = new ConsultasLN();
            MantenimientosLN mantenimientosLN = new MantenimientosLN(); ;

            RetrieveTrackXIdReq oRetTrackReq = null;
            RetrieveTrackXIdRes oRetTrackRes = null;

            SaveTrackReq oSaveTrackReq = null;
            SaveTrackRes oSaveTrackRes = null;

            RetrieveTrackXUserReq oRetTrackXUserReq = null;
            RetrieveTrackXUserRes oRetTrackXUserRes = null;

            SaveTrackXUserReq oSaveTrackXUserReq = null;
            SaveTrackXUserRes oSaveTrackXUserRes = null;

            try
            {
                if (modelo != null)
                {
                    oRetTrackReq = new RetrieveTrackXIdReq();
                    oRetTrackReq.id = modelo.id;
                    //Consulta si la canción se encuentra en la base de datos
                    oRetTrackRes = consultasLN.RetrieveTrackXId(oRetTrackReq);

                    if (oRetTrackRes != null && oRetTrackRes.Track != null)
                    {
                        if (oRetTrackRes.Track.Count > 0)
                        {
                            modelo.track_id = oRetTrackRes.Track[0].track_id;
                        }
                        else
                        {
                            oSaveTrackReq = new SaveTrackReq();
                            oSaveTrackReq.track_id = Guid.NewGuid();
                            oSaveTrackReq.name = modelo.name != null ? modelo.name : "";
                            oSaveTrackReq.spotify_url = modelo.spotify_url != null ? modelo.spotify_url : "" ;
                            oSaveTrackReq.href = modelo.href != null ? modelo.href : "";
                            oSaveTrackReq.id = modelo.id;
                            oSaveTrackReq.preview_url = modelo.preview_url != null ? modelo.preview_url : "";
                            oSaveTrackReq.uri = modelo.uri != null ? modelo.uri : "";
                            oSaveTrackReq.image_url = modelo.image_url != null ? modelo.image_url : "";

                            //Si la canción no se encuentra en la base de datos la inserta
                            oSaveTrackRes = mantenimientosLN.SaveTrack(oSaveTrackReq);

                            if (oSaveTrackRes != null && oSaveTrackRes.estado.Equals("00"))
                            {
                                modelo.track_id = oSaveTrackReq.track_id;
                            }
                        }

                        //Consulta si el usuario tiene la canción guardada
                        oRetTrackXUserReq = new RetrieveTrackXUserReq();
                        oRetTrackXUserReq.id_user = modelo.user_id;
                        oRetTrackXUserReq.track_id = modelo.id;

                        oRetTrackXUserRes = consultasLN.RetrieveTrackXUser(oRetTrackXUserReq);

                        if (oRetTrackXUserRes != null && oRetTrackXUserRes.Track != null)
                        {
                            if (oRetTrackXUserRes.Track.Count == 0)
                            {
                                oSaveTrackXUserReq = new SaveTrackXUserReq();
                                oSaveTrackXUserReq.id_user = modelo.user_id;
                                oSaveTrackXUserReq.track_id = modelo.id;

                                oSaveTrackXUserRes = mantenimientosLN.SaveTrackXUser(oSaveTrackXUserReq);
                            }
                        }
                        return Json(new { respuesta = respuesta, resultado = modelo });
                    }
                    else
                    {
                        return Json(new { respuesta = "99" });
                    }
                }
            }

            catch (Exception ex)
            {

            }

            return Json(new { respuesta = "00" });
        }

        public ActionResult VwSongList(string id)
        {
            RetrieveTracksSavedByUserReq oTracksByUserReq = null;
            TrackModels modelo = new TrackModels();
            ConsultasLN consultasLN = new ConsultasLN();
            try
            {
                //Consultar las canciones guardadas por un usuario
                oTracksByUserReq = new RetrieveTracksSavedByUserReq();
                oTracksByUserReq.id_user = !String.IsNullOrEmpty(id) ? Guid.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(id))) : Guid.Empty;
                modelo.CopyTracksByUser(consultasLN.RetrieveTracksSavedByUser(oTracksByUserReq));

            }
            catch (Exception ex)
            {

                throw;
            }

            return View(modelo);
        }
    }
}