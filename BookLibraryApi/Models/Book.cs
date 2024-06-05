using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BookLibraryApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "Length should be at most 100 characters")]
        public string Title { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "Length should be at most 60 characters")]
        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public Decimal Price { get; set; }

    }
}
