using Models.RedesNew;
using NUnit.Framework;
using Services.RedesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.RedesNew
{
    public class RedNewTest
    {
        private Models.Enum.Status.StatusEnum isCorrect;
        private RedNew _red;

        [SetUp]
        public void Setup()
        {
            isCorrect = Models.Enum.Status.StatusEnum.Ok;
            _red = new RedNew()
            {
                idRed = 1,
                idMatriz = 1,
                presionRed = 1,
                profundidadRed = 1,
                nombre = "1",
                descripcion = "1",
                isEliminado = false               
            };

        }
        [Test, Order(0)]
        public void Create()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            RedNewServices matrizServices = new RedNewServices(unitOfWork);
            matrizServices.Create(_red);
            Console.WriteLine(matrizServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, matrizServices.ValidationResult.Status);
        }
        [Test, Order(1)]
        public void GetAll()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            RedNewServices matrizServices = new RedNewServices(unitOfWork);
            var ListResult = matrizServices.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(2)]
        public void GetAllNoEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            RedNewServices matrizServices = new RedNewServices(unitOfWork);
            var ListResult = matrizServices.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(3)]
        public void UpdateIsEliminado()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            RedNewServices matrizServices = new RedNewServices(unitOfWork);
            matrizServices.UpdateIsEliminado(_red.idRed, true);
            Assert.AreEqual(isCorrect, matrizServices.ValidationResult.Status);
        }
        [Test, Order(4)]
        public void GetAllEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            RedNewServices matrizServices = new RedNewServices(unitOfWork);
            var ListResult = matrizServices.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(5)]
        public void GetById()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            RedNewServices matrizServices = new RedNewServices(unitOfWork);
            var Result = matrizServices.GetById(_red.idRed);
            Assert.IsNotNull(Result);
        }
        [Test, Order(6)]
        public void Update()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            RedNewServices matrizServices = new RedNewServices(unitOfWork);
            matrizServices.Update(_red);
            Console.WriteLine(matrizServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, matrizServices.ValidationResult.Status);
        }
        [Test, Order(7)]
        public void Remove()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            RedNewServices matrizServices = new RedNewServices(unitOfWork);
            matrizServices.Remove(_red);
            Assert.AreEqual(isCorrect, matrizServices.ValidationResult.Status);
        }
    }
}
