using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using GSLumiNET.Application.Services;
using GSLumiNET.Domain.Entities;
using GSLumiNET.Domain.Interfaces;
using System.Collections.Generic;

namespace GSLumiNET.Tests
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
        public void AdicionarRegistro_DeveRetornarRegistroEntity_QuandoAdicionarComSucesso()
        {
            // Arrange
            var registro = new RegistroEntity
            {
                Id = 1,
                Data = DateTime.Now,
                IExterna = 1.5,
                IInterna = 2.5,
                ILampada = 3.5
            };

            _repositoryMock.Setup(r => r.Adicionar(It.IsAny<RegistroEntity>())).Returns(registro);

            // Act
            var resultado = _registroService.AdicionarRegistro(registro);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(registro.Id, resultado.Id);
            Assert.Equal(registro.IExterna, resultado.IExterna);
            Assert.Equal(registro.IInterna, resultado.IInterna);
            Assert.Equal(registro.ILampada, resultado.ILampada);
        }

        [Fact]
        public void ObterPorId_DeveRetornarRegistroEntity_QuandoIdExistente()
        {
            // Arrange
            int registroId = 1;
            var registroEsperado = new RegistroEntity
            {
                Id = registroId,
                Data = DateTime.Now,
                IExterna = 1.5,
                IInterna = 2.5,
                ILampada = 3.5
            };

            _repositoryMock.Setup(r => r.ObterPorId(registroId)).Returns(registroEsperado);

            // Act
            var resultado = _registroService.ObterPorId(registroId);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(registroEsperado.Id, resultado.Id);
            Assert.Equal(registroEsperado.IExterna, resultado.IExterna);
            Assert.Equal(registroEsperado.IInterna, resultado.IInterna);
            Assert.Equal(registroEsperado.ILampada, resultado.ILampada);
        }

        [Fact]
        public void EditarRegistro_DeveRetornarRegistroEntity_QuandoEditarComSucesso()
        {
            // Arrange
            var registroParaEditar = new RegistroEntity
            {
                Id = 1,
                Data = DateTime.Now,
                IExterna = 1.0,
                IInterna = 1.5,
                ILampada = 2.0
            };

            var registroEditado = new RegistroEntity
            {
                Id = 1,
                Data = DateTime.Now.AddDays(1),
                IExterna = 2.0,
                IInterna = 3.0,
                ILampada = 4.0
            };

            _repositoryMock.Setup(r => r.Editar(It.IsAny<RegistroEntity>())).Returns(registroEditado);

            // Act
            var resultado = _registroService.EditarRegistro(registroParaEditar);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(registroEditado.Id, resultado.Id);
            Assert.Equal(registroEditado.IExterna, resultado.IExterna);
            Assert.Equal(registroEditado.IInterna, resultado.IInterna);
            Assert.Equal(registroEditado.ILampada, resultado.ILampada);
        }

        [Fact]
        public void RemoverRegistro_DeveRetornarRegistroEntity_QuandoRemoverComSucesso()
        {
            // Arrange
            int registroId = 1;
            var registroParaRemover = new RegistroEntity
            {
                Id = registroId,
                Data = DateTime.Now,
                IExterna = 1.0,
                IInterna = 2.0,
                ILampada = 3.0
            };

            _repositoryMock.Setup(r => r.Remover(registroId)).Returns(registroParaRemover);

            // Act
            var resultado = _registroService.RemoverRegistro(registroId);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(registroParaRemover.Id, resultado.Id);
            Assert.Equal(registroParaRemover.IExterna, resultado.IExterna);
            Assert.Equal(registroParaRemover.IInterna, resultado.IInterna);
            Assert.Equal(registroParaRemover.ILampada, resultado.ILampada);
        }

        [Fact]
        public void ObterTodos_DeveRetornarListaDeRegistros_QuandoExistiremRegistros()
        {
            // Arrange
            var listaDeRegistros = new List<RegistroEntity>
            {
                new RegistroEntity { Id = 1, Data = DateTime.Now, IExterna = 1.0, IInterna = 1.5, ILampada = 2.0 },
                new RegistroEntity { Id = 2, Data = DateTime.Now, IExterna = 2.0, IInterna = 2.5, ILampada = 3.0 }
            };

            _repositoryMock.Setup(r => r.ObterTodos()).Returns(listaDeRegistros);

            // Act
            var resultado = _registroService.ObterTodos();

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count());
            Assert.Contains(resultado, r => r.Id == 1);
            Assert.Contains(resultado, r => r.Id == 2);
        }
    }
}
