using Janos.Controllers;
using Janos.Models;
using Janos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Net.Http;
using System.Net;

namespace Janos.Tests.Controllers
{
    public class EnderecoControllerTests
    {
        private readonly EnderecoController _controller;
        private readonly Mock<IEnderecoRepository> _mockRepo;
        private readonly HttpClient _httpClient;

        public EnderecoControllerTests()
        {
            _mockRepo = new Mock<IEnderecoRepository>();
            _httpClient = new HttpClient(); 
            _controller = new EnderecoController(_mockRepo.Object, _httpClient); 
        }

        [Fact]
        public void GetById_ReturnsOkResult_WhenEnderecoExists()
        {
            // Arrange
            var endereco = new Endereco { EnderecoId = 1, Cep = "12345-678" };
            _mockRepo.Setup(repo => repo.GetById(1)).Returns(endereco);

            // Act
            var result = _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Endereco>(okResult.Value);
            Assert.Equal(endereco.EnderecoId, returnValue.EnderecoId);
        }

        [Fact]
        public void GetById_ReturnsNotFound_WhenEnderecoDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetById(1)).Returns((Endereco)null);

            // Act
            var result = _controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

}
}
