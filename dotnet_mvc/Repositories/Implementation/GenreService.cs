using dotnet_mvc.Models.Domain;
using dotnet_mvc.Repositories.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace dotnet_mvc.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly DatabaseContext _ctx;

        public GenreService(DatabaseContext ctx)
        {
            this._ctx = ctx;
        }
         public bool Add(Genre model)
        {
            try
            {
                var data = _ctx.Genre.Add(model);
                _ctx.SaveChanges();
                if(data == null)
                {
                    return false;
                }
                return true;
                
            }catch (Exception ex)
            {
                return false;
            }
        }

         public bool Delete(int id)
          {
            try
            {
                var data = this.FindById(id);
                if(data == null)
                {
                    return false;
                }
                _ctx.Genre.Remove(data);
                _ctx.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

       public IEnumerable<Genre> FindAll()
        {
            return _ctx.Genre.ToList();
        }

       public Genre FindById(int id)
        {
            return _ctx.Genre.Find(id);
        }

       public bool Update(Genre model)
        {
            // handle update service 
            try
            {
                _ctx.Genre.Update(model);
                _ctx.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
