using Cenfotec.Components.Entities.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotec.Components.Entities.Mantenimientos.Entrada
{
    [DataContract]
    public class SaveUserReq : EntradaBase
    {
        [DataMember]
        public Guid user_id { get; set; }

        [DataMember]
        public string display_name { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string spotify_url { get; set; }

        [DataMember]
        public string href { get; set; }

        [DataMember]
        public string id { get; set; }
    }
}


