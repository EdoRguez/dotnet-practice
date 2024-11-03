namespace DotnetPractice.Core.Common.Interfaces;

public interface IUnitOfWork 
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}