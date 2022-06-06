using Models;
using Models.Common;
using Models.Enum;
using Models.ProductosNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;

namespace Services.ProductosNew
{
    public class ProductoNewServices
    {
        private readonly IUnitOfWork _uniOfWork;
        public ValidationsFluent ValidationResult { get; }
        public ProductoNewServices(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        /// <summary>
        /// Crea un Producto
        /// </summary>
        /// <param name="_productoNew">
        /// Objeto de tipo ProductoNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Create(ProductoNew _productoNew)
        {
            try
            {
                ProductoNewValidator ProductValidator = new ProductoNewValidator();
                ValidationResult.Validation = ProductValidator.Validate(_productoNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create()) { result = context.Repository.ProductoNewRepository.Create(_productoNew); context.SaveChange(); }
                    if (result > 0)
                    { 
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok;
                        ValidationResult.Message = "Producto registrado correctamente.";
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
        /// Obtiene un ProductoNew existente en la BBDD por el id
        /// </summary>
        /// <param name="_idProduct">
        /// ID del ProductoNew
        /// </param>
        /// <returns>Retorna un ProductoNew</returns>
        public ProductoNew GetById(int _idProduct)
        {
            ProductoNew producto = new ProductoNew();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    producto = context.Repository.ProductoNewRepository.GetById(_idProduct);
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
        /// Obtiene una lista de todos los ProductoNew existentes en la BBDD
        /// </summary>
        /// <returns>
        /// Devuelve un objeto lista de tipo ProductoNew con todos sus Datos
        /// </returns>
        private List<ProductoNew> GetAll()
        {
            try
            {
                List<ProductoNew> productList = new List<ProductoNew>();
                using (var context = _uniOfWork.Create())
                {
                    productList = context.Repository.ProductoNewRepository.GetAll();
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
        /// Obtiene una lista de todos los ProductoNew no eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo ProductoNew con todos sus Datos</returns>
        private List<ProductoNew> GetAllNoEliminados()
        {
            try
            {
                List<ProductoNew> ProductList = new List<ProductoNew>();
                ProductList = GetAll();
                var Result = from ProductoNew in ProductList
                             where ProductoNew.is_eliminado == false
                             select ProductoNew;
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
        /// Obtiene una lista de todos los ProductoNew eliminados existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo ProductoNew con todos sus Datos</returns>
        private List<ProductoNew> GetAllEliminados()
        {
            try
            {
                List<ProductoNew> ProductList = new List<ProductoNew>();
                ProductList = GetAll();
                var Result = from ProductoNew in ProductList
                             where ProductoNew.is_eliminado == true
                             select ProductoNew;
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
        /// Obtiene una lista de todos los ProductoNew. Segun parametro indicado segun enumeracion.
        /// </summary>
        /// <param name="_operacion">Parametro seleccionado</param>
        /// <returns>Devuelve un objeto lista de ProductoNew</returns>
        public List<ProductoNew> GetAll(GetAll.GetAllEnum _operacion)
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
        /// Actualiza el ProductoNew 
        /// </summary>
        /// <param name="_productoNew">
        /// Objeto de tipo ProductoNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Update(ProductoNew _productoNew)
        {

            try
            {
                ProductoNewValidator productValidador = new ProductoNewValidator();
                ValidationResult.Validation = productValidador.Validate(_productoNew);
                if (ValidationResult.Validation.IsValid)
                {
                    int result;
                    using (var context = _uniOfWork.Create())
                    {
                        result=context.Repository.ProductoNewRepository.Update(_productoNew);
                        context.SaveChange();
                    }
                    if (result > 0)
                    { 
                        ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; 
                        ValidationResult.Message = "Producto actualizado correctamente."; 
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
        /// Elimina un ProductoNew
        /// </summary>
        /// <param name="_productoNew">
        /// Objeto de tipo ProductoNew con todos sus atributos completos para ser insertado en la BBDD
        /// </param>
        public void Remove(ProductoNew _productoNew)
        {
            int result = 0;
            try
            {
                ProductoNewValidator validator = new ProductoNewValidator();
                ValidationResult.Validation = validator.Validate(_productoNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _uniOfWork.Create())
                    {
                        result = context.Repository.ProductoNewRepository.Remove(_productoNew.id_producto);
                        context.SaveChange();
                    }
                    if (result > 0) { ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; }
                }
                else {ValidationResult.Status = Models.Enum.Status.StatusEnum.Validation;}
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
        /// <param name="_idProduct">ID del ProductoNew a actualiza</param>
        /// <param name="_isEliminado">parametro a actualizar</param>
        public void UpdateIsEliminado(int _idProduct, Boolean _isEliminado)
        {
            try
            {
                int result = 0;
                using (var context = _uniOfWork.Create())
                {
                    result = context.Repository.ProductoNewRepository.UpdateSoftDelete(_idProduct, _isEliminado);
                    context.SaveChange();
                }
                if (result > 0)
                { ValidationResult.Status = Models.Enum.Status.StatusEnum.Ok; ValidationResult.Message = "Producto eliminado correctamente."; }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
        }
        /// <summary>
        /// Verifica si existe el producto segun el codigo
        /// </summary>
        /// <param name="_codigo">codigo del producto</param>
        /// <returns>retorna true si existe el producto</returns>
        public Boolean IsExistCodigo(string _codigo)
        {
            try
            {

                using (var context = _uniOfWork.Create())
                {
                    return context.Repository.ProductoNewRepository.IsExistCodigo(_codigo);
                }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return false;
            }
        }
        /// <summary>
        /// Obtiene una lista de todos los ProductoNew segun el codigo existentes en la BBDD
        /// </summary>
        /// <returns>Devuelve un objeto lista de tipo ProductoNew con todos sus Datos</returns>
        public List<ProductoNew> GetbyCodigo(string _codigo)
        {
            try
            {
                List<ProductoNew> productList = new List<ProductoNew>();
                using (var context = _uniOfWork.Create())
                {
                    productList = context.Repository.ProductoNewRepository.GetByCodigo(_codigo);
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
    }
        
}

