using Cenfotec.Components.Entities.Consultas.Entrada;
using Cenfotec.Components.Entities.Consultas.Salida;
using Cenfotec.Components.Entities.Mantenimientos.Entrada;
using Cenfotec.Components.Entities.Mantenimientos.Salida;
using Cenfotec.Components.LN.Consultas;
using Cenfotec.Components.LN.Mantenimientos;
using Cenfotec.Components.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Cenfotec.Components.Web.Controllers
{
    public class UserController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveUser(UserModels modelo)
        {
            string respuesta = "00";

            ConsultasLN consultasLN = null;
            RetrieveUserXIdReq oRetUsuarioReq = null;
            RetrieveUserXIdRes oRetUsuarioRes = null;

            MantenimientosLN mantenimientosLN = null;
            SaveUserReq oSaveUsuarioReq = null;
            SaveUserRes oSaveUsuarioRes = null;

            try
            {               
                if (modelo != null)
                {
                    consultasLN = new ConsultasLN();
                    oRetUsuarioReq = new RetrieveUserXIdReq();
                    oRetUsuarioReq.id = modelo.id;
                    oRetUsuarioRes = consultasLN.RetrieveUserXId(oRetUsuarioReq);

                    if (oRetUsuarioRes != null && oRetUsuarioRes.User != null)
                    {
                        if (oRetUsuarioRes.User.Count > 0)
                        {
                            modelo.user_id = oRetUsuarioRes.User[0].user_id;

                            return Json(new { respuesta = respuesta, resultado = modelo });
                        }
                        else
                        {
                            mantenimientosLN = new MantenimientosLN();
                            oSaveUsuarioReq = new SaveUserReq();    
                            oSaveUsuarioReq.user_id = Guid.NewGuid();
                            oSaveUsuarioReq.display_name = modelo.display_name != null ? modelo.display_name : "";
                            oSaveUsuarioReq.email = modelo.email != null ? modelo.email : "";
                            oSaveUsuarioReq.spotify_url = modelo.spotify_url != null ? modelo.spotify_url : "";
                            oSaveUsuarioReq.href = modelo.href != null ? modelo.href : "";
                            oSaveUsuarioReq.id = modelo.id;

                            oSaveUsuarioRes = mantenimientosLN.SaveUser(oSaveUsuarioReq);

                            if (oSaveUsuarioRes != null && oSaveUsuarioRes.estado.Equals("00"))
                            {
                                modelo.user_id = oSaveUsuarioReq.user_id;
                                return Json(new { respuesta = respuesta, resultado = modelo });
                            }
                            else
                            {
                                return Json(new { respuesta = "99" });
                            }
                        }
                    }
                    else
                    {
                        return Json(new { respuesta = "99" });
                    }
                }
            }

            catch (Exception ex)
            {

            }

            return Json(new { respuesta = "00" });
        }

        [HttpPost]
        public ActionResult SaveTrack(TrackModels modelo)
        {
            string respuesta = "00";

            ConsultasLN consultasLN = new ConsultasLN();
            MantenimientosLN mantenimientosLN = new MantenimientosLN(); ;

            RetrieveTrackXIdReq oRetTrackReq = null;
            RetrieveTrackXIdRes oRetTrackRes = null;

            SaveTrackReq oSaveTrackReq = null;
            SaveTrackRes oSaveTrackRes = null;

            RetrieveTrackXUserReq oRetTrackXUserReq = null;
            RetrieveTrackXUserRes oRetTrackXUserRes = null;

            SaveTrackXUserReq oSaveTrackXUserReq = null;
            SaveTrackXUserRes oSaveTrackXUserRes = null;

            try
            {
                if (modelo != null)
                {
                    oRetTrackReq = new RetrieveTrackXIdReq();
                    oRetTrackReq.id = modelo.id;
                    //Consulta si la canción se encuentra en la base de datos
                    oRetTrackRes = consultasLN.RetrieveTrackXId(oRetTrackReq);

                    if (oRetTrackRes != null && oRetTrackRes.Track != null)
                    {
                        if (oRetTrackRes.Track.Count > 0)
                        {
                            modelo.track_id = oRetTrackRes.Track[0].track_id;
                        }
                        else
                        {
                            oSaveTrackReq = new SaveTrackReq();
                            oSaveTrackReq.track_id = Guid.NewGuid();
                            oSaveTrackReq.name = modelo.name != null ? modelo.name : "";
                            oSaveTrackReq.spotify_url = modelo.spotify_url != null ? modelo.spotify_url : "" ;
                            oSaveTrackReq.href = modelo.href != null ? modelo.href : "";
                            oSaveTrackReq.id = modelo.id;
                            oSaveTrackReq.preview_url = modelo.preview_url != null ? modelo.preview_url : "";
                            oSaveTrackReq.uri = modelo.uri != null ? modelo.uri : "";
                            oSaveTrackReq.image_url = modelo.image_url != null ? modelo.image_url : "";

                            //Si la canción no se encuentra en la base de datos la inserta
                            oSaveTrackRes = mantenimientosLN.SaveTrack(oSaveTrackReq);

                            if (oSaveTrackRes != null && oSaveTrackRes.estado.Equals("00"))
                            {
                                modelo.track_id = oSaveTrackReq.track_id;
                            }
                        }

                        //Consulta si el usuario tiene la canción guardada
                        oRetTrackXUserReq = new RetrieveTrackXUserReq();
                        oRetTrackXUserReq.id_user = modelo.user_id;
                        oRetTrackXUserReq.track_id = modelo.id;

                        oRetTrackXUserRes = consultasLN.RetrieveTrackXUser(oRetTrackXUserReq);

                        if (oRetTrackXUserRes != null && oRetTrackXUserRes.Track != null)
                        {
                            if (oRetTrackXUserRes.Track.Count == 0)
                            {
                                oSaveTrackXUserReq = new SaveTrackXUserReq();
                                oSaveTrackXUserReq.id_user = modelo.user_id;
                                oSaveTrackXUserReq.track_id = modelo.id;

                                oSaveTrackXUserRes = mantenimientosLN.SaveTrackXUser(oSaveTrackXUserReq);
                            }
                        }
                        return Json(new { respuesta = respuesta, resultado = modelo });
                    }
                    else
                    {
                        return Json(new { respuesta = "99" });
                    }
                }
            }

            catch (Exception ex)
            {

            }

            return Json(new { respuesta = "00" });
        }

        public ActionResult VwSongList(string id)
        {
            RetrieveTracksSavedByUserReq oTracksByUserReq = null;
            TrackModels modelo = new TrackModels();
            ConsultasLN consultasLN = new ConsultasLN();
            try
            {
                //Consultar las canciones guardadas por un usuario
                oTracksByUserReq = new RetrieveTracksSavedByUserReq();
                oTracksByUserReq.id_user = !String.IsNullOrEmpty(id) ? Guid.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(id))) : Guid.Empty;
                modelo.user_id = oTracksByUserReq.id_user;
                modelo.CopyTracksByUser(consultasLN.RetrieveTracksSavedByUser(oTracksByUserReq));

            }
            catch (Exception ex)
            {

                throw;
            }

            return View(modelo);
        }

        [HttpPost]
        public ActionResult EnviarCorreo(string correoDestino, string user_id)
        {
            ConsultasLN consultasLN = new ConsultasLN();
            RetrieveTracksSavedByUserReq oTracksByUserReq = null;
            RetrieveTracksSavedByUserRes oTracksByUserRes = null;

            try
            {
                //Consultar las canciones guardadas por un usuario
                oTracksByUserReq = new RetrieveTracksSavedByUserReq();
                oTracksByUserReq.id_user = Guid.Parse(user_id);
                oTracksByUserRes = consultasLN.RetrieveTracksSavedByUser(oTracksByUserReq);

                string correoOrigen = "envio.anuncios.proyecto@gmail.com";
                string contrasenaCorreoActivaciones = "envioanunciosproyecto";
                string servidorSmtp = "smtp.gmail.com";

                MailMessage email = new MailMessage(correoOrigen, correoDestino);
                //opciones de notificación de entrega
                email.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure | DeliveryNotificationOptions.OnSuccess | DeliveryNotificationOptions.Delay;

                /***********Cambiar*************/
                email.Subject = "Su lista de canciones guardadas";
                email.Body = CrearFormatoCorreo(oTracksByUserRes);
                email.IsBodyHtml = true;

                SmtpClient clienteSMTP = new SmtpClient(servidorSmtp);
                clienteSMTP.Port = 587;
                clienteSMTP.EnableSsl = true;
                clienteSMTP.UseDefaultCredentials = false;
                System.Net.NetworkCredential cred = new System.Net.NetworkCredential(correoOrigen, contrasenaCorreoActivaciones);
                clienteSMTP.Credentials = cred;
                clienteSMTP.Send(email);
            }
            catch (Exception)
            {
                throw;
            }
            return Json(new { respuesta = "00" });
        }
        private static string CrearFormatoCorreo(RetrieveTracksSavedByUserRes trackList)
        {
            StringBuilder mensajeCorreo = new StringBuilder();

            mensajeCorreo.AppendLine("<!DOCTYPE html>");
            mensajeCorreo.AppendLine("<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">");
            mensajeCorreo.AppendLine("<head>");
            mensajeCorreo.AppendLine("    <meta content=\"text/html; charset=utf-8\" http-equiv=\"Content-Type\">");
            mensajeCorreo.AppendLine("    <meta name=\"GENERATOR\" content=\"MSHTML 11.00.9600.17924\">");
            mensajeCorreo.AppendLine("</head>");

            mensajeCorreo.AppendLine("<body>");
            mensajeCorreo.AppendLine("<h2 style=\"margin-bottom:20px\">Sus canciones guardadas</h2>");
            mensajeCorreo.AppendLine("<table style=\"border-collapse:collapse; text-align:center;\" >");
            mensajeCorreo.AppendLine("<thead>");
            mensajeCorreo.AppendLine("<tr style =\"background-color:#6FA1D2; color:#ffffff;\">");
            mensajeCorreo.AppendLine("<th>Nombre</th>");
            mensajeCorreo.AppendLine("</tr>");
            mensajeCorreo.AppendLine("</thead>");

            mensajeCorreo.AppendLine("<tbody class=\"table - hover\">");

            foreach (var track in trackList.Tracks)
            {
                mensajeCorreo.AppendLine("<tr style =\"color:#555555;\">");
                mensajeCorreo.AppendLine("<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\"><a target=\"_blank\" href=\"" + track.spotify_url + "\">" + track.name + "</a></td>");
                mensajeCorreo.AppendLine("</tr>");
            }
            mensajeCorreo.AppendLine("</tbody>");

            mensajeCorreo.AppendLine("</table>");

            mensajeCorreo.AppendLine("</body>");
            mensajeCorreo.AppendLine("</html>");
            return mensajeCorreo.ToString();
        }
        public ActionResult vistapueba()
        {
            return View();
        }
    }
}
 