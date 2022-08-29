namespace Project.SchoolDepartment.Domain.Models;

public class CursoModel
{
	public Guid Guid { get; set; }
	public string? Nome { get; set; }
	public PaginatedModel<AlunoModel>? Alunos { get; set; }
	public PaginatedModel<TurmaModel>? Turmas { get; set; }
}
