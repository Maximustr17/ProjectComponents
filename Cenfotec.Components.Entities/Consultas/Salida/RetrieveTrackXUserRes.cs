using Cenfotec.Components.Entities.Generales;
using Cenfotec.Components.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotec.Components.Entities.Consultas.Salida
{
    [DataContract]
    public class RetrieveTrackXUserRes : RespuestaBase
    {
        [DataMember]
        public List<PA_RET_TRACK_X_USER_Result> Track { get; set; }
    }
}
