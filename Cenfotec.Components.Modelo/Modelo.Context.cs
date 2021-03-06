﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cenfotec.Components.Modelo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class components_bdEntities : DbContext
    {
        public components_bdEntities()
            : base("name=components_bdEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int PA_SAVE_USER(Nullable<System.Guid> user_id, string display_name, string email, string spotify_url, string href, string id, ObjectParameter eSTADO, ObjectParameter mENSAJE)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(System.Guid));
    
            var display_nameParameter = display_name != null ?
                new ObjectParameter("display_name", display_name) :
                new ObjectParameter("display_name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var spotify_urlParameter = spotify_url != null ?
                new ObjectParameter("spotify_url", spotify_url) :
                new ObjectParameter("spotify_url", typeof(string));
    
            var hrefParameter = href != null ?
                new ObjectParameter("href", href) :
                new ObjectParameter("href", typeof(string));
    
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_SAVE_USER", user_idParameter, display_nameParameter, emailParameter, spotify_urlParameter, hrefParameter, idParameter, eSTADO, mENSAJE);
        }
    
        public virtual int PA_SAVE_TRACK_X_USER(Nullable<System.Guid> id_user, string track_id, ObjectParameter eSTADO, ObjectParameter mENSAJE)
        {
            var id_userParameter = id_user.HasValue ?
                new ObjectParameter("id_user", id_user) :
                new ObjectParameter("id_user", typeof(System.Guid));
    
            var track_idParameter = track_id != null ?
                new ObjectParameter("track_id", track_id) :
                new ObjectParameter("track_id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_SAVE_TRACK_X_USER", id_userParameter, track_idParameter, eSTADO, mENSAJE);
        }
    
        public virtual int PA_SAVE_TRACK(Nullable<System.Guid> track_id, string name, string spotify_url, string href, string id, string preview_url, string uri, string image_url, ObjectParameter eSTADO, ObjectParameter mENSAJE)
        {
            var track_idParameter = track_id.HasValue ?
                new ObjectParameter("track_id", track_id) :
                new ObjectParameter("track_id", typeof(System.Guid));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var spotify_urlParameter = spotify_url != null ?
                new ObjectParameter("spotify_url", spotify_url) :
                new ObjectParameter("spotify_url", typeof(string));
    
            var hrefParameter = href != null ?
                new ObjectParameter("href", href) :
                new ObjectParameter("href", typeof(string));
    
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var preview_urlParameter = preview_url != null ?
                new ObjectParameter("preview_url", preview_url) :
                new ObjectParameter("preview_url", typeof(string));
    
            var uriParameter = uri != null ?
                new ObjectParameter("uri", uri) :
                new ObjectParameter("uri", typeof(string));
    
            var image_urlParameter = image_url != null ?
                new ObjectParameter("image_url", image_url) :
                new ObjectParameter("image_url", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_SAVE_TRACK", track_idParameter, nameParameter, spotify_urlParameter, hrefParameter, idParameter, preview_urlParameter, uriParameter, image_urlParameter, eSTADO, mENSAJE);
        }
    
        public virtual ObjectResult<PA_RET_TRACK_X_ID_Result> PA_RET_TRACK_X_ID(string id, ObjectParameter eSTADO, ObjectParameter mENSAJE)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PA_RET_TRACK_X_ID_Result>("PA_RET_TRACK_X_ID", idParameter, eSTADO, mENSAJE);
        }
    
        public virtual ObjectResult<PA_RET_TRACK_X_USER_Result> PA_RET_TRACK_X_USER(Nullable<System.Guid> id_user, string track_id, ObjectParameter eSTADO, ObjectParameter mENSAJE)
        {
            var id_userParameter = id_user.HasValue ?
                new ObjectParameter("id_user", id_user) :
                new ObjectParameter("id_user", typeof(System.Guid));
    
            var track_idParameter = track_id != null ?
                new ObjectParameter("track_id", track_id) :
                new ObjectParameter("track_id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PA_RET_TRACK_X_USER_Result>("PA_RET_TRACK_X_USER", id_userParameter, track_idParameter, eSTADO, mENSAJE);
        }
    
        public virtual ObjectResult<PA_RET_USER_X_ID_Result> PA_RET_USER_X_ID(string id, ObjectParameter eSTADO, ObjectParameter mENSAJE)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PA_RET_USER_X_ID_Result>("PA_RET_USER_X_ID", idParameter, eSTADO, mENSAJE);
        }
    
        public virtual ObjectResult<PA_RET_TRACKS_SAVED_BY_USER_Result> PA_RET_TRACKS_SAVED_BY_USER(Nullable<System.Guid> id_user, ObjectParameter eSTADO, ObjectParameter mENSAJE)
        {
            var id_userParameter = id_user.HasValue ?
                new ObjectParameter("id_user", id_user) :
                new ObjectParameter("id_user", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PA_RET_TRACKS_SAVED_BY_USER_Result>("PA_RET_TRACKS_SAVED_BY_USER", id_userParameter, eSTADO, mENSAJE);
        }
    
        public virtual int PA_DEL_TRACK_X_USER(string track_id, Nullable<System.Guid> user_id, ObjectParameter eSTADO, ObjectParameter mENSAJE)
        {
            var track_idParameter = track_id != null ?
                new ObjectParameter("track_id", track_id) :
                new ObjectParameter("track_id", typeof(string));
    
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PA_DEL_TRACK_X_USER", track_idParameter, user_idParameter, eSTADO, mENSAJE);
        }
    }
}
