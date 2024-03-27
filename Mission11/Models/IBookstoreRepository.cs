using Microsoft.EntityFrameworkCore.Query;

namespace Mission11.Models
{
    public interface IBookstoreRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
