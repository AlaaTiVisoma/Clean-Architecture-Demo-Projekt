using BookStore.Core.Entities;


namespace BookStore.Core.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author);
        // Add any other specific methods for Book as needed
    }
}
