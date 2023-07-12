using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_mvc.Models.Domain
{
    public class Book
    {
        public int Id { get; set; }

        public string ?Title { get; set; }

        public int ?TotalPages { get; set; }

        public int ?GenreId { get; set; }

        public int ? PublisherId { get; set; }

        public int ? AuthorId { get; set; }

        [NotMapped]
        public string ?GenreName { get; set; }
        [NotMapped]
        public string ?PublisherName { get; set; }
        [NotMapped]
        public string ?AuthorName { get; set; }

        [NotMapped]
        public List<SelectListItem> ?GenreList { get; set; }
        [NotMapped]
        public List<SelectListItem> ?PublisherList { get; set; }
        [NotMapped]
        public List<SelectListItem> ?AuthorList { get; set; }
    }
}
