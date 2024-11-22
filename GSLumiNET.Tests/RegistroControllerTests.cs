using Xunit;
using Moq;
using GSLumiNET.Domain.Entities;
using GSLumiNET.Domain.Interfaces;
using GSLumiNET.Application.Services;
using System;
using System.Collections.Generic;

namespace GSLumiNET.Tests.Services
{
    public class RegistroServiceTests
    {
        private readonly Mock<IRegistroRepository> _repositoryMock;
        private readonly RegistroService _registroService;

        public RegistroServiceTests()
        {
            _repositoryMock = new Mock<IRegistroRepository>();
            _registroService = new RegistroService(_repositoryMock.Object);
        }

        [Fact]
        public void AdicionarRegistro_DeveChamarRepositorioEAdicionarRegistro()
        {
            // Arrange
            var registro = new RegistroEntity
            {
                Id = 1,
                Data = DateTime.Now,
                IExterna = 20.0,
                IInterna = 15.0,
                ILampada = 10.0
            };

            _repositoryMock.Setup(r => r.Adicionar(It.IsAny<RegistroEntity>())).Returns(registro);

            // Act
            var resultado = _registroService.AdicionarRegistro(registro);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(registro.Id, resultado.Id);
            _repositoryMock.Verify(r => r.Adicionar(It.IsAny<RegistroEntity>()), Times.Once);
        }

        [Fact]
        public void AdicionarRegistro_DeveLancarExcecao_QuandoRegistroForNulo()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _registroService.AdicionarRegistro(null));
        }

        [Fact]
        public void ObterPorId_DeveRetornarRegistro_QuandoIdExistir()
        {
            // Arrange
            var registro = new RegistroEntity
            {
                Id = 1,
                Data = DateTime.Now,
                IExterna = 20.0,
                IInterna = 15.0,
                ILampada = 10.0
            };

            _repositoryMock.Setup(r => r.ObterPorId(registro.Id)).Returns(registro);

            // Act
            var resultado = _registroService.ObterPorId(registro.Id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(registro.Id, resultado.Id);
            _repositoryMock.Verify(r => r.ObterPorId(registro.Id), Times.Once);
        }

        [Fact]
        public void ObterPorId_DeveLancarExcecao_QuandoRegistroNaoExistir()
        {
            // Arrange
            var registroId = 999;

            _repositoryMock.Setup(r => r.ObterPorId(registroId)).Returns((RegistroEntity)null);

            // Act & Assert
            var ex = Assert.Throws<KeyNotFoundException>(() => _registroService.ObterPorId(registroId));
            Assert.Equal($"Registro com ID {registroId} não encontrado.", ex.Message);
        }

        [Fact]
        public void EditarRegistro_DeveChamarRepositorioEAtualizarRegistro()
        {
            // Arrange
            var registro = new RegistroEntity
            {
                Id = 1,
                Data = DateTime.Now,
                IExterna = 30.0,
                IInterna = 25.0,
                ILampada = 20.0
            };

            _repositoryMock.Setup(r => r.Editar(It.IsAny<RegistroEntity>())).Returns(registro);

            // Act
            var resultado = _registroService.EditarRegistro(registro);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(registro.Id, resultado.Id);
            _repositoryMock.Verify(r => r.Editar(It.IsAny<RegistroEntity>()), Times.Once);
        }

        [Fact]
        public void EditarRegistro_DeveLancarExcecao_QuandoRegistroForNulo()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _registroService.EditarRegistro(null));
        }

        [Fact]
        public void RemoverRegistro_DeveRemoverRegistro_QuandoIdExistir()
        {
            // Arrange
            var registro = new RegistroEntity
            {
                Id = 1,
                Data = DateTime.Now,
                IExterna = 30.0,
                IInterna = 25.0,
                ILampada = 20.0
            };

            _repositoryMock.Setup(r => r.Remover(registro.Id)).Returns(registro);

            // Act
            var resultado = _registroService.RemoverRegistro(registro.Id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(registro.Id, resultado.Id);
            _repositoryMock.Verify(r => r.Remover(registro.Id), Times.Once);
        }

        [Fact]
        public void RemoverRegistro_DeveLancarExcecao_QuandoRegistroNaoExistir()
        {
            // Arrange
            var registroId = 999;

            _repositoryMock.Setup(r => r.Remover(registroId)).Returns((RegistroEntity)null);

            // Act & Assert
            var ex = Assert.Throws<KeyNotFoundException>(() => _registroService.RemoverRegistro(registroId));
            Assert.Equal($"Registro com ID {registroId} não encontrado.", ex.Message);
        }

        [Fact]
        public void ObterTodos_DeveRetornarListaDeRegistros()
        {
            // Arrange
            var registros = new List<RegistroEntity>
            {
                new RegistroEntity { Id = 1, Data = DateTime.Now, IExterna = 20.0, IInterna = 15.0, ILampada = 10.0 },
                new RegistroEntity { Id = 2, Data = DateTime.Now, IExterna = 25.0, IInterna = 20.0, ILampada = 15.0 }
            };

            _repositoryMock.Setup(r => r.ObterTodos()).Returns(registros);

            // Act
            var resultado = _registroService.ObterTodos();

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(2, ((List<RegistroEntity>)resultado).Count);
            _repositoryMock.Verify(r => r.ObterTodos(), Times.Once);
        }
    }
}
