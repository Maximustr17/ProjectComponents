using Cenfotec.Components.Entities.Consultas.Salida;
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
        public List<TrackModels> TracksList { get; set; }
        public string src { get; set; }
        #endregion

        #region Métodos
        public void CopyTracksByUser(RetrieveTracksSavedByUserRes tracksByUser)
        {
            TrackModels newTrack = null;
            this.TracksList = new List<TrackModels>();
            try
            {
                if (tracksByUser != null && tracksByUser.Tracks.Count() > 0)
                {
                    foreach (var track in tracksByUser.Tracks)
                    {
                        newTrack = new TrackModels();
                        newTrack.track_id = track.track_id;
                        newTrack.name = track.name;
                        newTrack.spotify_url = track.spotify_url;
                        newTrack.href = track.href;
                        newTrack.id = track.id;
                        newTrack.preview_url = track.preview_url;
                        newTrack.uri = track.uri;
                        newTrack.image_url = track.image_url;
                        newTrack.src = "https://open.spotify.com/embed?uri=" + newTrack.uri;
                        this.TracksList.Add(newTrack);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}