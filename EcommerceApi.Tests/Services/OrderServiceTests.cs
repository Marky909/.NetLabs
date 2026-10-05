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
}