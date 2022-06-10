using Models.ProductosKitsNew;
using NUnit.Framework;
using Services.ProductosKitsNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.ProductosKitsNew
{
    public class ProductosKitsNewTest
    {
        private Models.Enum.Status.StatusEnum isCorrect;
        private ProductoKitNew _producto;

        [SetUp]
        public void Setup()
        {
            isCorrect = Models.Enum.Status.StatusEnum.Ok;
            _producto = new ProductoKitNew()
            {
              idProducto =1,
              idKit = 1,
              cantidadProducto = 1,
              idProductoKit = 1,
              isEliminado=false
            };

        }
        [Test, Order(0)]
        public void Create()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoKitNewServices productoServices = new ProductoKitNewServices(unitOfWork);
            productoServices.Create(_producto);
            Console.WriteLine(productoServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, productoServices.ValidationResult.Status);
        }
        [Test, Order(1)]
        public void GetAll()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoKitNewServices productoServices = new ProductoKitNewServices(unitOfWork);
            var ListResult = productoServices.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(2)]
        public void GetAllNoEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoKitNewServices productoServices = new ProductoKitNewServices(unitOfWork);
            var ListResult = productoServices.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(3)]
        public void UpdateIsEliminado()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoKitNewServices productoServices = new ProductoKitNewServices(unitOfWork);
            productoServices.UpdateIsEliminado(_producto.idProductoKit, true);
            Assert.AreEqual(isCorrect, productoServices.ValidationResult.Status);
        }
        [Test, Order(4)]
        public void GetAllEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoKitNewServices productoServices = new ProductoKitNewServices(unitOfWork);
            var ListResult = productoServices.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(5)]
        public void GetById()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoKitNewServices productoServices = new ProductoKitNewServices(unitOfWork);
            var Result = productoServices.GetById(_producto.idProductoKit);
            Assert.IsNotNull(Result);
        }
        [Test, Order(6)]
        public void Update()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoKitNewServices productoServices = new ProductoKitNewServices(unitOfWork);
            productoServices.Update(_producto);
            Console.WriteLine(productoServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, productoServices.ValidationResult.Status);
        }
        [Test, Order(7)]
        public void Remove()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoKitNewServices productoServices = new ProductoKitNewServices(unitOfWork);
            productoServices.Remove(_producto);
            Assert.AreEqual(isCorrect, productoServices.ValidationResult.Status);
        }
    }
}
