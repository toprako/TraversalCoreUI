﻿
using System.ComponentModel.DataAnnotations;

namespace TraversalCoreUI.Models.LoginVM
{
	public class UserRegisterViewModel
	{
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Name{ get; set; }

		[Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
		public string Surname{ get; set; }

		[Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Lütfen Mail Adresini Giriniz")]
		public string Mail { get; set; }

		[Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz")]
		[Compare("Password", ErrorMessage = "Şifreler Uyumlu Değil ! ")]
		public string ConfirmPassword { get; set; }
	}
}
