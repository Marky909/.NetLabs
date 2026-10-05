using EcommerceApi.Data;
using EcommerceApi.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace EcommerceApi.Tests.Services;

public class OrderServiceTests
{

    private EcommerceDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<EcommerceDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new EcommerceDbContext(options);
    }

    private Mock<ICurrentUserService> CreateCurrentUserMock(int userId)
    {
        var mock = new Mock<ICurrentUserService>();

        mock.Setup(x => x.UserId)
            .Returns(userId);

        return mock;
    }

    [Test]
    public void CheckOutAsync_WhenUserIsNotLoggedIn_ThrowsUnauthorizedAccessException()
    {
        //Arrange
        var context = CreateDbContext();

        var currentUser = new Mock<ICurrentUserService>();


        currentUser.Setup(x => x.UserId)
            .Returns((int?)null);

        var service = new OrderService(context, currentUser.Object);


        //Act + Assert

        Assert.ThrowsAsync<UnauthorizedAccessException>(
            async () => await service.CheckOutAsync());
    }
}