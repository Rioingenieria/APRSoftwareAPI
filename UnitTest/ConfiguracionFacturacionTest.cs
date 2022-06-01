using Models.ConfiguracionesFacturaciones;
using NUnit.Framework;
using Services.ConfiguracionesFacturaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class ConfiguracionFacturacionTest
    {
        public ConfiguracionFacturacion configuracionFacturacion;
        private List<ConfiguracionFacturacion> listaUsuario;
        private bool isEliminado = true;

        [SetUp]
        public void Setup()
        {
            configuracionFacturacion = new ConfiguracionFacturacion()
            {
                IdConfiguracionFacturacion = 1,
                TermicaFactura = false,
                TermicaBoleta = true,
                TermicaComprobante = false,
                CuentaBoleta = false,
                SaldoAnteriorDTE = false,
                ReciboTermico =false,
                EncabezadoCuentaBoleta = "Cuenta con boleta",
                ColorPrincipalDTE = 1,
                ColorSecundarioDTE = 2,
                InteresEstado = 1,
                ValorInteres =0,
                FechaCreacion = DateTime.Now,
                IdUsuario = 1,
                IsEliminado = false
            };
        }

        [Test, Order(0)]
        public void CreateTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionFacturacionServices configuracionFacturacionServices = new ConfiguracionFacturacionServices(unitOfWork);
            var resultado = configuracionFacturacionServices.Create(configuracionFacturacion);
            Assert.AreEqual(resultado, 1);
        }
        [Test, Order(1)]
        public void UpdateTest()
        {
            configuracionFacturacion.EncabezadoCuentaBoleta = "Cuenta con factura";
            configuracionFacturacion.TermicaFactura = true;
            configuracionFacturacion.TermicaBoleta = false;
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionFacturacionServices configuracionFacturacionServices = new ConfiguracionFacturacionServices(unitOfWork);
            var resultado = configuracionFacturacionServices.Update(configuracionFacturacion);
            Assert.AreEqual(resultado, 1);
        }

        [Test, Order(2)]
        public void GetByIdTest()
        {
            configuracionFacturacion.IdUsuario = 1;
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionFacturacionServices configuracionFacturacionServices = new ConfiguracionFacturacionServices(unitOfWork);
            var resultado = configuracionFacturacionServices.GetById(configuracionFacturacion.IdUsuario);
            Assert.AreEqual(resultado.IdUsuario, 1);
        }

        [Test, Order(3)]
        public void GetAllTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionFacturacionServices configuracionFacturacionServices = new ConfiguracionFacturacionServices(unitOfWork);
            listaUsuario = configuracionFacturacionServices.GetAll();
            Assert.IsNotEmpty(listaUsuario);
        }

        [Test, Order(4)]
        public void UpdateSoftDeleteTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionFacturacionServices configuracionFacturacionServices = new ConfiguracionFacturacionServices(unitOfWork);
            var resultado = configuracionFacturacionServices.UpdateSoftDelete(configuracionFacturacion.IdUsuario, isEliminado);
            Assert.AreEqual(resultado, 1);
        }

        [Test, Order(5)]
        public void IsExistTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionFacturacionServices configuracionFacturacionServices = new ConfiguracionFacturacionServices(unitOfWork);
            var resultado = configuracionFacturacionServices.IsExistIdUsuario(configuracionFacturacion.IdUsuario);
            Assert.AreEqual(resultado, true);
        }

        [Test, Order(6)]
        public void RemoveTest()
        {
            configuracionFacturacion.IdUsuario = 1;
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionFacturacionServices configuracionFacturacionServices = new ConfiguracionFacturacionServices(unitOfWork);
            var resultado = configuracionFacturacionServices.Remove(configuracionFacturacion);
            Assert.AreEqual(resultado, 1);
        }
    }
}
