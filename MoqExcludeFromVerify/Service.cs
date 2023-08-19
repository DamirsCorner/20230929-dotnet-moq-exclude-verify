namespace MoqExcludeFromVerify;
public class Service
{
    private readonly IDependency dependency;

    public Service(IDependency dependency)
    {
        this.dependency = dependency;
    }

    public string Method()
    {
        var response = dependency.Method1();
        if (String.IsNullOrEmpty(response))
        {
            response = dependency.Method2();
        }
        return response;
    }
}
