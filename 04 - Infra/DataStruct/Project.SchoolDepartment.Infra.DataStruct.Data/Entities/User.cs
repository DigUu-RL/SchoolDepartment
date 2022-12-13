namespace Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

public class User : EntityBase
{
	public string? Login { get; set; }
	public string? Email { get; set; }
	public string? PasswordHash { get; set; }
	public bool IsStudent { get; set; }
}
