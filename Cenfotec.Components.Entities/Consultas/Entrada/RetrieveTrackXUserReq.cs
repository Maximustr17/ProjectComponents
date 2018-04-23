using Cenfotec.Components.Entities.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotec.Components.Entities.Consultas.Entrada
{
    [DataContract]
    public class RetrieveTrackXUserReq : EntradaBase
    {
        [DataMember]
        public Guid id_user { get; set; }

        [DataMember]
        public string track_id { get; set; }   
    }
}
