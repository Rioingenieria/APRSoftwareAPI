using Models.DatosFacturacionNew;
using NUnit.Framework;
using Services.DatoFacturacionNewNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.DatosFacturacionNew
{
    internal class DatoFacturacionNewTest
    {
        private DatoFacturacionNew datosFacturacion;
        private List<DatoFacturacionNew> listaDatosFacturacion;
        private bool isEliminado = true;

        [SetUp]
        public void Setup()
        {
            datosFacturacion = new DatoFacturacionNew()
            {
                IdDatoFacturacion=1,
                Rut = "11111111-1",
                RazonSocial = "Razon Social 01",
                Direccion = "Direccion 01",
                ComunaEstado = 1,
                IdGiroFacturacion = 1,
                EmailIntercambio = "emailintercambio@mail.com",
                DocumentoPago = 1,
                FormaPagoEstado = 1,
                FechaCreacion=DateTime.Now,
                isEliminado=false,
                IdUsuario=1,
            };
        }

        [Test,Order(0)]
        public void CreateTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoFacturacionNewServices service = new DatoFacturacionNewServices(unitOfWork);
            var resultado = service.Create(datosFacturacion);
            Assert.AreEqual(resultado, 1);
        }

        [Test, Order(1)]
        public void UpdateTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoFacturacionNewServices datosFacturacionServices = new DatoFacturacionNewServices(unitOfWork);
            var resultado = datosFacturacionServices.Update(datosFacturacion);
            Assert.AreEqual(resultado, 1);
        }

        [Test, Order(2)]
        public void GetByIdTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoFacturacionNewServices datosFacturacionServices = new DatoFacturacionNewServices(unitOfWork);
            var resultado = datosFacturacionServices.GetById(datosFacturacion.IdDatoFacturacion);
            Assert.IsNotNull(resultado);
        }

        [Test, Order(3)]
        public void GetAllTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoFacturacionNewServices datosFacturacionServices = new DatoFacturacionNewServices(unitOfWork);
            listaDatosFacturacion = datosFacturacionServices.GetAll();
            Assert.IsNotEmpty(listaDatosFacturacion);
        }
        [Test, Order(4)]
        public void GetAllNoEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoFacturacionNewServices datosFacturacionServices = new DatoFacturacionNewServices(unitOfWork);
            var ListResult = datosFacturacionServices.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(5)]
        public void UpdateSoftDeleteTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoFacturacionNewServices datosFacturacionServices = new DatoFacturacionNewServices(unitOfWork);
            var resultado = datosFacturacionServices.UpdateSoftDelete(datosFacturacion.IdDatoFacturacion, isEliminado);
            Assert.AreEqual(resultado, 1);
        }

        [Test,Order(6)]
        public void GetAllEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoFacturacionNewServices datosFacturacionServices = new DatoFacturacionNewServices(unitOfWork);
            var ListResult = datosFacturacionServices.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(7)]
        public void IsExistTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoFacturacionNewServices datosFacturacionServices = new DatoFacturacionNewServices(unitOfWork);
            var resultado = datosFacturacionServices.IsExistRazonSocial(datosFacturacion.RazonSocial);
            Assert.AreEqual(resultado, true);
        }

        [Test, Order(8)]
        public void RemoveTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoFacturacionNewServices datosFacturacionServices = new DatoFacturacionNewServices(unitOfWork);
            var resultado = datosFacturacionServices.Remove(datosFacturacion);
            Assert.AreEqual(resultado, 1);
        }
    }
}
