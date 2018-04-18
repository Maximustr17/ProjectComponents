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
    public class SaveTrackReq : EntradaBase
    {
        [DataMember]
        public Guid track_id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string spotify_url { get; set; }

        [DataMember]
        public string href { get; set; }

        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string preview_url { get; set; }

        [DataMember]
        public string uri { get; set; }
    }
}


