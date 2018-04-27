using Cenfotec.Components.Entities.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotec.Components.Entities.Mantenimientos.Entrada
{
    public class DeleteTrackByUserReq : EntradaBase
    {
        [DataMember]
        public string track_id { get; set; }

        [DataMember]
        public Guid user_id { get; set; }
    }
}
