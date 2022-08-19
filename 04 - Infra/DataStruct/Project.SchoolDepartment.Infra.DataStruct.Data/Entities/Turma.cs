using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

public class Turma : Base
{
	public int QuantidadeAlunos { get; set; }
	public Periodo Periodo { get; set; }
	public DateTime DataInicio { get; set; }
	public DateTime DataFim { get; set; }

	// relationships
	public Guid CursoGuid { get; set; }
	public Curso? Curso { get; set; }
	public ICollection<Aluno>? Alunos { get; set; }
}
