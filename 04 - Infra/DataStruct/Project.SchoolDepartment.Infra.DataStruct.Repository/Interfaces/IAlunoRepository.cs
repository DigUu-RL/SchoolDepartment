using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

public interface IAlunoRepository : IBaseRepository<Aluno>
{
	Task<Paginated<Aluno>> GetAllAsync(int page, int quantity);
}
