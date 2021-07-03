using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz.");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız.");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Lütfen 50 Karakterden Fazla Değer Girişi Yapmayınız.");
            RuleFor(x => x.UserSurname).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Bilgilerini Boş Geçemezsiniz.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan Bilgilerini Boş Geçemezsiniz.");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("Lütfen Unvan Bilgilerini 50 Karakterden Fazla Değer Girişi Yapmayınız.");
            //RuleFor(x => x.WriterAbout).Must(x => x.Contains("a")).WithMessage("Hakkında kısmında mutlaka 'a' karakteri bulunmalıdır :)");
        }

        //A custom function could used instead of 'x=> x.Contains' 
        //private bool wAboutMustContainA(string arg)   
        //{
        //    return arg.Contains("a");
        //}
    }
}
