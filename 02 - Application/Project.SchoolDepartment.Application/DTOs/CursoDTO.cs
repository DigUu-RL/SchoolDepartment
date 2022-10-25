namespace Project.SchoolDepartment.Application.DTOs;

public class CursoDTO
{
	public Guid Guid { get; set; }
	public string? Nome { get; set; }
	public ICollection<AlunoDTO>? Alunos { get; set; }
	public ICollection<TurmaDTO>? Turmas { get; set; }
}
