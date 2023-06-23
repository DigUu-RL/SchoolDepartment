namespace Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

public abstract class EntityBase
{
	public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool Excluded { get; set; }

	public override string ToString()
	{
		return $"{Id}.{CreateDate}";
	}
}
