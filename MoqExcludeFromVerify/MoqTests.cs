using FluentAssertions;
using Moq;

namespace MoqExcludeFromVerify;

public class MoqTests
{
    private Mock<IDependency> mockDependency;

    [SetUp]
    public void Setup()
    {
        mockDependency = new Mock<IDependency>();
        mockDependency.Setup(x => x.Method2()).Returns("method 2");
    }

    [Test]
    public void Method1ReturnsEmpty()
    {
        mockDependency.Setup(x => x.Method1()).Returns("");
        var service = new Service(mockDependency.Object);

        service.Method().Should().Be("method 2");

        mockDependency.VerifyAll();
    }

    [Test]
    public void Method1ReturnsNonEmpty()
    {
        mockDependency.Setup(x => x.Method1()).Returns("method 1");
        var service = new Service(mockDependency.Object);

        service.Method().Should().Be("method 1");

        mockDependency.VerifyAll();
    }
}