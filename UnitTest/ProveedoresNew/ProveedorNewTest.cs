using Models.Common;
using Models.ProveedoresNew;
using NUnit.Framework;
using Services.ProveedoresNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkInterface;

namespace UnitTest.ProveedoresNew
{
    public class ProveedorNewTest
    {
        ProveedorNew _proveedor;
        UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
        private Models.Enum.Status.StatusEnum isCorrect;
        [SetUp]
        public void Setup() 
        { 
            isCorrect = Models.Enum.Status.StatusEnum.Ok;
             _proveedor = new ProveedorNew() 
             {
             id_proveedor=1,
             nombre="1",
             ciudad="1",
             telefono="1",
             email="1",
             descripcion="1",
             id_dato_facturacion=6,
             is_eliminado=false
             };

        }
        [Test, Order(0)]
        public void Create()
        {
            ProveedorNewServices proveedorServices = new ProveedorNewServices(unitOfWork);
            proveedorServices.Create(_proveedor);
            Console.WriteLine(proveedorServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, proveedorServices.ValidationResult.Status);
        }
        [Test, Order(1)]
        public void GetAll()
        {
            ProveedorNewServices proveedorServices = new ProveedorNewServices(unitOfWork);
            var ListResult = proveedorServices.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(2)]
        public void GetAllNoEliminados()
        {
            ProveedorNewServices proveedorServices = new ProveedorNewServices(unitOfWork);
            var ListResult = proveedorServices.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(3)]
        public void UpdateIsEliminado()
        {
            ProveedorNewServices proveedorServices = new ProveedorNewServices(unitOfWork);
            proveedorServices.UpdateIsEliminado(_proveedor.id_proveedor, true);
            Assert.AreEqual(isCorrect, proveedorServices.ValidationResult.Status);
        }
        [Test, Order(4)]
        public void GetAllEliminados()
        {
            ProveedorNewServices proveedorServices = new ProveedorNewServices(unitOfWork);
            var ListResult = proveedorServices.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(5)]
        public void GetById()
        {
            ProveedorNewServices proveedorServices = new ProveedorNewServices(unitOfWork);
            var ListResult = proveedorServices.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(6)]
        public void Update()
        {
            ProveedorNewServices proveedorServices = new ProveedorNewServices(unitOfWork);
            proveedorServices.Update(_proveedor);
            Console.WriteLine(proveedorServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, proveedorServices.ValidationResult.Status);
        }
        [Test, Order(7)]
        public void Remove()
        {
            ProveedorNewServices proveedorServices = new ProveedorNewServices(unitOfWork);
            proveedorServices.Remove(_proveedor);
            Assert.AreEqual(isCorrect, proveedorServices.ValidationResult.Status);
        }
    }
}
