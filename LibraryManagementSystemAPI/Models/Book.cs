using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Models
{
    public class Book
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }

        public bool IsAvailable { get; set; }
    }
}
