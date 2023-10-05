namespace Project.SchoolDepartment.Infra.Middleware.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public sealed class ModelAttribute : Attribute
{
    public ModelAttribute()
    {
        
    }
}
