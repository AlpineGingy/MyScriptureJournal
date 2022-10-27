using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;

namespace MyScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                if (context == null || context.Book == null)
                {
                    throw new ArgumentNullException("Null MyScriptureJournalContext");
                }

                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book {BookTitle = "1 Nephi"},
                    new Book {BookTitle = "2 Nephi"},
                    new Book {BookTitle = "Jacob"},
                    new Book {BookTitle = "Enos"},
                    new Book {BookTitle = "Jarom"},
                    new Book {BookTitle = "Omni"},
                    new Book {BookTitle = "Words of Mormon"},
                    new Book{BookTitle = "Mosiah"},
                    new Book {BookTitle = "Alma"},
                    new Book {BookTitle = "Helaman"},
                    new Book {BookTitle = "3 Nephi"},
                    new Book {BookTitle = "4 Nephi"},
                    new Book {BookTitle = "Mormon"},
                    new Book {BookTitle = "Ether"},
                    new Book {BookTitle = "Moroni"}
                );
                context.SaveChanges();
            }
        }
    }
}