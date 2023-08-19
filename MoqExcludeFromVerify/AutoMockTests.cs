using FluentAssertions;
using Moq;
using Moq.AutoMock;

namespace MoqExcludeFromVerify;
public class AutoMockTests
{
    private AutoMocker mocker;

    [SetUp]
    public void Setup()
    {
        mocker = new AutoMocker();
        mocker.Setup<IDependency, string>(x => x.Method2())
            .Returns("method 2")
            .Verifiable(Times.AtMost(int.MaxValue));
    }

    [Test]
    public void Method1ReturnsEmpty()
    {
        mocker.Setup<IDependency, string>(x => x.Method1()).Returns("");
        var service = mocker.Get<Service>();

        service.Method().Should().Be("method 2");

        mocker.VerifyAll();
    }

    [Test]
    public void Method1ReturnsNonEmpty()
    {
        mocker.Setup<IDependency, string>(x => x.Method1()).Returns("method 1");
        var service = mocker.Get<Service>();

        service.Method().Should().Be("method 1");

        mocker.VerifyAll();
    }
}
