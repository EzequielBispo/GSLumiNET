using GSLumiNET.Domain.Entities;
using GSLumiNET.Infrastructure.AppData;
using GSLumiNET.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace GSLumiNET.Tests.Repositories
{
    public class RegistroRepositoryTests : IDisposable
    {
        private readonly ApplicationContext _context;
        private readonly RegistroRepository _repository;

        public RegistroRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new ApplicationContext(options);
            _repository = new RegistroRepository(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        private void SeedDatabase()
        {
            _context.Registro.AddRange(new List<RegistroEntity>
            {
                new RegistroEntity { Id = 1, Data = System.DateTime.Now, IExterna = 10.5, IInterna = 20.0, ILampada = 30.5 },
                new RegistroEntity { Id = 2, Data = System.DateTime.Now, IExterna = 11.0, IInterna = 21.0, ILampada = 31.0 }
            });
            _context.SaveChanges();
        }

        [Fact]
        public void Adicionar_DeveAdicionarRegistroERetornarRegistro()
        {
            // Arrange
            var novoRegistro = new RegistroEntity
            {
                Id = 3,
                Data = System.DateTime.Now,
                IExterna = 12.5,
                IInterna = 22.0,
                ILampada = 32.5
            };

            // Act
            var resultado = _repository.Adicionar(novoRegistro);

            // Assert
            var registroNoDb = _context.Registro.Find(resultado.Id);
            Assert.NotNull(registroNoDb);
            Assert.Equal(novoRegistro.Id, registroNoDb.Id);
            Assert.Equal(novoRegistro.IExterna, registroNoDb.IExterna);
        }

        [Fact]
        public void Editar_DeveAtualizarRegistroERetornarRegistroAtualizado()
        {
            // Arrange
            SeedDatabase();
            var registroExistente = _context.Registro.First();
            registroExistente.IExterna = 15.0;

            // Act
            var resultado = _repository.Editar(registroExistente);

            // Assert
            var registroNoDb = _context.Registro.Find(resultado.Id);
            Assert.NotNull(registroNoDb);
            Assert.Equal(15.0, registroNoDb.IExterna);
        }

        [Fact]
        public void ObterPorId_DeveRetornarRegistroSeIdExistir()
        {
            // Arrange
            SeedDatabase();

            // Act
            var registro = _repository.ObterPorId(1);

            // Assert
            Assert.NotNull(registro);
            Assert.Equal(1, registro.Id);
        }

        [Fact]
        public void ObterPorId_DeveRetornarNullSeIdNaoExistir()
        {
            // Act
            var registro = _repository.ObterPorId(999);

            // Assert
            Assert.Null(registro);
        }

        [Fact]
        public void ObterTodos_DeveRetornarTodosRegistros()
        {
            // Arrange
            SeedDatabase();

            // Act
            var registros = _repository.ObterTodos();

            // Assert
            Assert.NotEmpty(registros);
            Assert.Equal(2, registros.Count());
        }

        [Fact]
        public void Remover_DeveRemoverRegistroSeIdExistir()
        {
            // Arrange
            SeedDatabase();
            var id = 1;

            // Act
            var registroRemovido = _repository.Remover(id);

            // Assert
            var registroNoDb = _context.Registro.Find(id);
            Assert.Null(registroNoDb);
            Assert.NotNull(registroRemovido);
        }

        [Fact]
        public void Remover_DeveRetornarNullSeIdNaoExistir()
        {
            // Arrange
            SeedDatabase();

            // Act
            var resultado = _repository.Remover(999);

            // Assert
            Assert.Null(resultado);
        }
    }
}
