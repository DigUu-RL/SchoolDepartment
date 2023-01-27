namespace Project.SchoolDepartment.Infra.DataStruct.Repository;

public interface IUnitOfWork
{
    Task CommitAsync();
    Task RollbackAsync();
}
