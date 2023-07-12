using System.ComponentModel.DataAnnotations;

namespace dotnet_mvc.Models.Domain
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string ? Name { get; set; }
    }
}
