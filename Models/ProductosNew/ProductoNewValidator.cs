using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProductosNew
{
   public class ProductoNewValidator :AbstractValidator<ProductoNew>
    {
        public ProductoNewValidator() 
        {
            RuleFor(ProductoNew => ProductoNew.id_bodega).NotNull().NotEmpty().WithMessage("El producto no se puede registrar sin identificador de bodega.");
            RuleFor(ProductoNew => ProductoNew.id_proveedor).NotNull().NotEmpty().WithMessage("El producto no se puede registrar sin identificador de provedor.");
            RuleFor(ProductoNew => ProductoNew.id_proveedor).NotNull().NotEmpty().WithMessage("El producto no se puede registrar sin identificador de estado.");
            RuleFor(ProductoNew => ProductoNew.id_categoria_producto).NotNull().NotEmpty().WithMessage("El producto no se puede registrar sin categoria de bodega.");
            RuleFor(ProductoNew => ProductoNew.codigo).NotNull().NotEmpty().WithMessage("El producto no se puede registrar sin el codigo.");
        }
    }
}
