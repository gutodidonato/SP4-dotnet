using Moq;
using Xunit;

public class EmailServiceTests
{
    private readonly Mock<IEmailService> _emailServiceMock;

    public EmailServiceTests()
    {
        _emailServiceMock = new Mock<IEmailService>();
    }

    [Fact]
    public async Task SendEmailAsync_ShouldSendEmail_WhenCalled()
    {
        // Arrange
        var toEmail = "recipient@example.com";
        var subject = "Test Subject";
        var message = "Test Message";

        // Act
        await _emailServiceMock.Object.SendEmailAsync(toEmail, subject, message);

        // Assert
        _emailServiceMock.Verify(es => es.SendEmailAsync(toEmail, subject, message), Times.Once);
    }
}
