using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Display(Name = "Book Title")]
        public string BookTitle { get; set; }

        // Navigation properties
        public List<Scripture>? Scriptures { get; set; }
    }
}
