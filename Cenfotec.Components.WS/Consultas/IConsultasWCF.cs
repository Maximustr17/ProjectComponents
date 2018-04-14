using Cenfotec.Components.Entities.Consultas.Entrada;
using Cenfotec.Components.Entities.Consultas.Salida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Cenfotec.Components.WS.Consultas
{
    [ServiceContract]
    public interface IConsultasWCF
    {
        [OperationContract]
        RetrieveUserXIdRes RetrieveUserXId(RetrieveUserXIdReq oReq);
    }
}
