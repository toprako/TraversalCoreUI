﻿using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AnnouncementValidatorRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen Başlık İçeriğini Boş Geçmeyiniz.!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen Duyuru İçeriğini Boş Geçmeyiniz.!");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Veri Girişi Yapınız.!");
            RuleFor(x => x.Content).MinimumLength(20).WithMessage("Lütfen En Az 20 Karakter Veri Girişi Yapınız.!");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Veri Girişi Yapınız.!");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Lütfen En Fazla 500 Karakter Veri Girişi Yapınız.!");
        }
    }
}
