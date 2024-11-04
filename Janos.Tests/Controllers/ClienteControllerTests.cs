using Janos.Controllers;
using Janos.Models;
using Janos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Janos.Tests
{
    public class ClienteControllerTests
    {
        private readonly Mock<IClienteRepository> _mockRepository;
        private readonly ClienteController _controller;

        public ClienteControllerTests()
        {
            _mockRepository = new Mock<IClienteRepository>();
            _controller = new ClienteController(_mockRepository.Object);
        }

        [Fact]
        public void GetById_ReturnsOkResult_WhenClienteExists()
        {
            // Arrange
            var clienteId = 1;
            var cliente = new Cliente { ClienteId = clienteId, Nome = "Teste", Email = "teste@example.com" };
            _mockRepository.Setup(repo => repo.GetById(clienteId)).Returns(cliente);

            // Act
            var result = _controller.GetById(clienteId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnCliente = Assert.IsType<Cliente>(okResult.Value);
            Assert.Equal(clienteId, returnCliente.ClienteId);
        }

        [Fact]
        public void GetById_ReturnsNotFound_WhenClienteDoesNotExist()
        {
            // Arrange
            var clienteId = 1;
            _mockRepository.Setup(repo => repo.GetById(clienteId)).Returns((Cliente)null);

            // Act
            var result = _controller.GetById(clienteId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

            [Fact]
            public void Create_ReturnsCreatedAtAction_WhenClienteIsValid()
            {
                // Arrange
                var cliente = new Cliente { ClienteId = 1, Nome = "Test", Email = "test@example.com", Cpf = "12345678901" };
                var mockRepo = new Mock<IClienteRepository>();
                mockRepo.Setup(repo => repo.Add(cliente)).Verifiable(); 
                var controller = new ClienteController(mockRepo.Object);

                // Act
                var result = controller.Create(cliente);

                // Assert
                var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
                Assert.Equal(nameof(ClienteController.GetById), createdAtActionResult.ActionName); 
                Assert.Equal(cliente.ClienteId, createdAtActionResult.RouteValues["id"]); 
                mockRepo.Verify(repo => repo.Add(cliente), Times.Once);
            }

        [Fact]
        public void Create_ReturnsBadRequest_WhenClienteIsNull()
        {
            // Act
            var result = _controller.Create(null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Update_ReturnsNoContent_WhenClienteIsValid()
        {
            // Arrange
            var clienteId = 1;
            var cliente = new Cliente { ClienteId = clienteId, Nome = "Cliente Atualizado" };
            _mockRepository.Setup(repo => repo.GetById(clienteId)).Returns(cliente);
            _mockRepository.Setup(repo => repo.Update(cliente)).Verifiable();

            // Act
            var result = _controller.Update(clienteId, cliente);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _mockRepository.Verify(repo => repo.Update(cliente), Times.Once);
        }

        [Fact]
        public void Update_ReturnsBadRequest_WhenIdsDoNotMatch()
        {
            // Arrange
            var cliente = new Cliente { ClienteId = 1, Nome = "Cliente Atualizado" };

            // Act
            var result = _controller.Update(2, cliente); // ID não corresponde

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContent_WhenClienteExists()
        {
            // Arrange
            var clienteId = 1;
            _mockRepository.Setup(repo => repo.GetById(clienteId)).Returns(new Cliente { ClienteId = clienteId });

            // Act
            var result = _controller.Delete(clienteId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNotFound_WhenClienteDoesNotExist()
        {
            // Arrange
            var clienteId = 1;
            _mockRepository.Setup(repo => repo.GetById(clienteId)).Returns((Cliente)null);

            // Act
            var result = _controller.Delete(clienteId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
