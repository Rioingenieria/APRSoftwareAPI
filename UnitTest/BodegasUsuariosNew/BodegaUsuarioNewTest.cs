using Models.Inventory.BodegasNew;
using Models.Inventory.BodegasUsuariosNew;
using Models.Usuarios;
using NUnit.Framework;
using Services.Inventory.BodegasUsuariosNewServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.Enum.GetAll;

namespace UnitTest.BodegasUsuariosNew
{
    public class BodegaUsuarioNewTest
    {
        private BodegaUsuarioNew bodegaUsuarioNew;
        private List<BodegaUsuarioNew> listaUsuarioBodegaNew;
        private bool isEliminado = true;

        [SetUp]
        public void Setup()
        {
            BodegaNew bodegaNew = new BodegaNew()
            {
                IdBodega = 1,
                Nombre = "bodega 1",
                Descripcion = "bodega principal",
                Direccion = "direccion 01",
                Telefono = "12345",
                Correo = "email@mail.com",
                IdUsuario = 1,
                IdUsuarioEncargado = 1,
                FechaCreacion = DateTime.Now,
                IsEliminado = false
            };

            MemoryStream ms = new MemoryStream();
            Usuario usuario = new Usuario()
            {
                IdUsuario = 5,
                NombreUsuario = "user",
                Nombre = "usuario",
                Apellido = "uno",
                Rut = "11111111-1",
                Cargo = "usuario",
                Contraseña = "123",
                IdTipoUsuario = 1,
                TipoUsuario = "tipo 01",
                FechaNacimiento = DateTime.Now,
                Email = "usuario@mail.com",
                ContraseñaGenerada = false,
                FotoUrl = "",
                Foto = ms.GetBuffer(),
                IsEliminado = false
            };

            bodegaUsuarioNew = new BodegaUsuarioNew()
            {
                BodegaNew = bodegaNew,
                Usuario = usuario
            };
        }
        [Test, Order(0)]
        public void GetByIdTest()
        {

            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            BodegaUsuarioNewServices bodegaUsuarioNewServices = new BodegaUsuarioNewServices(unitOfWork);
            var resultado = bodegaUsuarioNewServices.GetById(bodegaUsuarioNew.BodegaNew.IdBodega);
            Assert.AreEqual(resultado.BodegaNew.IdBodega, 1);
        }

        [Test, Order(1)]
        public void GetAllTest()
        {

            UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkInventarioSqlServer.UnitOfWorkInventarioSqlServer();
            BodegaUsuarioNewServices bodegaUsuarioNewServices = new BodegaUsuarioNewServices(unitOfWork);
            listaUsuarioBodegaNew = bodegaUsuarioNewServices.GetAll(GetAllEnum.Eliminados);
            Assert.IsNotEmpty(listaUsuarioBodegaNew);
        }
    }
}
