using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.Web.V2.Helpers
{
    public class ImageHelper
    {
        private static AppSettingsReader app = new AppSettingsReader();

        public static string CaminhoImagem()
        {
            return app.GetValue("Imagem", typeof (String)).ToString();
        }
    }
}