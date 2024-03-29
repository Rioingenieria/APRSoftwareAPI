﻿using Models.ConfiguracionesGlobales;
using RepositoryInterface.ConfiguracionesFacturaciones;
using RepositoryInterface.ConfiguracionesGlobales;
using RepositoryInterface.ConfiguracionesPeriodicosNew;
using RepositoryInterface.MedidoresNew;
using RepositorySqlServer.ConfiguracionesFacturaciones;
using RepositorySqlServer.ConfiguracionesGlobales;
using RepositorySqlServer.ConfiguracionesPeriodicasNew;
using RepositorySqlServer.MedidoresNew;
using RepositoryInterface.Usuarios;
using RepositorySqlServer.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;
using RepositoryInterface.ProductosNew;
using RepositorySqlServer.ProductosNew;
using RepositoryInterface.ProductosCategoriaNew;
using RepositorySqlServer.ProductosCategoriasNew;
using RepositoryInterface.ProveedoresNew;
using RepositorySqlServer.ProveedoresNew;
using RepositoryInterface.DatosFacturacionNew;
using RepositorySqlServer.DatosFacturacionNew;
using RepositoryInterface.ProductosKitsNewRepository;
using RepositorySqlServer.ProductosKitsNew;
using RepositoryInterface.MatricesNew;
using RepositorySqlServer.MatricesNew;
using RepositoryInterface.PozosNew;
using RepositorySqlServer.PozosNew;
using RepositoryInterface.RedesNew;
using RepositorySqlServer.RedesNew;
using RepositoryInterface.EmplazamientosNew;
using RepositorySqlServer.EmplazamientosNew;
using RepositoryInterface.ClientesNew;
using RepositorySqlServer.ClientesNew;
using UnitOfWorkInterface.SSR;

namespace UnitOfWorkSqlServer.SSR
{
    public class UnitOfWorkSSRSqlServerRepository:IUnitOfWorkSSRRepository
    {
        public IConfiguracionGlobalRepository ConfiguracionGlobalRepository { get; set; }
        public IConfiguracionPeriodicoNewRepository ConfiguracionPeriodicoNewRepository { get; set; }

        //public IEgresoCategoriaRepository EgresoCategoriaRepository { get; set; }
        //public IEgresoSubCategoriaRepository EgresoSubCategoriaRepository { get; set; }
        //public ISucursalesRepository SucursalesRepository { get; set; }
        //public IAssetInventoryRepository AssetInventoryRepository { get; set; }
        //public IStatusesRepository StatusesRepository { get; set; }
        //public IBrandRepository BrandRepository { get; set; }
        //public IUserRepository UserRepository { get; set; }
        //public ICambioSaldoInicialRepository CambioSaldoInicialRepository { get; set; }
        //public ILecturaIngresoRepository LecturaIngresoRepository { get; set; }
        //public IClienteRepository ClienteRepository { get; set; }
        //public IMedidorRepository MedidorRepository { get; }
        //public ISubsidioRepository SubsidioRepository { get; }
        //public IReferenciasDTERepository ReferenciasDTERepository { get; }
        //public ITarifasParametricaRepository TarifasParametricaRepository { get; }
        //public IObservacionRepository ObservacionRepository { get; }
        //public IEstadoRepository EstadoRepository { get; }
        //public IEstadoCategoriaRepository EstadoCategoriaRepository { get; }
        //public ICambioEstadoClienteRepository CambioEstadoClienteRepository { get; }
        //public IEmplazamientoRepository EmplazamientoRepository { get; }
        //public IGiroFacturacionRepository GiroFacturacionRepository { get; }
        //public IExencionRepository ExencionRepository { get; }
        //public ISectorRepository SectorRepository { get; }
        //public IRedRepository RedRepository { get; }
        //public IMatrizRepository MatrizRepository { get; }
        //public IPozoRepository PozoRepository { get; }
        //public ICorteServicioRepository CorteServicioRepository { get; }
        //public IReposicionServicioRepository ReposicionServicioRepository { get; }
        //public IClienteOtroRepository ClienteOtroRepository { get; }
        //public IRegistroRepository RegistroRepository { get; }
        //public IConfiguracionIndividualRepository ConfiguracionIndividualRepository { get; }
        public IConfiguracionFacturacionRepository ConfiguracionFacturacionRepository { get; }
        public IMedidorNewRepository MedidorNewRepository { get; set; }
        public IUsuarioRepository UsuarioRepository { get; }
        public IProductoNewRepository ProductoNewRepository { get; }

