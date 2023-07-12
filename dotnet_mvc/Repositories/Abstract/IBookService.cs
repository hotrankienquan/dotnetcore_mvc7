using dotnet_mvc.Models.Domain;

namespace dotnet_mvc.Repositories.Abstract
{
    public interface IBookService
    {
        bool Add(Book model);

        bool Update(Book model);

        Book FindById(int id);
        bool Delete(int id);

        IEnumerable<Book> FindAll();
    }
}
