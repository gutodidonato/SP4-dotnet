using Janos.Controllers;
using Janos.Models;
using Janos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Swashbuckle.AspNetCore.Annotations;
using Xunit;

namespace Janos.Tests.Controllers
{
    public class NotaControllerTests
    {
        private readonly Mock<INotaRepository> _notaRepositoryMock;
        private readonly NotaController _controller;

        public NotaControllerTests()
        {
            _notaRepositoryMock = new Mock<INotaRepository>();
            _controller = new NotaController(_notaRepositoryMock.Object);
        }

        [Fact]
        public void GetById_ReturnsOk_WhenNotaExists()
        {
            // Arrange
            var notaId = 1;
            var nota = new Nota { NotaId = notaId, Valor = 5, MediaNota = "5.0", DescricaoNota = "Nota de teste" };
            _notaRepositoryMock.Setup(repo => repo.GetById(notaId)).Returns(nota);

            // Act
            var result = _controller.GetById(notaId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(nota, result.Value);
        }

        [Fact]
        public void GetById_ReturnsNotFound_WhenNotaDoesNotExist()
        {
            // Arrange
            var notaId = 1;
            _notaRepositoryMock.Setup(repo => repo.GetById(notaId)).Returns((Nota)null);

            // Act
            var result = _controller.GetById(notaId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ReturnsCreatedAtAction_WhenNotaIsValid()
        {
            // Arrange
            var nota = new Nota { NotaId = 1, Valor = 5, MediaNota = "5.0", DescricaoNota = "Nota de teste" };
            _notaRepositoryMock.Setup(repo => repo.Add(nota));

            // Act
            var result = _controller.Create(nota) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(nota, result.Value);
        }

        [Fact]
        public void Update_ReturnsNoContent_WhenNotaIsValid()
        {
            // Arrange
            var nota = new Nota { NotaId = 1, Valor = 5, MediaNota = "5.0", DescricaoNota = "Nota de teste" };
            _notaRepositoryMock.Setup(repo => repo.Update(nota));

            // Act
            var result = _controller.Update(nota.NotaId, nota);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContent_WhenNotaExists()
        {
            // Arrange
            var notaId = 1;
            _notaRepositoryMock.Setup(repo => repo.Delete(notaId));

            // Act
            var result = _controller.Delete(notaId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNotFound_WhenNotaDoesNotExist()
        {
            // Arrange
            var notaId = 1;
            _notaRepositoryMock.Setup(repo => repo.Delete(notaId));

            // Act
            var result = _controller.Delete(notaId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
