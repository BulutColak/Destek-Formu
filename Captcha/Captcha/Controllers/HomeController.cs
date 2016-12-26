using Captcha.Models;
using DNB.Validation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Captcha.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public void ProcessRequest(HttpContext context)
        {
            // Create a random code and store it in the Session object.
            context.Session["CaptchaImageText"] = GenerateRandomCode();
            // Create a CAPTCHA image using the text stored in the Session object.
            RandomImage ci = new RandomImage(context.Session["CaptchaImageText"].ToString(), 302, 54);
            // Change the response headers to output a JPEG image.
            context.Response.Clear();
            context.Response.ContentType = "image/jpeg";
            // Write the image to the response stream in JPEG format.
            ci.Image.Save(context.Response.OutputStream, ImageFormat.Jpeg);

            // Dispose of the CAPTCHA image object.
            ci.Dispose();
        }

        // Function to generate random string with Random class.
        private string GenerateRandomCode()
        {
            Random r = new Random();
            string s = "";
            for (int j = 0; j < 5; j++)
            {
                int i = r.Next(3);
                int ch;
                switch (i)
                {
                    case 1:
                        ch = r.Next(0, 9);
                        s = s + ch.ToString();
                        break;
                    case 2:
                        ch = r.Next(65, 90);
                        s = s + Convert.ToChar(ch).ToString();
                        break;
                    case 3:
                        ch = r.Next(97, 122);
                        s = s + Convert.ToChar(ch).ToString();
                        break;
                    default:
                        ch = r.Next(97, 122);
                        s = s + Convert.ToChar(ch).ToString();
                        break;
                }
                r.NextDouble();
                r.Next(100, 1999);
            }
            return s;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public string Form(string nameSurname, string userName, string eposta, string mobilPhone, string captcha)
        {
            string code = Session["CaptchaImageText"].ToString();
            StringBuilder resultMessage = new StringBuilder();
            resultMessage.Append("<ul>");
            if (captcha == null || code != captcha)
            {
                resultMessage.Append("<li>Lütfen resimdeki sayıları doğru bir şekilde yazınız.</li>");
            }
            else
            {
               
                InputValidation nesne = new InputValidation();
                if (!nesne.ValidateName(nameSurname))
                {
                    resultMessage.Append("<li>Lütfen ad soyad alanını doğru bir şekilde yazınız.</li>");
                }
                string Design = @"^[a-zA-Z0-9]*$";
                Regex regex = new Regex(Design);
                userName = userName.Replace("ı", "i").Replace("ö", "o").Replace("Ö", "O").Replace("İ", "I").Replace("ç", "c").Replace("Ç", "C").Replace("Ş", "S").Replace("ş", "s").Replace("ğ", "g").Replace("ü", "u").Replace("Ü", "U").Replace(" ", "").Replace(".", "");
                if (!regex.Match(userName).Success)
                {
                    resultMessage.Append("<li>Lütfen kullanıcı adı alanını doğru bir şekilde yazınız.</li>");
                }
                if (!nesne.ValidateEmail(eposta))
                {
                    resultMessage.Append("<li>Lütfen e-posta alanını doğru bir şekilde yazınız.</li>");
                }
                if (!nesne.ValidateMobilPhone(mobilPhone))
                {
                    resultMessage.Append("<li>Lütfen cep telefonu alanını doğru bir şekilde yazınız.</li>");
                }
            }
            resultMessage.Append("</ul>");
            if (resultMessage.ToString() == "<ul></ul>")
            {
                resultMessage.Clear();
            }
            return resultMessage.ToString();
        }
    }
}