using Cenfotec.Components.Entities.Mantenimientos.Entrada;
using Cenfotec.Components.Entities.Mantenimientos.Salida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Cenfotec.Components.WS
{
    [ServiceContract]
    public interface IMantenimientosWCF
    {
        [OperationContract]
        SaveUserRes SaveUser(SaveUserReq oReq);
    }
}
