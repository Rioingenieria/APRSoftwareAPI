using Models.Inventory.BodegasNew;
using NUnit.Framework;
using Services.Inventory.BodegasNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.Enum.GetAll;

namespace UnitTest.BodegasNew
{
    public class BodegaNewTest
    {
        private BodegaNew bodegaNew;
        private List<BodegaNew> listaBodegaNew;
        private bool isEliminado = true;

        [SetUp]
        public void Setup()
        {
            bodegaNew = new BodegaNew()
            {
                IdBodega = 1,
                Nombre = "bodega 1",
                Descripcion = "bodega principal",
                Direccion = "direccion 01",
                Telefono = "12345",
                Correo = "email@mail.com",
                IdUsuario = 1,
                IdUsuarioEncargado = 1,
                FechaCreacion = DateTime.Now,
                IsEliminado = false
            };
        }
        [Test, Order(0)]
        public void CreateTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            BodegaNewServices bodegaNewServices = new BodegaNewServices(unitOfWork);
            var resultado = bodegaNewServices.Create(bodegaNew);
            Assert.AreEqual(resultado, 1);
        }
        [Test, Order(1)]
        public void UpdateTest()
        {
            bodegaNew.Nombre = "bodega 01";
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            BodegaNewServices bodegaNewServices = new BodegaNewServices(unitOfWork);
            var resultado = bodegaNewServices.Update(bodegaNew);
            Assert.AreEqual(resultado, 1);
        }

        [Test, Order(2)]
        public void GetByIdTest()
        {
            bodegaNew.IdBodega = 1;
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            BodegaNewServices bodegaNewServices = new BodegaNewServices(unitOfWork);
            var resultado = bodegaNewServices.GetById(bodegaNew.IdBodega);
            Assert.AreEqual(resultado.IdBodega, 1);
        }

        [Test, Order(3)]
        public void GetAllTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            BodegaNewServices bodegaNewServices = new BodegaNewServices(unitOfWork);
            listaBodegaNew = bodegaNewServices.GetAll(GetAllEnum.Todos);
            Assert.IsNotEmpty(listaBodegaNew);
        }

        [Test, Order(4)]
        public void UpdateSoftDeleteTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            BodegaNewServices bodegaNewServices = new BodegaNewServices(unitOfWork);
            var resultado = bodegaNewServices.UpdateIsEliminado(bodegaNew.IdBodega, isEliminado);
            Assert.AreEqual(resultado, 1);
        }

        [Test, Order(5)]
        public void IsExistIdBodegaTest()
        {
            bodegaNew.Nombre = "bodega test";
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            BodegaNewServices bodegaNewServices = new BodegaNewServices(unitOfWork);
            var resultado = bodegaNewServices.IsExistNombreBodegaNew(bodegaNew.Nombre);
            Assert.AreEqual(resultado, false);
        }

        [Test, Order(6)]
        public void RemoveTest()
        {
            bodegaNew.IdBodega = 2;
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            BodegaNewServices bodegaNewServices = new BodegaNewServices(unitOfWork);
            var resultado = bodegaNewServices.Remove(bodegaNew);
            Assert.AreEqual(resultado, 1);
        }
    }
}
