using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.Repository;

public class BookRepository : BaseRepository<Book, int>
{
    public BookRepository(StudyCoreAPIContext context)
        :base(context)
    {
        
    }

    public override async Task UpdateAsync(Book entity)
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
}