
using BookApi.Domain;

namespace BookApi.Data.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetById(int id);
        Task InsertBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}
