
using Models.ConfiguracionesPeriodicosNew;
using NUnit.Framework;
using Services.ConfiguracionesPeriodicasNew;
using System;
using System.Collections.Generic;

namespace UnitTest.CongiguracionesPeriodicosNew
{
    public class ConfiguracionPeriodicoNewTest
    {
        private Models.Enum.Status.StatusEnum isCorrect;
        private ConfiguracionPeriodicoNew Config;

       [SetUp]
        public void Setup()
        {
            isCorrect = Models.Enum.Status.StatusEnum.Ok;
            Config = new ConfiguracionPeriodicoNew()
            {
                idConfiguracionPeriodico = 1,
               adminSubsidio = true,
                isEliminado = false,
                idUsuario = 1,
                fechaCreacion = System.DateTime.Now,
                alcantarillado = false,
                appMovil=true,
                añosSubsidio=1,
                caducado="1",
                cajaVecina="1",
                carpetaMegasync="1",
                colorPrincipal=1,
                colorSecundario=1,
                contarClientesSubsidio_0=true,
                diasAvisoCorte=1,
                diasNoti=1,
                dte="1",
                envioWhatsapp="1",
                exencionIva=true,
                fechaCaducar=System.DateTime.Now,
                finTarifaVerano="1",
                frecuenciaServidor=1,
                informacion="1",
                inicioTarifaVerano="1",
                ivaUsuario=true,
                mesesCtramite=1,
                passwordMegasync="1",  
                periodoInicioServidor=System.DateTime.Now,
                porcentajeConsumo=1,   
                subsidio=1,
                subsidioIva=true,
                subsidioSoloAgua=true,
                tipoServicio=1,
                tramoSubsidio=true,
                ultimaBoleta=true,
                usuarioMegasync="1",
                version="1",
                diasVencimiento=1,
                funcionEscalonada=true,
                mesesSubsidio=1
                
            };
        }

       [Test]
        public void Create()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionPeriodicaNewServices config = new ConfiguracionPeriodicaNewServices(unitOfWork);
             config.create(Config);
            Console.WriteLine(config.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, config.ValidationResult.Status);
        }
        [Test]
        public void GetAll()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionPeriodicaNewServices config = new ConfiguracionPeriodicaNewServices(unitOfWork);
            var ListResult = config.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            Assert.IsNotEmpty(ListResult);
        }
        [Test]
        public void UpdateIsEliminado()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionPeriodicaNewServices config = new ConfiguracionPeriodicaNewServices(unitOfWork);
            config.UpdateIsEliminado(Config.idConfiguracionPeriodico, true);
            Console.WriteLine(config.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, config.ValidationResult.Status);
        }
        [Test]
        public void GetAllDelete()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionPeriodicaNewServices config = new ConfiguracionPeriodicaNewServices(unitOfWork);
            var ListResult = config.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test]
        public void GetAllNotDelete()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionPeriodicaNewServices config = new ConfiguracionPeriodicaNewServices(unitOfWork);
            var ListResult = config.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test]
        public void GetById()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionPeriodicaNewServices config = new ConfiguracionPeriodicaNewServices(unitOfWork);
            var Result = config.GetById(Config.idConfiguracionPeriodico);
            Assert.IsNotNull(Result);
        }
        [Test]
        public void Update()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionPeriodicaNewServices config = new ConfiguracionPeriodicaNewServices(unitOfWork);
             config.Update(Config);
            Console.WriteLine(config.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, config.ValidationResult.Status);
        }
        [Test]
        public void Remove()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            ConfiguracionPeriodicaNewServices config = new ConfiguracionPeriodicaNewServices(unitOfWork);
            config.Remove(Config);
            Console.WriteLine(config.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, config.ValidationResult.Status);
        }
    }
}
