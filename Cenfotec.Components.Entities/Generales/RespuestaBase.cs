using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotec.Components.Entities.Generales
{
    public class RespuestaBase
    {
        #region "Variables"

        private String _Estado = "00";
        private String _Mensaje = "";

        #endregion


        #region "Propiedades"

        [DataMember]
        public String estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        [DataMember]
        public String mensaje
        {
            get { return _Mensaje; }
            set { _Mensaje = value; }
        }

        #endregion

    }
}

