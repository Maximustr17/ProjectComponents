using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cenfotec.Components.Web.Models
{
    [Serializable]
    public class UserModels
    {
        #region Propiedades
        public Guid user_id { get; set; }
        public string display_name { get; set; }
        public string email { get; set; }
        public string spotify_url { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        #endregion

        #region Métodos

        #endregion
    }
}