        public IProductoCategoriaNewRepository ProductoCategoriaNewRepository { get; }

        public IProveedorNewRepository ProveedorNewRepository { get; }

        public IDatoFacturacionNewRepository DatoFacturacionNewRepository { get; }

        public IProductoKitNewRepository ProductoKitNewRepository { get; }

        public IMatrizNewRepository MatrizNewRepository { get; }

        public IPozoNewRepository PozoNewRepository { get; }

        public IRedNewRepository RedNewRepository { get; }

        public IEmplazamientoNewRepository EmplazamientoNewRepository { get; }

        public IClienteNewRepository ClienteNewRepository { get; }

        public UnitOfWorkSSRSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            ConfiguracionGlobalRepository = new ConfiguracionGlobalRepository(context, transaction);
            ConfiguracionPeriodicoNewRepository = new ConfiguracionPeriodicoNewRepository(context, transaction);
            ProductoNewRepository = new ProductoNewRepository(context, transaction);
            ProductoCategoriaNewRepository = new ProductoCategoriaNewRepository(context, transaction);
            ProveedorNewRepository = new ProveedorNewRepository(context, transaction);
            DatoFacturacionNewRepository = new DatoFacturacionNewRepository(context, transaction);
            ProductoKitNewRepository = new ProductoKitNewRepository(context, transaction);
            MatrizNewRepository = new MatrizNewRepository(context, transaction);
            PozoNewRepository = new PozoNewRepository(context, transaction);
            RedNewRepository = new RedNewRepository(context, transaction);
            EmplazamientoNewRepository = new EmplazamientoNewRepository(context, transaction);
            ClienteNewRepository = new ClienteNewRepository(context, transaction);
            //EgresoCategoriaRepository = new EgresoCategoriaRepository(context, transaction);
            //EgresoSubCategoriaRepository = new EgresoSubCategoriaRepository(context, transaction);
            //SucursalesRepository = new SucursalesRepository(context, transaction);
            //AssetInventoryRepository = new AssetInventoryRepository(context, transaction);
            //StatusesRepository = new StatusesRepository(context, transaction);
            //BrandRepository = new BrandRepository(context, transaction);
            //UserRepository = new UserRepository(context, transaction);
            //CambioSaldoInicialRepository = new CambioSaldoInicialRepository(context, transaction);
            //LecturaIngresoRepository = new LecturaIngresoRepository(context, transaction);
            //ClienteRepository = new ClienteRepository(context, transaction);
            //DatosFacturacionRepository = new DatosFacturacionRepository(context, transaction);
            //MedidorRepository = new MedidorRepository(context, transaction);
            //SubsidioRepository = new SubsidioRepository(context, transaction);
            //ReferenciasDTERepository = new ReferenciasDTERepository(context, transaction);
            //TarifasParametricaRepository = new TarifasParametricaRepository(context, transaction);
            //ObservacionRepository = new ObservacionRepository(context, transaction);
            //EstadoRepository = new EstadoRepository(context, transaction);
            //EstadoCategoriaRepository = new EstadoCategoriaRepository(context, transaction);
            //CambioEstadoClienteRepository = new CambioEstadoClienteRepository(context, transaction);
            //EmplazamientoRepository = new EmplazamientoRepository(context, transaction);
            //GiroFacturacionRepository = new GiroFacturacionRepository(context, transaction);
            //ExencionRepository = new ExencionRepository(context, transaction);
            //SectorRepository = new SectorRepository(context, transaction);
            //RedRepository = new RedRepository(context, transaction);
            //MatrizRepository = new MatrizRepository(context, transaction);
            //PozoRepository = new PozoRepository(context, transaction);
            //CorteServicioRepository = new CorteServicioRepository(context, transaction);
            //ReposicionServicioRepository = new ReposicionServicioRepository(context, transaction);
            //ClienteOtroRepository = new ClienteOtroRepository(context, transaction);
            //RegistroRepository = new RegistroRepository(context, transaction);
            //ConfiguracionIndividualRepository = new ConfiguracionIndividualRepository(context, transaction);
            ConfiguracionFacturacionRepository = new ConfiguracionFacturacionRepository(context, transaction);
            MedidorNewRepository = new MedidorNewRepository(context, transaction);
            UsuarioRepository = new UsuarioRepository(context, transaction);
        }
    }
}
