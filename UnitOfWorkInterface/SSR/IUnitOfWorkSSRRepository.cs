using RepositoryInterface.ConfiguracionesGlobales;
using RepositoryInterface.ConfiguracionesPeriodicosNew;
using RepositoryInterface.ConfiguracionesFacturaciones;
using RepositoryInterface.MedidoresNew;
using RepositoryInterface.Usuarios;
using RepositoryInterface.ProductosNew;
using RepositoryInterface.ProductosCategoriaNew;
using RepositoryInterface.ProveedoresNew;
using RepositoryInterface.DatosFacturacionNew;
using RepositoryInterface.ProductosKitsNewRepository;
using RepositoryInterface.MatricesNew;
using RepositoryInterface.PozosNew;
using RepositoryInterface.RedesNew;
using RepositoryInterface.EmplazamientosNew;
using RepositoryInterface.ClientesNew;

namespace UnitOfWorkInterface.SSR
{
    public interface IUnitOfWorkSSRRepository
    {
        IConfiguracionGlobalRepository ConfiguracionGlobalRepository { get; }
        IConfiguracionPeriodicoNewRepository ConfiguracionPeriodicoNewRepository { get; }
        IMedidorNewRepository MedidorNewRepository { get; }
        IProductoNewRepository ProductoNewRepository { get; }
        IProductoCategoriaNewRepository ProductoCategoriaNewRepository { get; }
        IProveedorNewRepository ProveedorNewRepository { get; }
        IDatoFacturacionNewRepository DatoFacturacionNewRepository { get; }
        IProductoKitNewRepository ProductoKitNewRepository { get; }
        IMatrizNewRepository MatrizNewRepository { get; }
        IPozoNewRepository PozoNewRepository { get; }
        IRedNewRepository RedNewRepository { get; }
        IEmplazamientoNewRepository EmplazamientoNewRepository { get; }
        IClienteNewRepository ClienteNewRepository { get; }
        //IEgresoCategoriaRepository EgresoCategoriaRepository { get; }
        //IEgresoSubCategoriaRepository EgresoSubCategoriaRepository { get; }
        //ISucursalesRepository SucursalesRepository { get; }
        //IAssetInventoryRepository AssetInventoryRepository { get; }
        //IStatusesRepository StatusesRepository { get; }
        //IBrandRepository BrandRepository { get; }
        //IUserRepository UserRepository { get; }
        //ICambioSaldoInicialRepository CambioSaldoInicialRepository { get; }
        //ILecturaIngresoRepository LecturaIngresoRepository { get; }
        //IClienteRepository ClienteRepository { get; }
        //IMedidorRepository MedidorRepository { get; }
        //ISubsidioRepository SubsidioRepository { get; }
        //IReferenciasDTERepository ReferenciasDTERepository { get; }
        //ITarifasParametricaRepository TarifasParametricaRepository { get; }
        //IObservacionRepository ObservacionRepository { get; }
        //IEstadoRepository EstadoRepository { get; }
        //IEstadoCategoriaRepository EstadoCategoriaRepository { get; }
        //ICambioEstadoClienteRepository CambioEstadoClienteRepository { get; }
        //IEmplazamientoRepository EmplazamientoRepository { get; }
        //IGiroFacturacionRepository GiroFacturacionRepository { get; }
        //IExencionRepository ExencionRepository { get; }
        //ISectorRepository SectorRepository { get; }
        //IRedRepository RedRepository { get; }
        //IMatrizRepository MatrizRepository { get; }
        //IPozoRepository PozoRepository { get; }
        //ICorteServicioRepository CorteServicioRepository { get; }
        //IReposicionServicioRepository ReposicionServicioRepository { get; }
        //IClienteOtroRepository ClienteOtroRepository { get; }
        //IRegistroRepository RegistroRepository { get; }
        //IConfiguracionIndividualRepository ConfiguracionIndividualRepository { get; }
        IConfiguracionFacturacionRepository ConfiguracionFacturacionRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
    }
}
