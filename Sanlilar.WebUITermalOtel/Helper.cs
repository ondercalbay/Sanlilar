using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Sanlilar.WebUITermalOtel
{
    public static class Helper
    {
        public enum EnuMesajTuru
        {
            success,
            info,
            danger,
            warning
        }
        public static string GetMesaj(EnuMesajTuru mesajTuru, string baslik, string mesaj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<div class='col-sm-6 col-md-6'>");
            sb.AppendFormat("   <div class='alert alert-{0}'>", mesajTuru);
            sb.AppendFormat("       <button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>");            
            sb.AppendFormat("        <strong>{0}</strong>", baslik);
            sb.AppendFormat("       <hr class='message-inner-separator'>");
            sb.AppendFormat("       <p>{0}</p>", mesaj);
            sb.AppendFormat("   </div>");
            sb.AppendFormat("</div>");

            return sb.ToString();
        }
    }
}