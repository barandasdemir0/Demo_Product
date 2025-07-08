using System.ComponentModel.DataAnnotations;

namespace Demo_Product.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Lütfen isim giriniz")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Lütfen Soyadınızı giriniz")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Lütfen cinsiyetinizi giriniz")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Lütfen Mail giriniz")]
        public string EMail { get; set; }


        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Lütfen tekrar şifrenizi giriniz")]
        [Compare("Password", ErrorMessage = "Lütfen Şifreler eşleştiğinden emin olunuz")]
        public string ConfirmPassword { get; set; }
    }
}
