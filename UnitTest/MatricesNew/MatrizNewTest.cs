using Models.MatricesNew;
using NUnit.Framework;
using Services.MatricesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.MatricesNew
{
    public class MatrizNewTest
    {
        private Models.Enum.Status.StatusEnum isCorrect;
        private MatrizNew _matriz;

        [SetUp]
        public void Setup()
        {
            isCorrect = Models.Enum.Status.StatusEnum.Ok;
            _matriz = new MatrizNew()
            {
                idMatriz = 1,
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
            MatrizNewServices matrizServices = new MatrizNewServices(unitOfWork);
            matrizServices.Create(_matriz);
            Console.WriteLine(matrizServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, matrizServices.ValidationResult.Status);
        }
        [Test, Order(1)]
        public void GetAll()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            MatrizNewServices matrizServices = new MatrizNewServices(unitOfWork);
            var ListResult = matrizServices.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(2)]
        public void GetAllNoEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            MatrizNewServices matrizServices = new MatrizNewServices(unitOfWork);
            var ListResult = matrizServices.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(3)]
        public void UpdateIsEliminado()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            MatrizNewServices matrizServices = new MatrizNewServices(unitOfWork);
            matrizServices.UpdateIsEliminado(_matriz.idMatriz, true);
            Assert.AreEqual(isCorrect, matrizServices.ValidationResult.Status);
        }
        [Test, Order(4)]
        public void GetAllEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            MatrizNewServices matrizServices = new MatrizNewServices(unitOfWork);
            var ListResult = matrizServices.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(5)]
        public void GetById()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            MatrizNewServices matrizServices = new MatrizNewServices(unitOfWork);
            var Result = matrizServices.GetById(_matriz.idMatriz);
            Assert.IsNotNull(Result);
        }
        [Test, Order(6)]
        public void Update()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            MatrizNewServices matrizServices = new MatrizNewServices(unitOfWork);
            matrizServices.Update(_matriz);
            Console.WriteLine(matrizServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, matrizServices.ValidationResult.Status);
        }
        [Test, Order(7)]
        public void Remove()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            MatrizNewServices matrizServices = new MatrizNewServices(unitOfWork);
            matrizServices.Remove(_matriz);
            Assert.AreEqual(isCorrect, matrizServices.ValidationResult.Status);
        }
    }
}
