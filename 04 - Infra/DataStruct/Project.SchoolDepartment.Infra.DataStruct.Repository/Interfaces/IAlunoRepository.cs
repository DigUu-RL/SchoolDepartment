using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

public interface IAlunoRepository
{
	Task<Paginated<Aluno>> GetAllAsync(int page, int quantity);
	Task<Aluno?> GetByGuidAsync(Guid guid);
	Task CreateAsync(Aluno aluno);
	Task UpdateAsync(Aluno aluno);
	Task DeleteAsync(Aluno aluno);
}
