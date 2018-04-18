﻿using Cenfotec.Components.Entities.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotec.Components.Entities.Consultas.Entrada
{
    [DataContract]
    public class RetrieveTrackXIdReq : EntradaBase
    {
        [DataMember]
        public string id { get; set; }
    }
}
