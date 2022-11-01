using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ScriptureId { get; set; }
        public int BookId { get; set; }

        [Required, StringLength(255)]
        public string? Chapter { get; set; }

        [Required, StringLength(255)]
        public string? Verses { get; set; }

        [Required, StringLength(255)]
        public string? Notes { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }  
        
        // Navigation Properties
        public Book? Book { get; set; }

    }
}
