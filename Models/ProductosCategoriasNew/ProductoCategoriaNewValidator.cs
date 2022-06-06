using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProductosCategoriasNew
{
    public class ProductoCategoriaNewValidator : AbstractValidator<ProductoCategoriaNew>
    {
        public ProductoCategoriaNewValidator()
        {
            RuleFor(ProductoCategoriaNew => ProductoCategoriaNew.id_usuario).NotNull().NotEmpty().WithMessage("El producto categoria no se puede registrar sin identificador de usuario.");
            RuleFor(ProductoCategoriaNew => ProductoCategoriaNew.nombre).NotNull().NotEmpty().WithMessage("El producto categoria no se puede registrar sin nombre.");

        }
    }
}
