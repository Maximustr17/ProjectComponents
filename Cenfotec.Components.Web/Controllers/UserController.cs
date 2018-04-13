using Cenfotec.Components.AS.Mantenimientos;
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
            string respuesta = "99";

            MantenimientosAS mantenimientosAS = null;
            SaveUserReq oReq = new SaveUserReq();
            SaveUserRes oRes = null;

            try
            {               
                if (modelo != null)
                {
                    
                }
            }

            catch (Exception ex)
            {

            }

            return Json(new { respuesta = "00" });
        }
    }
}