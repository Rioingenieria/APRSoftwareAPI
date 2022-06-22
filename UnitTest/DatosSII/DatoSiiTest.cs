using Models.DatosSII;
using NUnit.Framework;
using Services.DatosSII;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.DatosSII
{
    public class DatoSiiTest
    {
        private Models.Enum.Status.StatusEnum isCorrect;
        private DatoSii _datoSii;

        [SetUp]
        public void Setup()
        {
            isCorrect = Models.Enum.Status.StatusEnum.Ok;
            _datoSii = new DatoSii()
            {
                idEmpresa = 5,
                rut="1",
                razonSocial = "1",
                rutCertificado="1",
                nombreCertificado="1",
                giro="1",
                direccion="1",
                comuna="1",
                codigoActividades="1",
                fechaAutorizacion=DateTime.Now,
                numeroResolucion="1",
                ciudad="1",
                razonSocialBoleta="1",
                giroBoleta="1",
                unidadSii="1",
                telefono="1",
                correo="1",
                idAprGlobal=1,
                datosSiiServidor=true,
                telefonoEmergencia="1",
                tipoEmpresa="1",
                facebook="1",  
                paginaWeb="1",
                fechaResolucion=DateTime.Now,
                codigoLicenciatura=1,
                nombreLicenciatura="1",
                codigoRegion="1",
                nombreRegion="1",
                codigoComuna="1",
                nombreComuna="1",
                isEliminado = false
            };

        }
        [Test, Order(0)]
        public void Create()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoSiiServices redServices = new DatoSiiServices(unitOfWork);
            redServices.Create(_datoSii);
            Console.WriteLine(redServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, redServices.ValidationResult.Status);
        }
        [Test, Order(1)]
        public void GetAll()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoSiiServices redServices = new DatoSiiServices(unitOfWork);
            var ListResult = redServices.GetAll(Models.Enum.GetAll.GetAllEnum.Todos);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(2)]
        public void GetAllNoEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoSiiServices redServices = new DatoSiiServices(unitOfWork);
            var ListResult = redServices.GetAll(Models.Enum.GetAll.GetAllEnum.NoEliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(3)]
        public void UpdateIsEliminado()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoSiiServices redServices = new DatoSiiServices(unitOfWork);
            redServices.UpdateIsEliminado(_datoSii.idEmpresa, true);
            Assert.AreEqual(isCorrect, redServices.ValidationResult.Status);
        }
        [Test, Order(4)]
        public void GetAllEliminados()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoSiiServices redServices = new DatoSiiServices(unitOfWork);
            var ListResult = redServices.GetAll(Models.Enum.GetAll.GetAllEnum.Eliminados);
            Assert.IsNotEmpty(ListResult);
        }
        [Test, Order(5)]
        public void GetById()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoSiiServices redServices = new DatoSiiServices(unitOfWork);
            var Result = redServices.GetById(_datoSii.idEmpresa);
            Assert.IsNotNull(Result);
        }
        [Test, Order(6)]
        public void Update()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoSiiServices redServices = new DatoSiiServices(unitOfWork);
            redServices.Update(_datoSii);
            Console.WriteLine(redServices.ValidationResult.Message.ToString());
            Assert.AreEqual(isCorrect, redServices.ValidationResult.Status);
        }
        [Test, Order(7)]
        public void Remove()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            DatoSiiServices redServices = new DatoSiiServices(unitOfWork);
            redServices.Remove(_datoSii);
            Assert.AreEqual(isCorrect, redServices.ValidationResult.Status);
        }
    }
}
