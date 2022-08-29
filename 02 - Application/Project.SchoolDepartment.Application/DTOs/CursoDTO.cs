namespace Project.SchoolDepartment.Application.DTOs;

public class CursoDTO
{
	public Guid Guid { get; set; }
	public string? Nome { get; set; }
	public PaginatedDTO<AlunoDTO>? Alunos { get; set; }
	public PaginatedDTO<TurmaDTO>? Turmas { get; set; }
}
