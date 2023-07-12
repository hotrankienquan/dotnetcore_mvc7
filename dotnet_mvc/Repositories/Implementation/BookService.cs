using dotnet_mvc.Models.Domain;
using dotnet_mvc.Repositories.Abstract;
using System.Security.Policy;

namespace dotnet_mvc.Repositories.Implementation
{
    public class BookService : IBookService
    {
        private readonly DatabaseContext _ctx;
        public BookService(DatabaseContext databaseContext)
        {
            _ctx = databaseContext;
        }
        public bool Add(Book model)
        {
            try
            {
                var data = _ctx.Book.Add(model);
                _ctx.SaveChanges(); 
                if(data != null)
                {
                    return true;
                }
                return false;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if(data == null) { return false; }
                _ctx.Remove(data);
                _ctx.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Book> FindAll()
        {
            var data = (from book in _ctx.Book join genre in _ctx.Genre on
                        book.GenreId equals genre.Id
                        select new Book
                        {
                            Id = book.Id,
                            GenreId = book.GenreId,
                            Title = book.Title,
                            TotalPages = book.TotalPages,
                            GenreName = genre.Name!,
                        }).ToList();
            return data;
        }

        public Book FindById(int id)
        {
            return _ctx.Book.Find(id)!;
        }

        public bool Update(Book model)
        {
            try
            {
                _ctx.Book.Update(model);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
