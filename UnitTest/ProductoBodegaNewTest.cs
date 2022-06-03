using Models.Inventory.ProductosBodegasNew;
using NUnit.Framework;
using Services.Inventory.ProductosBodegasNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class ProductoBodegaNewTest
    {
        public ProductoBodegaNew productoBodegaNew;
        private List<ProductoBodegaNew> listaProductoBodegaNew;
        private bool isEliminado = true;

        [SetUp]
        public void Setup()
        {
            productoBodegaNew = new ProductoBodegaNew()
            {
                IdProducto = 1,
                IdBodega = 1,
                IdProductoBodega = 1,
                IsEliminado = false
            };
        }
        [Test, Order(0)]
        public void CreateTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            ProductoBodegaNewServices productoBodegaNewServices = new ProductoBodegaNewServices(unitOfWork);
            var resultado = productoBodegaNewServices.Create(productoBodegaNew);
            Assert.AreEqual(resultado, 1);
        }
        [Test, Order(1)]
        public void UpdateTest()
        {
            productoBodegaNew.IsEliminado = true;
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            ProductoBodegaNewServices productoBodegaNewServices = new ProductoBodegaNewServices(unitOfWork);
            var resultado = productoBodegaNewServices.Update(productoBodegaNew);
            Assert.AreEqual(resultado, 1);
        }

        [Test, Order(2)]
        public void GetByIdTest()
        {
            productoBodegaNew.IdProductoBodega = 1;
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            ProductoBodegaNewServices productoBodegaNewServices = new ProductoBodegaNewServices(unitOfWork);
            var resultado = productoBodegaNewServices.GetById(productoBodegaNew.IdProductoBodega);
            Assert.AreEqual(resultado.IdProductoBodega, 1);
        }

        [Test, Order(3)]
        public void GetAllTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            ProductoBodegaNewServices productoBodegaNewServices = new ProductoBodegaNewServices(unitOfWork);
            listaProductoBodegaNew = productoBodegaNewServices.GetAll();
            Assert.IsNotEmpty(listaProductoBodegaNew);
        }

        [Test, Order(4)]
        public void UpdateSoftDeleteTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            ProductoBodegaNewServices productoBodegaNewServices = new ProductoBodegaNewServices(unitOfWork);
            var resultado = productoBodegaNewServices.UpdateSoftDelete(productoBodegaNew.IdProductoBodega, isEliminado);
            Assert.AreEqual(resultado, 1);
        }

        [Test, Order(5)]
        public void IsExistIdBodegaTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            ProductoBodegaNewServices productoBodegaNewServices = new ProductoBodegaNewServices(unitOfWork);
            var resultado = productoBodegaNewServices.IsExistIdBodega(productoBodegaNew.IdBodega);
            Assert.AreEqual(resultado, true);
        }

        [Test, Order(6)]
        public void IsExistIdProductoTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            ProductoBodegaNewServices productoBodegaNewServices = new ProductoBodegaNewServices(unitOfWork);
            var resultado = productoBodegaNewServices.IsExistIdProducto(productoBodegaNew.IdProducto);
            Assert.AreEqual(resultado, true);
        }

        [Test, Order(7)]
        public void RemoveTest()
        {
            productoBodegaNew.IdProductoBodega = 1;
            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            ProductoBodegaNewServices productoBodegaNewServices = new ProductoBodegaNewServices(unitOfWork);
            var resultado = productoBodegaNewServices.Remove(productoBodegaNew);
            Assert.AreEqual(resultado, 1);
        }
    }
}
