using System.ComponentModel.DataAnnotations;

namespace BooksService.Models
{
    public class Book
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}