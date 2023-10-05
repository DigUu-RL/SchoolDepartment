namespace Project.SchoolDepartment.Infra.Middleware.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class RequestAttribute : Attribute
{
    public RequestAttribute()
    {
        
    }
}
