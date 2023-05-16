using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Kısmını Boş Geçemezsiniz .!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Kısmı Boş Geçilemez");
            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Lütfen En Az 20 karakterlik Açıklama Bilgisi Giriniz.!");
            RuleFor(x => x.Description).MaximumLength(1500).WithMessage("Açıklama Kısmı Çok Uzun Lütfen 1500 karakteri Geçirmeyiniz!.");
        }
    }
}
