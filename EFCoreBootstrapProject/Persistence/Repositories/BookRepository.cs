using Application.Contracts.Persistence;
using Domain;

namespace Persistence.Repositories;

public class BookRepository : IRepository<Book>
{
    private readonly BootstrapDbContext _dbContext;
    public BookRepository(BootstrapDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Book GetById(Guid id)
    {
        return _dbContext.Books.Find(id) ?? throw new Exception("Id not found!");
    }

    public void Add(Book newItem)
    {
        _dbContext.Books.Add(newItem);
        //without this, you'll see changes locally, but they will not persist to the DB
        _dbContext.SaveChanges();
    }
}