using MailKit.Net.Smtp;

using MimeKit;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Reflection.Metadata;

namespace Dealer.API.Correos
{
    public class Emails
    {
        private string Micorreo = "franchelisrd@gmail.com";
        private string Clave = "sxxp oirx dhki ykqg";
        public string CorreoTH { get; set; }
        const string server = "smtp.gmail.com";
        const int puerto = 587;
        //public DateOnly Desde {  get; set; }    
        //    public DateOnly Hasta { get; set; } 
         public BodyBuilder BodyBuilder;
        //public Emails()
        //{
        //    this.Hasta = Hasta; this.Desde = Desde; this.CorreoTH = correo;
        //    BodyBuilder.HtmlBody = $"    <h1>Estimado(a)s {nombreth} </h1>\r\n    <br />\r\n    <br />\r\n    <h3>Haz Transaccionado por el alquiler de un vehiculo ({Marca} {Modelo}) Desde {Desde} Hasta {Hasta}</h3>\r\n    <br />\r\n    <br />\r\n    <h4>Espero que lo disfrutes!</h4><br />\r\n    <h5>Saludos Cordiales!</h5><br />\r\n    <h6>Dealer Franchelis</h6>";
        //}

        


        public async Task Enviar(string correo, string nombreth, string Marca, string Modelo, DateOnly Desde, DateOnly Hasta)
        {
            try
            {
                BodyBuilder = new();
                this.CorreoTH = correo;
                BodyBuilder.HtmlBody = $"    <h1>Estimado(a)s {nombreth} </h1>\r\n    <br />\r\n    <br />\r\n    <h3>Haz Transaccionado por el alquiler de un vehiculo ({Marca} {Modelo}) Desde {Desde} Hasta {Hasta}</h3>\r\n    <br />\r\n    <br />\r\n    <h4>Espero que lo disfrutes!</h4><br />\r\n    <h5>Saludos Cordiales!</h5><br />\r\n    <h6>Dealer Franchelis</h6>";
              
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("Dealer Franchelis", Micorreo));
                message.To.Add(new MailboxAddress(nombreth, CorreoTH));
                message.Body = this.BodyBuilder.ToMessageBody();

                SmtpClient smtp = new SmtpClient();
                smtp.CheckCertificateRevocation = false;
                await smtp.ConnectAsync(server, puerto, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(this.Micorreo, this.Clave);
                smtp.Send(message);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex) {
                Console.Clear();
                Console.WriteLine(ex);
            }
        }

    }
}
