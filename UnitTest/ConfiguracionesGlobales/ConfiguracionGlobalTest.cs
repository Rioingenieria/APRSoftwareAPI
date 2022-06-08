using Models.ConfiguracionesGlobales;
using NUnit.Framework;
using Services.ConfiguracionesGlobales;
using System;
using System.Collections.Generic;
using UnitOfWorkSqlServer;

namespace UnitTest.ConfiguracionesGlobales
{
    public class ConfiguracionGlobalTest
    {
        private Models.Enum.Status.StatusEnum isCorrect;
        private ConfiguracionGlobal ConfigGlobal;
        [SetUp]
        public void Setup()
        {
            isCorrect = Models.Enum.Status.StatusEnum.Ok;
            ConfigGlobal = new ConfiguracionGlobal()
            {
                id_configuracion = 1,
                web = true,
                is_eliminado = false,
                id_usuario = 1,
                fecha_creacion = System.DateTime.Now,
                is_ambiente_produccion = false
            };
        }
        [Test]
        public void Create()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionGlobalServices config = new ConfiguracionGlobalServices(unitOfWork);
            config.create(ConfigGlobal);
            Console.WriteLine(config.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect,config.ValidationResult.Status);
        }
        [Test]
        public void GetAll()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionGlobalServices config = new ConfiguracionGlobalServices(unitOfWork);
            var ListResult = config.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            Assert.IsNotEmpty(ListResult);
        }
        [Test]
        public void UpdateIsEliminado()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionGlobalServices config = new ConfiguracionGlobalServices(unitOfWork);
            config.UpdateIsEliminado(ConfigGlobal.id_configuracion, true);
            Console.WriteLine(config.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, config.ValidationResult.Status);
        }
        [Test]
        public void GetAllDelete()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionGlobalServices config = new ConfiguracionGlobalServices(unitOfWork);
            var ListResult = config.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test]
        public void GetAllNotDelete()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionGlobalServices config = new ConfiguracionGlobalServices(unitOfWork);
            var ListResult = config.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test]
        public void GetById()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionGlobalServices config = new ConfiguracionGlobalServices(unitOfWork);
            var Result = config.GetById(ConfigGlobal.id_configuracion);
            Assert.IsNotNull(Result);
        }
        [Test]
        public void Update()
        {
            Setup();
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionGlobalServices config = new ConfiguracionGlobalServices(unitOfWork);
             config.Update(ConfigGlobal);
            Console.WriteLine(config.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, config.ValidationResult.Status);
        }
        [Test]
        public void Remove()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionGlobalServices config = new ConfiguracionGlobalServices(unitOfWork);
            var Result = config.Remove(ConfigGlobal);
            Assert.AreEqual(isCorrect,config.ValidationResult.Status);
        }
    }
}
