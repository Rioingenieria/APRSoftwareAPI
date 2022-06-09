using FluentValidation;
using Models.ProductosCategoriasNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProductosKitsNew
{
    public class ProductoKitNewValidator: AbstractValidator<ProductoKitNew>
    {
        public ProductoKitNewValidator()
        {
            RuleFor(ProductoKitNew => ProductoKitNew.idProducto).NotNull().NotEmpty().WithMessage("El producto kit no se puede registrar sin identificador de producto.");
            RuleFor(ProductoKitNew => ProductoKitNew.idKit).NotNull().NotEmpty().WithMessage("El producto kit no se puede registrar sin identificador de kit.");
        }
    }
}
