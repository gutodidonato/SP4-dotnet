using Janos.Controllers;
using Janos.Models;
using Janos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Janos.Tests.Controllers
{
    public class LojaControllerTests
    {
        private readonly Mock<ILojaRepository> _lojaRepositoryMock;
        private readonly LojaController _controller;

        public LojaControllerTests()
        {
            _lojaRepositoryMock = new Mock<ILojaRepository>();
            _controller = new LojaController(_lojaRepositoryMock.Object);
        }

        [Fact]
        public void GetById_ReturnsOkResult_WhenLojaExists()
        {
            // Arrange
            var lojaId = 1;
            var loja = new Loja { LojaId = lojaId, Nome = "Loja Teste" };
            _lojaRepositoryMock.Setup(repo => repo.GetById(lojaId)).Returns(loja);

            // Act
            var result = _controller.GetById(lojaId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedLoja = Assert.IsType<Loja>(okResult.Value);
            Assert.Equal(lojaId, returnedLoja.LojaId);
        }

        [Fact]
        public void GetById_ReturnsNotFound_WhenLojaDoesNotExist()
        {
            // Arrange
            var lojaId = 2;
            _lojaRepositoryMock.Setup(repo => repo.GetById(lojaId)).Returns((Loja)null);

            // Act
            var result = _controller.GetById(lojaId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ReturnsCreatedAtAction_WhenLojaIsCreated()
        {
            // Arrange
            var loja = new Loja { LojaId = 3, Nome = "Nova Loja" };
            _lojaRepositoryMock.Setup(repo => repo.Add(loja));

            // Act
            var result = _controller.Create(loja);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedLoja = Assert.IsType<Loja>(createdResult.Value);
            Assert.Equal(loja.LojaId, returnedLoja.LojaId);
        }

        [Fact]
        public void GetByNotaMinima_ReturnsOkResult_WhenLojasExist()
        {
            // Arrange
            var notaMinima = 4;
            var lojas = new List<Loja>
            {
                new Loja { LojaId = 1, Nome = "Loja 1" },
                new Loja { LojaId = 2, Nome = "Loja 2" }
            };
            _lojaRepositoryMock.Setup(repo => repo.GetByNotaMinima(notaMinima)).Returns(lojas);

            // Act
            var result = _controller.GetByNotaMinima(notaMinima);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedLojas = Assert.IsType<List<Loja>>(okResult.Value);
            Assert.Equal(2, returnedLojas.Count);
        }

        [Fact]
        public void Update_ReturnsNoContent_WhenLojaIsUpdated()
        {
            // Arrange
            var lojaId = 1;
            var loja = new Loja { LojaId = lojaId, Nome = "Loja Atualizada" };

            // Act
            var result = _controller.Update(lojaId, loja);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContent_WhenLojaIsDeleted()
        {
            // Arrange
            var lojaId = 1;

            // Act
            var result = _controller.Delete(lojaId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
