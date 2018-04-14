﻿using Cenfotec.Components.Entities.Mantenimientos.Entrada;
using Cenfotec.Components.Entities.Mantenimientos.Salida;
using Cenfotec.Components.LN.Mantenimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Cenfotec.Components.WS
{
    public class MantenimientosWCF : IMantenimientosWCF
    {
        public SaveUserRes SaveUser(SaveUserReq oReq)
        {
            MantenimientosLN mantenimientosLN = new MantenimientosLN();
            SaveUserRes oRes = new SaveUserRes();
            try
            {
                oRes = mantenimientosLN.SaveUser(oReq);
            }
            catch (Exception ex)
            {
                oRes.estado = "99";
                oRes.mensaje = "MENSAJE_ERROR_WCF " + ex.ToString() + ((ex.InnerException != null) ? Environment.NewLine + ex.InnerException.Message : string.Empty);
            }
            finally
            {
                //Liberamos la memoria
                mantenimientosLN = null;
            }
            return oRes;
        }
    }
}
