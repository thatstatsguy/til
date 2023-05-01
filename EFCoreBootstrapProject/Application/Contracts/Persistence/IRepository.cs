namespace Application.Contracts.Persistence;

public interface IRepository<T> where T : class
{
    public T GetById(Guid Id);
    public void Add(T newItem);
}