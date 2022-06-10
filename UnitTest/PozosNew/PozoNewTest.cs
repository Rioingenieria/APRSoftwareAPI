using Models.PozosNew;
using NUnit.Framework;
using Services.PozosNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.PozosNew
{
    public class PozoNewTest
    {
        private Models.Enum.Status.StatusEnum isCorrect;
        private PozoNew _pozo;

        [SetUp]
        public void Setup()
        {
            isCorrect = Models.Enum.Status.StatusEnum.Ok;
            _pozo = new PozoNew()
            {
                idPozo = 1,
                nombre = "1",
                descripcion = "1",
                isEliminado = false
            };

        }
        [Test, Order(0)]
        public void Create()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            PozoNewServices pozoServices = new PozoNewServices(unitOfWork);
            pozoServices.Create(_pozo);
            Console.WriteLine(pozoServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, pozoServices.ValidationResult.Status);
        }
        [Test, Order(1)]
        public void GetAll()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            PozoNewServices pozoServices = new PozoNewServices(unitOfWork);
            var ListResult = pozoServices.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(2)]
        public void GetAllNoEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            PozoNewServices pozoServices = new PozoNewServices(unitOfWork);
            var ListResult = pozoServices.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(3)]
        public void UpdateIsEliminado()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            PozoNewServices pozoServices = new PozoNewServices(unitOfWork);
            pozoServices.UpdateIsEliminado(_pozo.idPozo, true);
            Assert.AreEqual(isCorrect, pozoServices.ValidationResult.Status);
        }
        [Test, Order(4)]
        public void GetAllEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            PozoNewServices pozoServices = new PozoNewServices(unitOfWork);
            var ListResult = pozoServices.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(5)]
        public void GetById()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            PozoNewServices pozoServices = new PozoNewServices(unitOfWork);
            var Result = pozoServices.GetById(_pozo.idPozo);
            Assert.IsNotNull(Result);
        }
        [Test, Order(6)]
        public void Update()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            PozoNewServices pozoServices = new PozoNewServices(unitOfWork);
            pozoServices.Update(_pozo);
            Console.WriteLine(pozoServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, pozoServices.ValidationResult.Status);
        }
        [Test, Order(7)]
        public void Remove()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            PozoNewServices pozoServices = new PozoNewServices(unitOfWork);
            pozoServices.Remove(_pozo);
            Assert.AreEqual(isCorrect, pozoServices.ValidationResult.Status);
        }
    }
}
