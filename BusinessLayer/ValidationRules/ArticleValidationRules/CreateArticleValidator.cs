using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ArticleValidationRules
{
    public class CreateArticleValidator : AbstractValidator<Article>
    {
        public CreateArticleValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori boş bırakılamaz!");
            
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel boş bırakılamaz!");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz!");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalı!");

            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş bırakılamaz!");
            RuleFor(x => x.Content).MinimumLength(3).WithMessage("İçerik en az 3 karakter olmalı!");
        }
    }
}
