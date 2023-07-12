using dotnet_mvc.Models.Domain;

namespace dotnet_mvc.Repositories.Abstract
{
    public interface IPublisherService
    {
        bool Add(Publisher model);

        bool Update(Publisher model);

        Publisher FindById(int id);

        IEnumerable<Publisher> FindAll();
        bool Delete(int id);
    }
}
