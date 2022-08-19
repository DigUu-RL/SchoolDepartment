namespace Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

public class Curso : Base
{
	public string? Nome { get; set; }

	// relationships
	public ICollection<Aluno>? Alunos { get; set; }
	public ICollection<Turma>? Turmas { get; set; }
}
