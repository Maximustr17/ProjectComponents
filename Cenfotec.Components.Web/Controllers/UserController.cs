using Cenfotec.Components.AS.Consultas;
using Cenfotec.Components.AS.Mantenimientos;
using Cenfotec.Components.Entities.Consultas.Entrada;
using Cenfotec.Components.Entities.Consultas.Salida;
using Cenfotec.Components.Entities.Mantenimientos.Entrada;
using Cenfotec.Components.Entities.Mantenimientos.Salida;
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

            ConsultasAS consultasAS = null;
            RetrieveUserXIdReq oRetUsuarioReq = null;
            RetrieveUserXIdRes oRetUsuarioRes = null;

            MantenimientosAS mantenimientosAS = null;
            SaveUserReq oSaveUsuarioReq = null;
            SaveUserRes oSaveUsuarioRes = null;

            try
            {               
                if (modelo != null)
                {
                    consultasAS = new ConsultasAS();
                    oRetUsuarioReq = new RetrieveUserXIdReq();
                    oRetUsuarioReq.id = modelo.id;
                    oRetUsuarioRes = consultasAS.RetrieveUserXId(oRetUsuarioReq);

                    if (oRetUsuarioRes != null && oRetUsuarioRes.User != null)
                    {
                        if (oRetUsuarioRes.User.Count > 0)
                        {
                            modelo.user_id = oRetUsuarioRes.User[0].user_id;

                            return Json(new { respuesta = respuesta, resultado = modelo });
                        }
                        else
                        {
                            mantenimientosAS = new MantenimientosAS();
                            oSaveUsuarioReq = new SaveUserReq();    
                            oSaveUsuarioReq.user_id = Guid.NewGuid();
                            oSaveUsuarioReq.display_name = modelo.display_name;
                            oSaveUsuarioReq.email = modelo.email;
                            oSaveUsuarioReq.spotify_url = modelo.spotify_url;
                            oSaveUsuarioReq.href = modelo.href;
                            oSaveUsuarioReq.id = modelo.id;

                            oSaveUsuarioRes = mantenimientosAS.SaveUser(oSaveUsuarioReq);

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
    }
}