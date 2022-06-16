using Models.MedidoresNew;
using NUnit.Framework;
using Services.MedidoresNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.MedidoresNew
{
    public class MedidorNewTest
    {
        public MedidorNew medidorNew;
        private List<MedidorNew> listaMedidorNew;
        private bool isEliminado = true;

        [SetUp]
        public void Setup()
        {
            medidorNew = new MedidorNew()
            {
                IdMedidor = 1,
                NumeroMedidor = "1111",
                InstalacionFecha = DateTime.Now,
                InstalacionFechaVerdad = true,
                UnidadMedidorEstado = 1,
                Alcantarillado =false,
                IdSubsidio = 1,
                IdCliente = 1,
                IdRed = 1,
                Nicho = false,
                DiametroEstado = 1,
                IdEmplazamiento =1,
                SegundoHogar = 1,
                EstadoClienteEstado =1,
                IdExencion = 1,
                IdSector =1,
                IdTarifa = 1,
                IdConfiguracionPeriodico = 1,
                IdDatoFacturacion =1,
                TipoMedidorEstado = 1,
                SincronizacionWeb =false,
                IdClienteGlobal =1,
                NumeroVivienda = 1,
                Direccion = "direccion 01",
                IdConfiguracionFacturacion = 1,
                FechaCreacion = DateTime.Now,
                IdUsuario = 1,
                IsEliminado = false
            };
        }

        [Test, Order(0)]
        public void CreateTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            MedidorNewServices medidorServices = new MedidorNewServices(unitOfWork);
            var resultado = medidorServices.Create(medidorNew);
            Assert.AreEqual(resultado, 1);
        }
        [Test, Order(1)]
        public void UpdateTest()
        {
            medidorNew.NumeroMedidor = "10001";
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            MedidorNewServices medidorServices = new MedidorNewServices(unitOfWork);
            var resultado = medidorServices.Update(medidorNew);
            Assert.AreEqual(resultado, 1);
        }

        [Test, Order(2)]
        public void GetByIdTest()
        {

            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            MedidorNewServices medidorServices = new MedidorNewServices(unitOfWork);
            var resultado = medidorServices.GetById(medidorNew.IdMedidor);
            Assert.AreEqual(resultado.IdMedidor, 1);
        }

        [Test, Order(3)]
        public void GetAllTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            MedidorNewServices medidorServices = new MedidorNewServices(unitOfWork);
            listaMedidorNew = medidorServices.GetAll();
            Assert.IsNotEmpty(listaMedidorNew);
        }

        [Test, Order(4)]
        public void UpdateSoftDeleteTest()
        {

            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            MedidorNewServices medidorServices = new MedidorNewServices(unitOfWork);
            var resultado = medidorServices.UpdateSoftDelete(medidorNew.IdMedidor, isEliminado);
            Assert.AreEqual(resultado, 1);
        }

        [Test, Order(5)]
        public void IsExistTest()
        {
            medidorNew.NumeroMedidor = "1111";
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            MedidorNewServices medidorServices = new MedidorNewServices(unitOfWork);
            var resultado = medidorServices.IsExistNumeroMedidorNew(medidorNew.NumeroMedidor);
            Assert.AreEqual(resultado, false);
        }

        [Test, Order(6)]
        public void RemoveTest()
        {

            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            MedidorNewServices medidorServices = new MedidorNewServices(unitOfWork);
            var resultado = medidorServices.Remove(medidorNew);
            Assert.AreEqual(resultado, 1);
        }
    }
}
