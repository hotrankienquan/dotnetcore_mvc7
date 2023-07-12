using dotnet_mvc.Models.Domain;

namespace dotnet_mvc.Repositories.Abstract
{
    public interface IGenreService
    {
        // add, update, delete, findById, getAll
        bool Add(Genre model);

        bool Update(Genre model);
 
        public Genre FindById(int id);

        IEnumerable<Genre> FindAll();
        bool Delete(int id);
    }
}
