namespace DotnetPractice.Core.Interfaces;

public interface IUnitOfWork 
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}