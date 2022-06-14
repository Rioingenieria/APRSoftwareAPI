using Models.ClientesNew;
using NUnit.Framework;
using Services.ClientesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.ClientesNew
{
    public class ClienteNewTest
    {
        private Models.Enum.Status.StatusEnum isCorrect;
        private ClienteNew _cliente;

        [SetUp]
        public void Setup()
        {
            isCorrect = Models.Enum.Status.StatusEnum.Ok;
            _cliente = new ClienteNew()
            {
                idCliente= 1,
                nombre = "1",
                apellido= "1",
                rut = "1",
                domicilio= "1",
                email = "1",
                ingreso =DateTime.Now,
                tipoClienteEstado= 1,
                numSocio= 1,
                telefono= "1",
                numVivi= 1,
                genero= "1",
                fechaNacimiento= DateTime.Now,
                firmarLibro= true,
                envioWhatsapp= "1",
                fechaCreacion= DateTime.Now,
                idUsuario=1,
                isEliminado = false
            };

        }
        [Test, Order(0)]
        public void Create()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ClienteNewServices clienteServices = new ClienteNewServices(unitOfWork);
            clienteServices.Create(_cliente);
            Console.WriteLine(clienteServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, clienteServices.ValidationResult.Status);
        }
        [Test, Order(1)]
        public void GetAll()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ClienteNewServices clienteServices = new ClienteNewServices(unitOfWork);
            var ListResult = clienteServices.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(2)]
        public void GetAllNoEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ClienteNewServices clienteServices = new ClienteNewServices(unitOfWork);
            var ListResult = clienteServices.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(3)]
        public void UpdateIsEliminado()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ClienteNewServices clienteServices = new ClienteNewServices(unitOfWork);
            clienteServices.UpdateIsEliminado(_cliente.idCliente, true);
            Assert.AreEqual(isCorrect, clienteServices.ValidationResult.Status);
        }
        [Test, Order(4)]
        public void GetAllEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ClienteNewServices clienteServices = new ClienteNewServices(unitOfWork);
            var ListResult = clienteServices.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(5)]
        public void GetById()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ClienteNewServices clienteServices = new ClienteNewServices(unitOfWork);
            var Result = clienteServices.GetById(_cliente.idCliente);
            Assert.IsNotNull(Result);
        }
        [Test, Order(6)]
        public void Update()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ClienteNewServices clienteServices = new ClienteNewServices(unitOfWork);
            clienteServices.Update(_cliente);
            Console.WriteLine(clienteServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, clienteServices.ValidationResult.Status);
        }
        [Test, Order(7)]
        public void IsExistsRutCliente()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ClienteNewServices clienteServices = new ClienteNewServices(unitOfWork);
            var Result = clienteServices.IsExitsRutCliente(_cliente.rut);
            Assert.True(Result);
        }

        [Test, Order(8)]
        public void Remove()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ClienteNewServices clienteServices = new ClienteNewServices(unitOfWork);
            clienteServices.Remove(_cliente);
            Assert.AreEqual(isCorrect, clienteServices.ValidationResult.Status);
        }
    }
}
