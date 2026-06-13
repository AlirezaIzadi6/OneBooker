using FluentAssertions;
using Moq;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Services;
using OneBooker.Modules.Users.Application.Contracts.Repositories;
using OneBooker.Modules.Users.Application.UserManagement.Login;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.Services.Globalization;

namespace OneBooker.Tests.Modules.Users.Application.UserManagement.Login;

public class UserLoginServiceTests
{
    private readonly Mock<IGlobalizationService> _globalizationMock;
    private readonly Mock<IPasswordHashService> _hashServiceMock;
    private readonly Mock<IIdentityManagerService> _identityServiceMock;
    private readonly UserLoginService _service;
    private readonly Mock<IUserRepository> _userRepoMock;

    public UserLoginServiceTests()
    {
        _userRepoMock = new Mock<IUserRepository>();
        _hashServiceMock = new Mock<IPasswordHashService>();
        _identityServiceMock = new Mock<IIdentityManagerService>();
        _globalizationMock = new Mock<IGlobalizationService>();
        _service = new UserLoginService(
            _userRepoMock.Object,
            _hashServiceMock.Object,
            _identityServiceMock.Object,
            _globalizationMock.Object);
    }

    [Fact]
    public async Task LoginAsync_WhenUserNotFound_ShouldReturnNotAuthenticated()
    {
        // Arrange
        var request = new LoginRequest
        {
            UserName = "nonexistent",
            Password = "any",
        };
        _userRepoMock.Setup(r => r.GetByUsernameAsync(request.UserName)).ReturnsAsync((User)null);
        _globalizationMock.Setup(g => g.Localize(Messages.UsernameOrPasswordIncorrect)).Returns("Invalid credentials");

        // Act
        Response<ILoginResult> result = await _service.LoginAsync(request);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.ErrorType.Should().Be(ErrorType.NotAuthenticated);
        result.ErrorMessage.Should().Be("Invalid credentials");
    }

    [Fact]
    public async Task LoginAsync_WhenPasswordIncorrect_ShouldReturnNotAuthenticated()
    {
        // Arrange
        var request = new LoginRequest
        {
            UserName = "user",
            Password = "wrongpassword",
        };
        var user = new User
        {
            Username = "user",
            PasswordHash = "correct_hash",
        };
        _userRepoMock.Setup(r => r.GetByUsernameAsync(request.UserName)).ReturnsAsync(user);
        _hashServiceMock.Setup(s => s.Verify(user.PasswordHash, request.Password)).ReturnsAsync(false);
        _globalizationMock.Setup(g => g.Localize(Messages.UsernameOrPasswordIncorrect)).Returns("Invalid credentials");

        // Act
        Response<ILoginResult> result = await _service.LoginAsync(request);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.ErrorType.Should().Be(ErrorType.NotAuthenticated);
    }

    [Fact]
    public async Task LoginAsync_WhenCredentialsAreCorrect_ShouldReturnSuccess()
    {
        // Arrange
        var request = new LoginRequest
        {
            UserName = "user",
            Password = "correctpassword",
        };
        var user = new User
        {
            Username = "user",
            PasswordHash = "correct_hash",
        };
        var mockLoginResult = new Mock<ILoginResult>();

        _userRepoMock.Setup(r => r.GetByUsernameAsync(request.UserName)).ReturnsAsync(user);
        _hashServiceMock.Setup(s => s.Verify(user.PasswordHash, request.Password)).ReturnsAsync(true);
        _identityServiceMock.Setup(s => s.GenerateLoginResponseAsync(request, user))
            .ReturnsAsync(mockLoginResult.Object);

        // Act
        Response<ILoginResult> result = await _service.LoginAsync(request);

        // Assert
        result.IsSuccess.Should().BeTrue();
        Assert.NotNull(result.Data);
        Assert.Equal(mockLoginResult.Object, result.Data);
        _identityServiceMock.Verify(s => s.GenerateLoginResponseAsync(request, user), Times.Once);
    }
}