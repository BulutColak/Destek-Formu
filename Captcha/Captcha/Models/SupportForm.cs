using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Captcha.Models
{
    public class SupportForm
    {
        [Required(ErrorMessage = "Ad soyad boş geçilemez.")]
        [RegularExpression(@"[A-z^şŞıİçÇöÖüÜĞğ\s]*", ErrorMessage = "Lütfen geçerli bir ad soyad giriniz")]
        [DisplayName("Ad Soyad")]
        [DataType(DataType.Text)]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "E-posta boş geçilemez.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz")]
        [DisplayName("E-Posta Adresi")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cep telefonu boş geçilemez.")]
        [RegularExpression(@"5[0-9]{2}[0-9]{7}", ErrorMessage = "Lütfen geçerli bir cep telefonu giriniz")]
        [DisplayName("Cep Telefonu")]
        [DataType(DataType.PhoneNumber)]
        public string MobilPhone { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Lütfen geçerli bir kullanıcı adı giriniz")]
        [DisplayName("Kullanıcı Adı")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [DisplayName("Hata Kodu")]
        [DataType(DataType.Text)]
        public string ErrorCode { get; set; }

        //  [RegularExpression(@"^([a-zA-Z\s\ö\ç\ş\ı\ğ\ü\Ö\Ç\Ş\İ\Ğ\Ü]+)$", ErrorMessage = "Lütfen sadece harf girişi yapınız.")]
        [DisplayName("Ülke")]
        [DataType(DataType.Text)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Açıklama boş geçilemez.")]
        [DisplayName("Açıklama")]
        [DataType(DataType.Text)]
        public string ErrorDescription { get; set; }
        public string Captcha { get; set; }
    }
}