using Models;
using Models.Common;
using Models.Enum;
using Models.Inventory.BodegasUsuariosNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface.IUnitOfWorkInventario;
using static Models.Enum.Status;

namespace Services.Inventory.BodegasUsuariosNewServices
{
    public class BodegaUsuarioNewServices
    {
        private readonly IUnitOfWorkInventario _uniOfWork;
        public ValidationsFluent ValidationResult { get; }
        public BodegaUsuarioNewServices(IUnitOfWorkInventario unitOfWork)
        {
            _uniOfWork = unitOfWork;
            ValidationResult = new ValidationsFluent();
        }
        ///<summary>
        ///Obtiene una bodegaUsuarioNew por su Id.
        ///</summary>
        ///<return>
        ///Devuelve un objeto de tipo BodegaUsuarioNew con todos sus atributos correspondiente al registro de la BBDD
        ///</return>
        ///<param name="_IdBodegaNew">
        ///Id de la bodegaUsuarioNew a obtener.
        ///</param>
        public BodegaUsuarioNew GetById(int _IdBodegaNew)
        {
            BodegaUsuarioNew bodegaUsuarioNew = new BodegaUsuarioNew();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    bodegaUsuarioNew = context.Repository.BodegaUsuarioNewRepository.GetById(_IdBodegaNew);
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
            }
            return bodegaUsuarioNew;
        }
        ///<summary>
        ///Obtiene una lista de todas las bodegas y usuarios relacionados por id_usuario_encargado de la BBDD
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de BodegaUsuarioNew.
        ///</return>
        private List<BodegaUsuarioNew> GetAll()
        {
            List<BodegaUsuarioNew> listaBodegasUsuariosNew = new List<BodegaUsuarioNew>();
            try
            {
                using (var context = _uniOfWork.Create())
                {
                    listaBodegasUsuariosNew = context.Repository.BodegaUsuarioNewRepository.GetAll();
                    context.SaveChange();
                }
                ValidationResult.Status = StatusEnum.Ok;
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = StatusEnum.Error;
            }
            return listaBodegasUsuariosNew;
        }
        ///<summary>
        ///Obtiene una lista de todas las bodegas y usuarios relacionados por id_usuario_encargado no eliminadas de la BBDD 
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de BodegaUsuarioNew.
        ///</return>
        private List<BodegaUsuarioNew> GetAllNoEliminados()
        {
            List<BodegaUsuarioNew> listaBodegasUsuariosNew = new List<BodegaUsuarioNew>();
            try
            {
                listaBodegasUsuariosNew = GetAll();
                var result = from bodegaUsuarioNew in listaBodegasUsuariosNew
                             where bodegaUsuarioNew.BodegaNew.IsEliminado == false && bodegaUsuarioNew.Usuario.IsEliminado==false
                             select bodegaUsuarioNew;
                return result.ToList();
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        ///<summary>
        ///Obtiene una lista de todas las bodegas y usuarios relacionados por id_usuario_encargado eliminadas de la BBDD 
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de BodegaUsuarioNew.
        ///</return>
        private List<BodegaUsuarioNew> GetAllEliminados()
        {
            try
            {
                List<BodegaUsuarioNew> listaBodegasUsuariosNew = new List<BodegaUsuarioNew>();
                listaBodegasUsuariosNew = GetAll();
                var result = from bodegaUsuarioNew in listaBodegasUsuariosNew
                             where bodegaUsuarioNew.BodegaNew.IsEliminado == true && bodegaUsuarioNew.Usuario.IsEliminado == true
                             select bodegaUsuarioNew;
                return result.ToList();
            }
            catch (Exception ex)
            {
                SalidaLogs.AgregarLog(ex);
                ValidationResult.Status = Models.Enum.Status.StatusEnum.Error;
                return null;
            }
        }
        ///<summary>
        ///Obtiene una lista de todas las bodegas y usuarios relacionados por id_usuario_encargado. Segun parametro indicado segun enumeracion.
        ///</summary>
        ///<return>
        ///Devuelve un objeto lista de BodegaUsuarioNew.
        ///</return>
        public List<BodegaUsuarioNew> GetAll(GetAll.GetAllEnum _operacion)
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
    }
}
