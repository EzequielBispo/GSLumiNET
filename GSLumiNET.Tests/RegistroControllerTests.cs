using Microsoft.AspNetCore.Mvc;
using Moq;
using GSLumiNET.API.Controllers;
using GSLumiNET.Application.Services;
using GSLumiNET.Domain.Entities;
using System.Collections.Generic;
using Xunit;

namespace GSLumiNET.Tests.Controllers
{
    public class RegistroControllerTests
    {
        private readonly Mock<RegistroService> _mockRegistroService;
        private readonly RegistroController _registroController;

        public RegistroControllerTests()
        {
            _mockRegistroService = new Mock<RegistroService>();
            _registroController = new RegistroController(_mockRegistroService.Object);
        }

        [Fact]
        public void ObterPorId_DeveRetornarOk_QuandoRegistroExistir()
        {
            // Arrange
            var registroId = 1;
            var registro = new RegistroEntity { Id = registroId, Data = System.DateTime.Now, IExterna = 10, IInterna = 20, ILampada = 30 };

            _mockRegistroService.Setup(service => service.ObterPorId(registroId)).Returns(registro);

            // Act
            var result = _registroController.ObterPorId(registroId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(registro, okResult.Value);
        }

        [Fact]
        public void ObterPorId_DeveRetornarNotFound_QuandoRegistroNaoExistir()
        {
            // Arrange
            var registroId = 1;

            _mockRegistroService.Setup(service => service.ObterPorId(registroId)).Returns((RegistroEntity)null);

            // Act
            var result = _registroController.ObterPorId(registroId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void ObterTodos_DeveRetornarOk_ComListaDeRegistros()
        {
            // Arrange
            var registros = new List<RegistroEntity>
            {
                new RegistroEntity { Id = 1, Data = System.DateTime.Now, IExterna = 10, IInterna = 20, ILampada = 30 },
                new RegistroEntity { Id = 2, Data = System.DateTime.Now, IExterna = 15, IInterna = 25, ILampada = 35 }
            };

            _mockRegistroService.Setup(service => service.ObterTodos()).Returns(registros);

            // Act
            var result = _registroController.ObterTodos();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(registros, okResult.Value);
        }

        [Fact]
        public void AdicionarRegistro_DeveRetornarCreatedAtAction_QuandoRegistroValido()
        {
            // Arrange
            var novoRegistro = new RegistroEntity { Id = 1, Data = System.DateTime.Now, IExterna = 10, IInterna = 20, ILampada = 30 };

            _mockRegistroService.Setup(service => service.AdicionarRegistro(novoRegistro)).Returns(novoRegistro);

            // Act
            var result = _registroController.AdicionarRegistro(novoRegistro);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(novoRegistro, createdAtActionResult.Value);
        }

        [Fact]
        public void AdicionarRegistro_DeveRetornarBadRequest_QuandoRegistroInvalido()
        {
            // Arrange
            RegistroEntity novoRegistro = null;

            // Act
            var result = _registroController.AdicionarRegistro(novoRegistro);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void EditarRegistro_DeveRetornarOk_QuandoAtualizacaoBemSucedida()
        {
            // Arrange
            var registroId = 1;
            var registroAtualizado = new RegistroEntity { Id = registroId, Data = System.DateTime.Now, IExterna = 10, IInterna = 20, ILampada = 30 };

            _mockRegistroService.Setup(service => service.EditarRegistro(registroAtualizado)).Returns(registroAtualizado);

            // Act
            var result = _registroController.EditarRegistro(registroId, registroAtualizado);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(registroAtualizado, okResult.Value);
        }

        [Fact]
        public void RemoverRegistro_DeveRetornarOk_QuandoRemocaoBemSucedida()
        {
            // Arrange
            var registroId = 1;
            var registroRemovido = new RegistroEntity { Id = registroId, Data = System.DateTime.Now, IExterna = 10, IInterna = 20, ILampada = 30 };

            _mockRegistroService.Setup(service => service.RemoverRegistro(registroId)).Returns(registroRemovido);

            // Act
            var result = _registroController.RemoverRegistro(registroId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal($"Registro com ID {registroId} removido com sucesso.", okResult.Value);
        }

        [Fact]
        public void RemoverRegistro_DeveRetornarNotFound_QuandoRegistroNaoExistir()
        {
            // Arrange
            var registroId = 1;

            _mockRegistroService.Setup(service => service.RemoverRegistro(registroId)).Returns((RegistroEntity)null);

            // Act
            var result = _registroController.RemoverRegistro(registroId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

    }
}
