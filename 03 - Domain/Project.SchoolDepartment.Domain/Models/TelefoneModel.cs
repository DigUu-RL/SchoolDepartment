namespace Project.SchoolDepartment.Domain.Models;

public class TelefoneModel
{
	public Guid Guid { get; set; }
	public string? Numero { get; set; }
	public AlunoModel? Aluno { get; set; }
}
