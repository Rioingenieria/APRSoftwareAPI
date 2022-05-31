
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
                id_configuracion_periodico = 9,
               admin_subsidio = true,
                is_eliminado = false,
                id_usuario = 1,
                fecha_creacion = System.DateTime.Now,
                alcantarillado = false,
                app_movil=true,
                años_subsidio=1,
                caducado="1",
                caja_vecina="1",
                carpeta_megasync="1",
                color_principal=1,
                color_secundario=1,
                contar_clientes_subsidio_0=true,
                dias_aviso_corte=1,
                dias_noti=1,
                dte="1",
                envio_whatsapp="1",
                exencion_iva=true,
                fecha_caducar=System.DateTime.Now,
                fin_tarifa_verano="1",
                frecuencia_servidor=1,
                informacion="1",
                inicio_tarifa_verano="1",
                iva_usuario=true,
                meses_ctramite=1,
                password_megasync="1",  
                periodo_inicio_servidor=System.DateTime.Now,
                porcentaje_consumo=1,   
                subsidio=1,
                subsidio_iva=true,
                subsidio_solo_agua=true,
                tipo_servicio=1,
                tramo_subsidio=true,
                ultima_boleta=true,
                usuario_megasync="1",
                version="1",
                dias_vencimiento=1,
                funcion_escalonada=true,
                meses_subsidio=1
                
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
            config.UpdateIsEliminado(Config.id_configuracion_periodico, true);
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
            var Result = config.GetById(5);
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
