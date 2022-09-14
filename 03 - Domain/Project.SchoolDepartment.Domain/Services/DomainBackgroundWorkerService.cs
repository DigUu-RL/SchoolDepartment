using Project.SchoolDepartment.Domain.Interfaces;

namespace Project.SchoolDepartment.Domain.Services;

public class DomainBackgroundWorkerService : IDomainBackgroundWorkerService
{
	public async Task StartAsync(CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
