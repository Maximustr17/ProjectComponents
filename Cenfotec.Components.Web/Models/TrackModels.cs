using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cenfotec.Components.Web.Models
{
    [Serializable]
    public class TrackModels
    {
        #region Propiedades
        public Guid track_id { get; set; }
        public string name { get; set; }
        public string spotify_url { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string preview_url { get; set; }
        public string uri { get; set; }
        public string image_url { get; set; }
        public Guid user_id { get; set; }
        #endregion

        #region Métodos

        #endregion
    }
}