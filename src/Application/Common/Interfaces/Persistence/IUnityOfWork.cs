namespace Application.Common.Interfaces.Persistence;

public interface IUnityOfWork
{
    Task CommitChangesAsync();
}