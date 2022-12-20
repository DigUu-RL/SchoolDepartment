using Project.SchoolDepartment.Integration.Interfaces;

namespace Project.SchoolDepartment.Integration.Services;

public class IntegrationApiService : IIntegrationApiService
{
	private readonly HttpClient _client;

	public IntegrationApiService()
	{
		_client = new HttpClient();
	}
}
