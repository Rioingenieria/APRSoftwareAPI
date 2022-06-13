using Models.EmplazamientosNew;
using NUnit.Framework;
using Services.EmplazamientosNew;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.EmplazamientosNew
{
    public class EmplazamientoNewTest
    {
        private Models.Enum.Status.StatusEnum isCorrect;
        private EmplazamientoNew _emplazamiento;

        [SetUp]
        public void Setup()
        {
            isCorrect = Models.Enum.Status.StatusEnum.Ok;
            MemoryStream ms=new MemoryStream();
            _emplazamiento = new EmplazamientoNew()
            {
                idEmplazamiento = 1,
                rol = "1",
                lote = "1",
                parcela = "",
                plano =ms.GetBuffer(),
                isEliminado = false
            };
        }
        [Test, Order(0)]
        public void Create()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            EmplazamientoNewServices emplazamientoServices = new EmplazamientoNewServices(unitOfWork);
            emplazamientoServices.Create(_emplazamiento);
            Console.WriteLine(emplazamientoServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, emplazamientoServices.ValidationResult.Status);
        }
        [Test, Order(1)]
        public void GetAll()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            EmplazamientoNewServices emplazamientoServices = new EmplazamientoNewServices(unitOfWork);
            var ListResult = emplazamientoServices.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(2)]
        public void GetAllNoEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            EmplazamientoNewServices emplazamientoServices = new EmplazamientoNewServices(unitOfWork);
            var ListResult = emplazamientoServices.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(3)]
        public void UpdateIsEliminado()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            EmplazamientoNewServices emplazamientoServices = new EmplazamientoNewServices(unitOfWork);
            emplazamientoServices.UpdateIsEliminado(_emplazamiento.idEmplazamiento, true);
            Assert.AreEqual(isCorrect, emplazamientoServices.ValidationResult.Status);
        }
        [Test, Order(4)]
        public void GetAllEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            EmplazamientoNewServices emplazamientoServices = new EmplazamientoNewServices(unitOfWork);
            var ListResult = emplazamientoServices.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(5)]
        public void GetById()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            EmplazamientoNewServices emplazamientoServices = new EmplazamientoNewServices(unitOfWork);
            var Result = emplazamientoServices.GetById(_emplazamiento.idEmplazamiento);
            Assert.IsNotNull(Result);
        }
        [Test, Order(6)]
        public void Update()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            EmplazamientoNewServices emplazamientoServices = new EmplazamientoNewServices(unitOfWork);
            emplazamientoServices.Update(_emplazamiento);
            Console.WriteLine(emplazamientoServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, emplazamientoServices.ValidationResult.Status);
        }
        [Test, Order(7)]
        public void Remove()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            EmplazamientoNewServices emplazamientoServices = new EmplazamientoNewServices(unitOfWork);
            emplazamientoServices.Remove(_emplazamiento);
            Assert.AreEqual(isCorrect, emplazamientoServices.ValidationResult.Status);
        }

    }  
}
