using Models;
using Models.Common;
using Models.Enum;
using Models.ProductosCategoriasNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;

namespace Services.ProductosCategoriasNew
{
    public class ProductoCategoriaNewServices
    {
        private readonly IUnitOfWork _uniOfWork;
        public ValidationsFluent ValidationResult { get; }
        public ProductoCategoriaNewServices(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        /// <summary>
        /// Crea un Producto categoria
        /// </summary>
        /// <param name="_productoCategoriaNew">
        /// Objeto de tipo ProductoCategoriaNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Create(ProductoCategoriaNew _productoCategoriaNew)
        {
            try
            {
                ProductoCategoriaNewValidator ProductValidator = new ProductoCategoriaNewValidator();
                ValidationResult.Validation = ProductValidator.Validate(_productoCategoriaNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create()) { result = context.Repository.ProductoCategoriaNewRepository.Create(_productoCategoriaNew); context.SaveChange(); }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Producto categoria registrado correctamente.";
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
        /// Obtiene un ProductoCategoriaNew existente en la BBDD por el id
        /// </summary>
        /// <param name="_idProductCategoria">
        /// ID del ProductoNew
        /// </param>
        /// <returns>Retorna un ProductoCategoriaNew</returns>
        public ProductoCategoriaNew GetById(int _idProductCategoria)
        {
            ProductoCategoriaNew config = new ProductoCategoriaNew();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    config = context.Repository.ProductoCategoriaNewRepository.GetById(_idProductCategoria);
                }
                return config;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los ProductoCategoriaNew existentes en la BBDD
        /// </summary>
        /// <returns>
        /// Devuelve un objeto lista de tipo ProductoCategoriaNew con todos sus Datos
        /// </returns>
        private List<ProductoCategoriaNew> GetAll()
        {
            try
            {
                List<ProductoCategoriaNew> productCategoriaList = new List<ProductoCategoriaNew>();
                using (var context = _uniOfWork.Create())
                {
                    productCategoriaList = context.Repository.ProductoCategoriaNewRepository.GetAll();
                }
                return productCategoriaList;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los ProductoCategoriaNew no eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo ProductoCategoriaNew con todos sus Datos</returns>
        private List<ProductoCategoriaNew> GetAllNoEliminados()
        {
            try
            {
                List<ProductoCategoriaNew> ProductCategoriaList = new List<ProductoCategoriaNew>();
                ProductCategoriaList = GetAll();
                var Result = from ProductoCategoriaNew in ProductCategoriaList
                             where ProductoCategoriaNew.is_eliminado == false
                             select ProductoCategoriaNew;
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
        /// Obtiene una lista de todos los ProductoCategoriaNew eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo ProductoNew con todos sus Datos</returns>
        private List<ProductoCategoriaNew> GetAllEliminados()
        {
            try
            {
                List<ProductoCategoriaNew> ProductCategoriaList = new List<ProductoCategoriaNew>();
                ProductCategoriaList = GetAll();
                var Result = from ProductoCategoriaNew in ProductCategoriaList
                             where ProductoCategoriaNew.is_eliminado == true
                             select ProductoCategoriaNew;
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
        /// Obtiene una lista de todos los ProductoCategoriaNew. Segun parametro indicado segun enumeracion.
        /// </summary>
        /// <param name="_operacion">Parametro seleccionado</param>
        /// <returns>Devuelve un objeto lista de ProductoCategoriaNew</returns>
        public List<ProductoCategoriaNew> GetAll(GetAll.GetAllEnum _operacion)
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
        /// Actualiza el ProductoCategoriaNew 
        /// </summary>
        /// <param name="_productoCategoriaNew">
        /// Objeto de tipo ProductoCategoriaNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Update(ProductoCategoriaNew _productoCategoriaNew)
        {
            try
            {
                ProductoCategoriaNewValidator productValidador = new ProductoCategoriaNewValidator();
                ValidationResult.Validation = productValidador.Validate(_productoCategoriaNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.ProductoCategoriaNewRepository.Update(_productoCategoriaNew);
                        context.SaveChange();
                    }
                    if (result > 0)
                    {
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Producto categoria actualizado correctamente.";
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
        /// Elimina un ProductoCategoriaNew
        /// </summary>
        /// <param name="_productoCategoriaNew">
        /// Objeto de tipo ProductoCategoriaNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Remove(ProductoCategoriaNew _productoCategoriaNew)
        {
            int result = 0;
            try
            {
                ProductoCategoriaNewValidator validator = new ProductoCategoriaNewValidator();
                ValidationResult.Validation = validator.Validate(_productoCategoriaNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.ProductoCategoriaNewRepository.Remove(_productoCategoriaNew.id_producto_categoria);
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
        /// <param name="_idProduct">ID del ProductoCategoriaNew a actualiza</param>
        /// <param name="_isEliminado">parametro a actualizar</param>
        public void UpdateIsEliminado(int _idProduct, Boolean _isEliminado)
        {
            try
            {
                int result = 0;
                using (var context = _uniOfWork.Create())
                {
                    result = context.Repository.ProductoCategoriaNewRepository.UpdateSoftDelete(_idProduct, _isEliminado);
                    context.SaveChange();
                }
                if (result > 0)
                { ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; ValidationResult.Message = "Producto Categoria eliminado correctamente."; }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }
    }
}
