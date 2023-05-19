using System.ComponentModel.DataAnnotations;

namespace TraversalCoreUI.Models.LoginVM
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfen Kuıllanıcı Adını Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }

    }
}
