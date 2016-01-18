using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using Text2PNG.Utilities;

namespace Text2PNG
{
    /// <summary>
    /// This handler is called whenever a file ending in .img is
    /// requested. A file with that extension does not need to exist
    /// </summary>
    public class ImgHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var text = request.Params.Get("text");
            text = (text == null) ? String.Empty : text;

            context.Response.ContentType = "image/png";

            var image = ImageFactory.CreateBitmapImage(text);
            image.Save(context.Response.OutputStream, ImageFormat.Png);

        }
    }
}