using Models.ProductosCategoriasNew;
using NUnit.Framework;
using Services.ProductosCategoriasNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.ProductosCategoriasNew
{
    public class ProductoCategoriaNewTest
    {
        private Models.Enum.Status.StatusEnum isCorrect;
        ProductoCategoriaNew _productoCategoria;
        [SetUp]
        public void Setup()
        {
            isCorrect = Models.Enum.Status.StatusEnum.Ok;
            _productoCategoria=new ProductoCategoriaNew() 
            { 
            id_producto_categoria=1,
            nombre="1",
            descripcion="1",
            is_eliminado=false,
            id_usuario=1,
            fecha_creacion=DateTime.Now
            };
        }
        [Test,Order (0)]
        public void Create()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoCategoriaNewServices productoServices = new ProductoCategoriaNewServices(unitOfWork);
            productoServices.Create(_productoCategoria);
            Console.WriteLine(productoServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, productoServices.ValidationResult.Status);
        }
        [Test, Order(1)]
        public void GetAll()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoCategoriaNewServices productoServices = new ProductoCategoriaNewServices(unitOfWork);
            var ListResult = productoServices.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(2)]
        public void GetAllNoEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoCategoriaNewServices productoServices = new ProductoCategoriaNewServices(unitOfWork);
            var ListResult = productoServices.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(3)]
        public void UpdateIsEliminado()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoCategoriaNewServices productoServices = new ProductoCategoriaNewServices(unitOfWork);
            productoServices.UpdateIsEliminado(_productoCategoria.id_producto_categoria, true);
            Assert.AreEqual(isCorrect, productoServices.ValidationResult.Status);
        }
        [Test, Order(4)]
        public void GetAllEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoCategoriaNewServices productoServices = new ProductoCategoriaNewServices(unitOfWork);
            var ListResult = productoServices.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(5)]
        public void GetById()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoCategoriaNewServices productoServices = new ProductoCategoriaNewServices(unitOfWork);
            var ListResult = productoServices.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(6)]
        public void Update()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoCategoriaNewServices productoServices = new ProductoCategoriaNewServices(unitOfWork);
            productoServices.Update(_productoCategoria);
            Console.WriteLine(productoServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, productoServices.ValidationResult.Status);
        }
        [Test, Order(7)]
        public void Remove()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoCategoriaNewServices productoServices = new ProductoCategoriaNewServices(unitOfWork);
            productoServices.Remove(_productoCategoria);
            Assert.AreEqual(isCorrect, productoServices.ValidationResult.Status);
        }
    }
}
