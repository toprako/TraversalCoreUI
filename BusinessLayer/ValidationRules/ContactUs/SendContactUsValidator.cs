﻿using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Alanı Boş Geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu Alanı En Az 5 Karakter Olmalıdır.!");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu Alanı En Fazla 100 Karakter Olmalıdır.!");
            RuleFor(x => x.Email).MinimumLength(5).WithMessage("Mail Alanı En Az 5 Karakter Olmalıdır.!");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("Mail Alanı En Fazla 100 Karakter Olmalıdır.!");
        }
    }
}
