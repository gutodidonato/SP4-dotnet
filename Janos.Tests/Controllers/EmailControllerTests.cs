using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

public class EmailControllerTests
{
    private readonly EmailController _controller;
    private readonly Mock<IEmailService> _emailServiceMock;

    public EmailControllerTests()
    {
        _emailServiceMock = new Mock<IEmailService>();
        _controller = new EmailController(_emailServiceMock.Object);
    }

    [Fact]
    public async Task SendEmail_ShouldReturnOk_WhenEmailIsSent()
    {
        // Arrange
        var emailRequest = new EmailRequest
        {
            ToEmail = "recipient@example.com",
            Subject = "Test Subject",
            Message = "Test Message"
        };

        // Act
        var result = await _controller.SendEmail(emailRequest);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Email enviado com sucesso.", okResult.Value);
        _emailServiceMock.Verify(es => es.SendEmailAsync(emailRequest.ToEmail, emailRequest.Subject, emailRequest.Message), Times.Once);
    }
}
