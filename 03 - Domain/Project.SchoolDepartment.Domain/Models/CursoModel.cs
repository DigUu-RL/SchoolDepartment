namespace Project.SchoolDepartment.Domain.Models;

public class CursoModel
{
	public Guid Guid { get; set; }
	public string? Nome { get; set; }
	public ICollection<AlunoModel>? Alunos { get; set; }
	public ICollection<TurmaModel>? Turmas { get; set; }
}
