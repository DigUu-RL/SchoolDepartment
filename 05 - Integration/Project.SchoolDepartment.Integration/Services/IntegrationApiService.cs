using Project.SchoolDepartment.Integration.Interfaces;

namespace Project.SchoolDepartment.Integration.Services;

public class IntegrationApiService : IIntegrationApiService
{
	private readonly HttpClient _httpClient;

	public IntegrationApiService()
	{
		_httpClient = new HttpClient();
	}
}
