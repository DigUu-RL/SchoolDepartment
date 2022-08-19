namespace Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

public class Telefone : Base
{
	public string? Numero { get; set; }

	// relationships
	public Guid AlunoGuid { get; set; }
	public Aluno? Aluno { get; set; }
}
