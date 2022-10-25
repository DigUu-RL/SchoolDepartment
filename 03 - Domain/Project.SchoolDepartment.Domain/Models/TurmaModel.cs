using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Domain.Models;

public class TurmaModel
{
	public Guid Guid { get; set; }
	public int QuantidadeAlunos { get; set; }
	public Periodo Periodo { get; set; }
	public DateTime DataInicio { get; set; }
	public DateTime DataFim { get; set; }
	public CursoModel? Curso { get; set; }
	public ICollection<AlunoModel>? Alunos { get; set; }
}
