using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inventory.ProductosBodegasNew
{
    public class ProductoBodegaNewValidator : AbstractValidator<ProductoBodegaNew>
    {
        public ProductoBodegaNewValidator()
        {
            RuleFor(ProductoBodegaNew => ProductoBodegaNew.IdProducto).NotNull().WithMessage("El Id del Producto no puede ser nulo");
            RuleFor(ProductoBodegaNew => ProductoBodegaNew.IdBodega).NotNull().WithMessage("El Id de la Bodega no puede ser nulo");
        }
    }
}
