using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ControlEscuela.Web.Helpers
{
    public static class UtilidadesMvc
    {
        public static byte[] PostedFileBaseToBytes(HttpPostedFileBase file)
        {
            MemoryStream target = new MemoryStream();
            file.InputStream.CopyTo(target);
            return target.ToArray();
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static byte[] BmpToBytes(this Bitmap bmp, ImageFormat formato)
        {
            using (var memoryStream = new MemoryStream())
            {
                bmp.Save(memoryStream, formato);
                return memoryStream.ToArray();
            }
        }

        public static MvcHtmlString ReturnUrlVal(this HtmlHelper html, string elemento)
        {
            var tag = new TagBuilder("input");
            tag.MergeAttribute("type", "hidden");
            tag.MergeAttribute("name", elemento);
            string returnVal = html.ViewContext.RequestContext.HttpContext.Request.QueryString["ReturnUrl"];
            tag.MergeAttribute("value", returnVal);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));
        }

        public static string RenderPartialToString(this ControllerContext controllerContext, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = controllerContext.RouteData.GetRequiredString("action");
            ViewDataDictionary viewData = new ViewDataDictionary();
            TempDataDictionary tempData = new TempDataDictionary();
            viewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                ViewContext viewContext = new ViewContext(controllerContext, viewResult.View, viewData, tempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }

        }

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }

        public static byte[] GetPassEncrypt(string passTexto)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            UTF8Encoding enc = new UTF8Encoding();
            byte[] hashed = md5.ComputeHash(enc.GetBytes(passTexto));
            return hashed;
        }
    }
}