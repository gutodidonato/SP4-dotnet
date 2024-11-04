using Janos.Controllers;
using Janos.Models;
using Janos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class ItemControllerTests
{
    private readonly Mock<IItemRepository> _itemRepositoryMock;
    private readonly ItemController _controller;

    public ItemControllerTests()
    {
        _itemRepositoryMock = new Mock<IItemRepository>();
        _controller = new ItemController(_itemRepositoryMock.Object);
    }

    #region Métodos de Teste

    [Fact]
    public void GetById_ReturnsOkResult_WhenItemExists()
    {
        // Arrange
        var nome = "Item1";
        var item = new Item { ItemId = 1, Nome = nome, Tipo = "Type1", Descricao = "Description", Valor = 10.0, Quantidade = 5 };
        _itemRepositoryMock.Setup(repo => repo.GetById(nome)).Returns(item);

        // Act
        var result = _controller.GetById(nome);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(item, okResult.Value);
    }

    [Fact]
    public void Create_ReturnsCreatedAtActionResult_WhenItemIsValid()
    {
        // Arrange
        var item = new Item { ItemId = 2, Nome = "Item2", Tipo = "Type2", Descricao = "Description2", Valor = 20.0, Quantidade = 3 };
        _itemRepositoryMock.Setup(repo => repo.Add(item));

        // Act
        var result = _controller.Create(item);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(item, createdResult.Value);
        Assert.Equal(nameof(_controller.GetById), createdResult.ActionName);
    }

    [Fact]
    public void Update_ReturnsNoContent_WhenItemIsUpdated()
    {
        // Arrange
        var item = new Item { ItemId = 1, Nome = "Item1", Tipo = "Type1", Descricao = "Description", Valor = 10.0, Quantidade = 5 };

        // Act
        var result = _controller.Update(item.Nome, item);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _itemRepositoryMock.Verify(repo => repo.Update(item), Times.Once);
    }

    [Fact]
    public void Delete_ReturnsNotFound_WhenItemDoesNotExist()
    {
        // Arrange
        var nome = "Item1";
        _itemRepositoryMock.Setup(repo => repo.GetById(nome)).Returns((Item)null);

        // Act
        var result = _controller.Delete(nome);

        // Assert
        Assert.IsType<NotFoundResult>(result);
        _itemRepositoryMock.Verify(repo => repo.Delete(nome), Times.Never);
    }

    [Fact]
    public void Delete_ReturnsNoContent_WhenItemExists()
    {
        // Arrange
        var nome = "Item1";
        var item = new Item { ItemId = 1, Nome = nome, Tipo = "Type1", Descricao = "Description", Valor = 10.0, Quantidade = 5 };
        _itemRepositoryMock.Setup(repo => repo.GetById(nome)).Returns(item);

        // Act
        var result = _controller.Delete(nome);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _itemRepositoryMock.Verify(repo => repo.Delete(nome), Times.Once);
    }

    #endregion
}
