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
                            oSaveUsuarioReq.display_name = modelo.display_name;
                            oSaveUsuarioReq.email = modelo.email;
                            oSaveUsuarioReq.spotify_url = modelo.spotify_url;
                            oSaveUsuarioReq.href = modelo.href;
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

            ConsultasLN consultasLN = null;
            RetrieveTrackXIdReq oRetTrackReq = null;
            RetrieveTrackXIdRes oRetTrackRes = null;

            MantenimientosLN mantenimientosLN = null;
            SaveTrackReq oSaveTrackReq = null;
            SaveTrackRes oSaveTrackRes = null;

            SaveTrackXUserReq oSaveTrackXUserreq = null;
            SaveTrackXUserRes oSaveTrackXUserres = null;

            try
            {
                if (modelo != null)
                {
                    consultasLN = new ConsultasLN();
                    oRetTrackReq = new RetrieveTrackXIdReq();
                    oRetTrackReq.id = modelo.id;
                    oRetTrackRes = consultasLN.RetrieveTrackXId(oRetTrackReq);

                    if (oRetTrackRes != null && oRetTrackRes.Track != null)
                    {
                        if (oRetTrackRes.Track.Count > 0)
                        {
                            modelo.track_id = oRetTrackRes.Track[0].track_id;

                            
                        }
                        else
                        {
                            mantenimientosLN = new MantenimientosLN();
                            oSaveTrackReq = new SaveTrackReq();
                            oSaveTrackReq.track_id = Guid.NewGuid();
                            oSaveTrackReq.name = modelo.name;
                            oSaveTrackReq.spotify_url = modelo.spotify_url;
                            oSaveTrackReq.href = modelo.href;
                            oSaveTrackReq.id = modelo.id;
                            oSaveTrackReq.preview_url = modelo.preview_url;
                            oSaveTrackReq.uri = modelo.uri;

                            oSaveTrackRes = mantenimientosLN.SaveTrack(oSaveTrackReq);

                            if (oSaveTrackRes != null && oSaveTrackRes.estado.Equals("00"))
                            {
                                modelo.track_id = oSaveTrackReq.track_id;
                            }
                        }

                        //Consultar si el usuario tiene la canción y guardarla
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
    }
}