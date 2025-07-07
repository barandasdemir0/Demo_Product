using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün Adını Boş geçemezsiniz");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stok Boş geçemezsiniz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat Boş geçemezsiniz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır");
        }
    }
}
