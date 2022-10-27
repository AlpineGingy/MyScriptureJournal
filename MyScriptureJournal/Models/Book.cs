namespace MyScriptureJournal.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }

        // Navigation properties
        public List<Scripture> Scriptures { get; set; }
    }
}
