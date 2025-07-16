using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.Repository;

public class BookRepository : IRepository<Book, int>
{
    private readonly StudyCoreAPIContext _context;
    public BookRepository(StudyCoreAPIContext context)
    {
        _context = context;
    }
    public async Task<IReadOnlyCollection<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task AddAsync(Book entity)
    {
        await _context.Books.AddAsync(entity);
    }

    public async Task UpdateAsync(Book entity)
    {
        var book = await GetByIdAsync(entity.Id);

        if (book == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        
        book.Name = entity.Name;
        book.Author = entity.Author;
        book.Language = entity.Language;
        book.CompleteDate = entity.CompleteDate;
        book.PageCount = entity.PageCount;
        book.ReadPages = entity.ReadPages;
    }

    public async Task DeleteAsync(int id)
    {
        var book = await GetByIdAsync(id);

        if (book == null)
        {
            throw new ArgumentNullException(nameof(book));
        }
        _context.Books.Remove(book);
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }
}