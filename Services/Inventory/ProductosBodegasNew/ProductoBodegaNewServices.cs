using Models;
using Models.Common;
using Models.Inventory.ProductosBodegasNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.IUnitOfWorkInventario;
using static Models.Enum.Status;

namespace Services.Inventory.ProductosBodegasNew
{
    public class ProductoBodegaNewServices
    {
        private readonly IUnitOfWorkInventario _unitOfWork;
        public ValidationsFluent ValidationResult { get; }
        public ProductoBodegaNewServices(IUnitOfWorkInventario unitOfWork)
        {
            _unitOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }

        ///<summary>
        ///Crea un nuevo ProductoBodegaNew
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la creación fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_productoBodegaNew">
        ///Objeto de tipo ProductoBodegaNew con todos sus atributos completos para ser insertado en la BBDD
        ///</param>
        public int Create(ProductoBodegaNew _productoBodegaNew)
        {
            int result = 0;
            try
            {
                ProductoBodegaNewValidator validator = new ProductoBodegaNewValidator();
                ValidationResult.Validation = validator.Validate(_productoBodegaNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.ProductoBodegaNewRepository.Create(_productoBodegaNew);
                        context.SaveChange();
                    }
                    ValidationResult.Status = StatusEnum.Ok;
                    ValidationResult.Message = "ProductoBodega registrado correctamente.";
                }
                else
                {
                    ValidationResult.Status = StatusEnum.Validation;
                }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return result;
        }
        ///<summary>
        ///Obtiene un ProductoBodegaNew por su Id
        ///</summary>
        ///<return>
        ///Devuelve un objeto de tipo ProductoBodegaNew con todos sus atributos completos, de los datos obtenidos desde la BBDD
        ///</return>
        ///<param name="_id">
        ///Id del ProductoBodegaNew a obtener
        ///</param>
        public ProductoBodegaNew GetById(int _id)
        {
            var _productoBodegaNew = new ProductoBodegaNew();
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    _productoBodegaNew = context.Repository.ProductoBodegaNewRepository.GetById(_id);
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return _productoBodegaNew;
        }
        ///<summary>
        ///Obtiene una lista de todos los ProductosBodegaNew existentes en la BBDD
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de tipo ProductoBodegaNew con todos sus atributos completos, de los datos obtenidos desde la BBDD
        ///</return>
        public List<ProductoBodegaNew> GetAll()
        {
            List<ProductoBodegaNew> result = new List<ProductoBodegaNew>();
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    result = context.Repository.ProductoBodegaNewRepository.GetAll();
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return result;
        }
        ///<summary>
        ///Actualiza una ProductoBodegaNew
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la actualización fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_productoBodegaNew">
        ///Objeto de tipo ProductoBodegaNew con todos sus atributos completos para ser actualizado en la BBDD
        ///</param>
        public int Update(ProductoBodegaNew _productoBodegaNew)
        {
            int result = 0;
            try
            {
                ProductoBodegaNewValidator validator = new ProductoBodegaNewValidator();
                ValidationResult.Validation = validator.Validate(_productoBodegaNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.ProductoBodegaNewRepository.Update(_productoBodegaNew);
                        context.SaveChange();
                    }
                    ValidationResult.Status = StatusEnum.Ok;
                }
                else
                {
                    ValidationResult.Status = StatusEnum.Validation;
                }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return result;
        }
        ///<summary>
        ///Realiza un borrado suave sobre un registro de ProductoBodegaNew
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la actualización fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_id">
        ///Id de la ProductoBodegaNew para ser marcada como eliminada en la BBDD
        ///</param>
        ///<param name="_isEliminado">
        ///Valor del campo is_eliminado para ser actualizado en la BBDD
        ///</param>
        public int UpdateSoftDelete(int _id, bool _isEliminado)
        {
            int result = 0;
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    result = context.Repository.ProductoBodegaNewRepository.UpdateSoftDelete(_id, _isEliminado);
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return result;
        }
        ///<summary>
        ///Verifica si existe un idBodega para un ProductoBodegaNew en la BBDD
        ///</summary>
        ///<return>
        ///Devuelve verdadero si existe, o un falso si no existe.
        ///</return>
        ///<param name="_idBodega">
        ///idBodega del ProductoBodegaNew a ser verificado en la BBDD
        ///</param>
        public bool IsExistIdBodega(int _idBodega)
        {
            bool result = false;
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    result = context.Repository.ProductoBodegaNewRepository.IsExistIdBodega(_idBodega);
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return result;
        }
        ///<summary>
        ///Verifica si existe un idProducto para un ProductoBodegaNew en la BBDD
        ///</summary>
        ///<return>
        ///Devuelve verdadero si existe, o un falso si no existe.
        ///</return>
        ///<param name="_idProducto">
        ///idProducto del ProductoBodegaNew a ser verificado en la BBDD
        ///</param>
        public bool IsExistIdProducto(int _idProducto)
        {
            bool result = false;
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    result = context.Repository.ProductoBodegaNewRepository.IsExistIdProducto(_idProducto);
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return result;
        }
        ///<summary>
        ///Elimina un ProductoBodegaNew por su Id
        ///</summary>
        ///<return>
        ///Devuelve un numero 1 si la eliminación fue exitosa, o un 0 si falló.
        ///</return>
        ///<param name="_productoBodegaNew">
        ///_productoBodegaNew es el objeto de tipo ProductoBodegaNew con todos sus atributos para ser eliminado de la BBDD
        ///</param>
        public int Remove(ProductoBodegaNew _productoBodegaNew)
        {
            int result = 0;
            try
            {
                ProductoBodegaNewValidator validator = new ProductoBodegaNewValidator();
                ValidationResult.Validation = validator.Validate(_productoBodegaNew);
                if (ValidationResult.Validation.IsValid)
                {
                    using (var context = _unitOfWork.Create())
                    {
                        result = context.Repository.ProductoBodegaNewRepository.Remove(_productoBodegaNew);
                        context.SaveChange();
                    }
                    ValidationResult.Status = StatusEnum.Ok;
                }
                else
                {
                    ValidationResult.Status = StatusEnum.Validation;
                }
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return result;
        }
    }
}
