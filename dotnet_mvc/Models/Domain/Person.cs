using System.ComponentModel.DataAnnotations;

namespace dotnet_mvc.Models.Domain
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
    }
}
