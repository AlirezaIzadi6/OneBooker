using FluentAssertions;
using Moq;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Services;
using OneBooker.Modules.Users.Application.Contracts.Repositories;
using OneBooker.Modules.Users.Application.UserManagement.Registration;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.Modules.Users.Domain.UserManagement.Enums;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.Services.Globalization;

namespace OneBooker.Tests.Modules.Users.Application.UserManagement.Registration;

public class UserRegistrationServiceTests
{
    private readonly Mock<IGlobalizationService> _globalizationMock;
    private readonly Mock<IPasswordHashService> _hashServiceMock;
    private readonly UserRegistrationService _service;
    private readonly Mock<IUserRepository> _userRepoMock;

    public UserRegistrationServiceTests()
    {
        _userRepoMock = new Mock<IUserRepository>();
        _hashServiceMock = new Mock<IPasswordHashService>();
        _globalizationMock = new Mock<IGlobalizationService>();
        _service = new UserRegistrationService(
            _userRepoMock.Object,
            _hashServiceMock.Object,
            _globalizationMock.Object);
    }

    [Fact]
    public async Task RegisterUser_WhenUsernameIsDuplicate_ShouldReturnFail()
    {
        // Arrange
        var request = new RegistrationRequest
        {
            UserName = "TestUser",
            Email = "test@test.com",
            NationalCode = "1234567890",
            Password = "Password123",
        };
        _userRepoMock.Setup(r => r.IsUsernameDuplicate("TESTUSER")).ReturnsAsync(true);
        _globalizationMock.Setup(g => g.Localize(Messages.DuplicateItem)).Returns("Duplicate {0}");

        // Act
        Response<int> result = await _service.RegisterUser(request);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.ErrorMessage.Should().Contain("username");
    }

    [Fact]
    public async Task RegisterUser_WhenEmailIsDuplicate_ShouldReturnFail()
    {
        // Arrange
        var request = new RegistrationRequest
        {
            UserName = "testuser",
            Email = "Test@Test.com",
            NationalCode = "1234567890",
            Password = "Password123",
        };
        _userRepoMock.Setup(r => r.IsUsernameDuplicate(It.IsAny<string>())).ReturnsAsync(false);
        _userRepoMock.Setup(r => r.IsEmailDuplicate("TEST@TEST.COM")).ReturnsAsync(true);
        _globalizationMock.Setup(g => g.Localize(Messages.DuplicateItem)).Returns("Duplicate {0}");

        // Act
        Response<int> result = await _service.RegisterUser(request);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.ErrorMessage.Should().Contain("email");
    }

    [Fact]
    public async Task RegisterUser_WhenNationalCodeIsDuplicate_ShouldReturnFail()
    {
        // Arrange
        var request = new RegistrationRequest
        {
            UserName = "testuser",
            Email = "test@test.com",
            NationalCode = "1234567890",
            Password = "Password123",
        };
        _userRepoMock.Setup(r => r.IsUsernameDuplicate(It.IsAny<string>())).ReturnsAsync(false);
        _userRepoMock.Setup(r => r.IsEmailDuplicate(It.IsAny<string>())).ReturnsAsync(false);
        _userRepoMock.Setup(r => r.IsNationalCodeDuplicate(request.NationalCode)).ReturnsAsync(true);
        _globalizationMock.Setup(g => g.Localize(Messages.DuplicateItem)).Returns("Duplicate {0}");

        // Act
        Response<int> result = await _service.RegisterUser(request);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.ErrorMessage.Should().Contain("national code");
    }

    [Fact]
    public async Task RegisterUser_WhenDataIsValid_ShouldReturnSuccess()
    {
        // Arrange
        var request = new RegistrationRequest
        {
            UserName = "newuser",
            Email = "new@test.com",
            NationalCode = "0987654321",
            Password = "SecurePassword123",
            FirstName = "John",
            LastName = "Doe",
        };
        int expectedId = 123;
        _userRepoMock.Setup(r => r.IsUsernameDuplicate(It.IsAny<string>())).ReturnsAsync(false);
        _userRepoMock.Setup(r => r.IsEmailDuplicate(It.IsAny<string>())).ReturnsAsync(false);
        _userRepoMock.Setup(r => r.IsNationalCodeDuplicate(It.IsAny<string>())).ReturnsAsync(false);
        _hashServiceMock.Setup(s => s.Hash(request.Password)).ReturnsAsync("hashed_pass");
        _userRepoMock.Setup(r => r.CreateUser(It.IsAny<User>())).ReturnsAsync(expectedId);

        // Act
        Response<int> result = await _service.RegisterUser(request);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().Be(expectedId);
        _userRepoMock.Verify(
            r => r.CreateUser(
                It.Is<User>(
                    u =>
                        u.Username == request.UserName &&
                        u.NormalizedUsername.Equals(request.UserName, StringComparison.OrdinalIgnoreCase) &&
                        u.Email == request.Email &&
                        u.NormalizedEmail.Equals(request.Email, StringComparison.OrdinalIgnoreCase) &&
                        u.PasswordHash == "hashed_pass" &&
                        u.FirstName == request.FirstName &&
                        u.LastName == request.LastName &&
                        u.NationalCode == request.NationalCode &&
                        u.Role == UserRole.Normal)),
            Times.Once);
    }
}