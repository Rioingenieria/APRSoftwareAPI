using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Encriptacion;
using Models.Usuarios;
using NUnit.Framework;
using Services.Usuarios;

namespace UnitTest
{
    public class UsuarioTest
    {
        public Usuario usuario;
        private List<Usuario> listaUsuario;
        private bool isEliminado = true;

        [SetUp]
        public void Setup()
        {

            MemoryStream ms = new MemoryStream();

            usuario = new Usuario()
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
        }

        [Test, Order(0)]
        public void CreateTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            UsuarioServices usuarioServices = new UsuarioServices(unitOfWork);
            var resultado = usuarioServices.Create(usuario);
            Assert.AreEqual(resultado, 1);
        }
        [Test, Order(1)]
        public void UpdateTest()
        {
            usuario.NombreUsuario = "user01";
            usuario.Nombre = "Usuario";
            usuario.Apellido = "Nuevo";
            usuario.Contraseña = Encriptacion.EncriptarSha256(usuario.Contraseña);
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            UsuarioServices usuarioServices = new UsuarioServices(unitOfWork);
            var resultado = usuarioServices.Update(usuario);
            Assert.AreEqual(resultado, 1);
        }

        [Test, Order(2)]
        public void GetByIdTest()
        {
            usuario.IdUsuario = 5;
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            UsuarioServices usuarioServices = new UsuarioServices(unitOfWork);
            var resultado = usuarioServices.GetById(usuario.IdUsuario);
            Assert.AreEqual(resultado.IdUsuario, 5);
        }

        [Test, Order(3)]
        public void GetAllTest()
        {
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            UsuarioServices usuarioServices = new UsuarioServices(unitOfWork);
            listaUsuario = usuarioServices.GetAll();
            Assert.IsNotEmpty(listaUsuario);
        }

        [Test, Order(4)]
        public void UpdateSoftDeleteTest()
        {
            usuario.IdUsuario = 5;
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            UsuarioServices usuarioServices = new UsuarioServices(unitOfWork);
            var resultado = usuarioServices.UpdateSoftDelete(usuario.IdUsuario, isEliminado);
            Assert.AreEqual(resultado, 1);
        }

        [Test, Order(5)]
        public void IsExistTest()
        {
            usuario.Nombre = "Usuario 05";
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            UsuarioServices usuarioServices = new UsuarioServices(unitOfWork);
            var resultado = usuarioServices.IsExistNombreUsuario(usuario.Nombre);
            Assert.AreEqual(resultado, false);
        }

        [Test, Order(6)]
        public void RemoveTest()
        {
            usuario.IdUsuario = 5;
            UnitOfWorkSqlServer.UnitOfWorkSqlServer unitOfWork = new UnitOfWorkSqlServer.UnitOfWorkSqlServer();
            UsuarioServices usuarioServices = new UsuarioServices(unitOfWork);
            var resultado = usuarioServices.Remove(usuario);
            Assert.AreEqual(resultado, 1);
        }
    }
}
