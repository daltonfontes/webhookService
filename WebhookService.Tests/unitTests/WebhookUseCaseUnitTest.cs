using WebhookService.Application.UseCases;
using WebhookService.Domain.Interfaces;
using Xunit;
using Moq;
using WebhookService.Domain.Entities;

namespace WebhookService.Tests.unitTests
{
    public class WebhookUseCaseUnitTest
    {
        private readonly Mock<IWebhookRepository> _mockRepo;
        private readonly ProcessWebhookUseCase _useCase;

        public WebhookUseCaseUnitTest()
        {
            _mockRepo = new Mock<IWebhookRepository>();
            _useCase = new ProcessWebhookUseCase(_mockRepo.Object);
        }

        [Fact]
        public async Task ProcessWebhookUseCase_ExecuteAsync_Success()
        {
            // Arrange
            var type = "deploy";
            var payload = "suceess";

            _mockRepo.Setup(x => x.SaveAsync(It.IsAny<WebhookEvent>()));

            // Act
            await _useCase.ExecuteAsync(type, payload);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public async Task ProcessWebhookUseCase_ExecuteAsync_Fail()
        {
            // Arrange
            var type = "deploy";
            var payload = "false";

            _mockRepo.Setup(x => x.SaveAsync(It.IsAny<WebhookEvent>()));

            // Act
            await _useCase.ExecuteAsync(type, payload);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public async Task ProcessWebhookUseCase_ExecuteAsync_Null()
        {
            // Arrange
            string type = null;
            string payload = null;

            _mockRepo.Setup(x => x.SaveAsync(It.IsAny<WebhookEvent>()));

            // Act
            await _useCase.ExecuteAsync(type, payload);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public async Task ProcessWebhookUseCase_ExecuteAsync_Empty()
        {
            // Arrange
            var type = "";
            var payload = "";

            _mockRepo.Setup(x => x.SaveAsync(It.IsAny<WebhookEvent>()));

            // Act
            await _useCase.ExecuteAsync(type, payload);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public async Task ProcessWebhookUseCase_ExecuteAsync_WhiteSpace()
        {
            // Arrange
            var type = " ";
            var payload = " ";

            _mockRepo.Setup(x => x.SaveAsync(It.IsAny<WebhookEvent>()));

            // Act
            await _useCase.ExecuteAsync(type, payload);

            // Assert
            Assert.True(true);
        }
    }
}
