using Models;
using Models.Common;
using Models.Enum;
using Models.ProductosKitsNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;

namespace Services.ProductosKitsNew
{
    public class ProductoKitNewServices
    {
        private readonly IUnitOfWork _uniOfWork;
        public ValidationsFluent ValidationResult { get; }
        public ProductoKitNewServices(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        /// <summary>
        /// Crea un Producto
        /// </summary>
        /// <param name="_ProductoKitNew">
        /// Objeto de tipo ProductoKitNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Create(ProductoKitNew _ProductoKitNew)
        {
            try
            {
                ProductoKitNewValidator ProductValidator = new ProductoKitNewValidator();
                ValidationResult.Validation = ProductValidator.Validate(_ProductoKitNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create()) { result = context.Repository.ProductoKitNewRepository.Create(_ProductoKitNew); context.SaveChange(); }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Producto Kit registrado correctamente.";
                    }
                    return;
                }
                else
                {
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Validation;
                    return;
                }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return;
            }

        }
        /// <summary>
        /// Obtiene un ProductoKitNew existente en la BBDD por el id
        /// </summary>
        /// <param name="_idProduct">
        /// ID del ProductoKitNew
        /// </param>
        /// <returns>Retorna un ProductoKitNew</returns>
        public ProductoKitNew GetById(int _idProduct)
        {
            ProductoKitNew producto = new ProductoKitNew();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    producto = context.Repository.ProductoKitNewRepository.GetById(_idProduct);
                }
                return producto;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los ProductoKitNew existentes en la BBDD
        /// </summary>
        /// <returns>
        /// Devuelve un objeto lista de tipo ProductoKitNew con todos sus Datos
        /// </returns>
        private List<ProductoKitNew> GetAll()
        {
            try
            {
                List<ProductoKitNew> productList = new List<ProductoKitNew>();
                using (var context = _uniOfWork.Create())
                {
                    productList = context.Repository.ProductoKitNewRepository.GetAll();
                }
                return productList;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los ProductoKitNew no eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo ProductoKitNew con todos sus Datos</returns>
        private List<ProductoKitNew> GetAllNoEliminados()
        {
            try
            {
                List<ProductoKitNew> ProductList = new List<ProductoKitNew>();
                ProductList = GetAll();
                var Result = from ProductoKitNew in ProductList
                             where ProductoKitNew.isEliminado == false
                             select ProductoKitNew;
                return Result.ToList();
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los ProductoKitNew eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo ProductoKitNew con todos sus Datos</returns>
        private List<ProductoKitNew> GetAllEliminados()
        {
            try
            {
                List<ProductoKitNew> ProductList = new List<ProductoKitNew>();
                ProductList = GetAll();
                var Result = from ProductoKitNew in ProductList
                             where ProductoKitNew.isEliminado == true
                             select ProductoKitNew;
                return Result.ToList();
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los ProductoKitNew. Segun parametro indicado segun enumeracion.
        /// </summary>
        /// <param name="_operacion">Parametro seleccionado</param>
        /// <returns>Devuelve un objeto lista de ProductoKitNew</returns>
        public List<ProductoKitNew> GetAll(GetAll.GetAllEnum _operacion)
        {
            try
            {
                switch (_operacion)
                {
                    case Models.Enum.GetAll.GetAllEnum.NoEliminados:
                        return GetAllNoEliminados();
                    case Models.Enum.GetAll.GetAllEnum.Eliminados:
                        return GetAllEliminados();
                    case Models.Enum.GetAll.GetAllEnum.Todos:
                        return GetAll();
                    default:
                        return null;
                }

            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Actualiza el ProductoKitNew 
        /// </summary>
        /// <param name="_ProductoKitNew">
        /// Objeto de tipo ProductoKitNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Update(ProductoKitNew _ProductoKitNew)
        {

            try
            {
                ProductoKitNewValidator productValidador = new ProductoKitNewValidator();
                ValidationResult.Validation = productValidador.Validate(_ProductoKitNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.ProductoKitNewRepository.Update(_ProductoKitNew);
                        context.SaveChange();
                    }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Producto Kit actualizado correctamente.";
                    }

                }
                else
                {
                    ValidationResult.Status = Models.Enum.Status.StatusEnum.Validation;
                    return;
                }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }

        }
        /// <summary>
        /// Elimina un ProductoKitNew
        /// </summary>
        /// <param name="_ProductoKitNew">
        /// Objeto de tipo ProductoKitNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Remove(ProductoKitNew _ProductoKitNew)
        {
            int result = 0;
            try
            {
                ProductoKitNewValidator validator = new ProductoKitNewValidator();
                ValidationResult.Validation = validator.Validate(_ProductoKitNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.ProductoKitNewRepository.Remove(_ProductoKitNew.idProductoKit);
                        context.SaveChange();
                    }
                    if (result > 0) { ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; }
                }
                else { ValidationResult.Status = Models.Enum.Status.StatusEnum.Validation; }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }
        /// <summary>
        /// Actualiza el campo is_eliminado de la base de datos.
        /// </summary>
        /// <param name="_idProduct">ID del ProductoKitNew a actualiza</param>
        /// <param name="_isEliminado">parametro a actualizar</param>
        public void UpdateIsEliminado(int _idProduct, Boolean _isEliminado)
        {
            try
            {
                int result = 0;
                using (var context = _uniOfWork.Create())
                {
                    result = context.Repository.ProductoKitNewRepository.UpdateSoftDelete(_idProduct, _isEliminado);
                    context.SaveChange();
                }
                if (result > 0)
                { ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; ValidationResult.Message = "Producto Kit eliminado correctamente."; }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }

    }
}
