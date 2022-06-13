using Models.ProductosNew;
using NUnit.Framework;
using Services.ProductosNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.ProductosNew
{
    public class ProductoNewTest
    {
        private Models.Enum.Status.StatusEnum isCorrect;
        private ProductoNew _producto;
        [SetUp]
        public void Setup()
        { 
            isCorrect = Models.Enum.Status.StatusEnum.Ok;
            _producto = new Models.ProductosNew.ProductoNew() 
            {
            idProducto=1,
            nombre="1",
            descripcion="1",
            existencia=1,
            precio=1,
            codigo="1",
            costo=1,
            unidadMedidaEstado=1,
            idUsuario=1,
            fechaCreacion=DateTime.Now,
            isEliminado=false,
            sku="1",
            idProveedor=5,
            idBodega=1,
            idCategoriaProducto=1,
            idEstadoEstado=1
            };
        
        }
        [Test, Order (0)] 
        public void Create() 
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoNewServices productoServices = new ProductoNewServices(unitOfWork);
            productoServices.Create(_producto);
            Console.WriteLine(productoServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, productoServices.ValidationResult.Status);
        }
        [Test, Order(1)]
        public void GetAll()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoNewServices productoServices = new ProductoNewServices(unitOfWork);
            var ListResult = productoServices.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(2)]
        public void GetAllNoEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoNewServices productoServices = new ProductoNewServices(unitOfWork);
            var ListResult = productoServices.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(3)]
        public void UpdateIsEliminado()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoNewServices productoServices = new ProductoNewServices(unitOfWork);
            productoServices.UpdateIsEliminado(_producto.idProducto, true);
            Assert.AreEqual(isCorrect, productoServices.ValidationResult.Status);
        }
        [Test, Order(4)]
        public void GetAllEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoNewServices productoServices = new ProductoNewServices(unitOfWork);
            var ListResult = productoServices.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(5)]
        public void GetById() 
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoNewServices productoServices = new ProductoNewServices(unitOfWork);
            var ListResult = productoServices.GetById(_producto.idProducto);
            Assert.IsNotNull(ListResult);
        }
        [Test, Order(6)]
        public void Update() 
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoNewServices productoServices = new ProductoNewServices(unitOfWork);
            productoServices.Update(_producto);
            Console.WriteLine(productoServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, productoServices.ValidationResult.Status);
        }
        [Test, Order(7)]
        public void Remove()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoNewServices productoServices = new ProductoNewServices(unitOfWork);
            productoServices.Remove(_producto);
            Assert.AreEqual(isCorrect, productoServices.ValidationResult.Status);
        }
        [Test,Order(8)]
        public void IsExitsCodigo()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoNewServices productoServices = new ProductoNewServices(unitOfWork);
            var result = productoServices.IsExistCodigo(_producto.codigo);
            Assert.AreEqual(result, true);
        }
        [Test,Order(9)]
        public void GetbyCodigo()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ProductoNewServices productoServices = new ProductoNewServices(unitOfWork);
            var ListResult = productoServices.GetbyCodigo(_producto.codigo);
            Assert.IsNotEmpty(ListResult);
        }
    }
}
