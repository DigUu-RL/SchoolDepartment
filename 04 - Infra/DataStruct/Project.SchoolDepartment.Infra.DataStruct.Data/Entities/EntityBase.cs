namespace Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

public abstract class EntityBase<TEntity> : IEquatable<TEntity> where TEntity : class
{
	public Guid Guid { get; set; }

	public override bool Equals(object? obj)
	{
		if (obj is null)
			return false;

		if (typeof(TEntity) != obj.GetType())
			return false;

		return Equals(obj as TEntity);
	}

	public bool Equals(TEntity? other)
	{
		if (other is null)
			return false;

		if (ReferenceEquals(this, other))
			return true;

		if (GetHashCode() != other.GetHashCode())
			return false;

		return base.Equals(other);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode() + Guid.GetHashCode();
	}
}
