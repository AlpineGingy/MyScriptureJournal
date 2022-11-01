using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public SelectList Books { get; set; }

        public IList<Scripture> Scripture { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string BookTitle { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        
        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from s in _context.Scripture
                                           orderby s.Book
                                           select s.Book.BookTitle;

            var scriptures = from s in _context.Scripture
                             select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Notes.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BookTitle))
            {
                scriptures = scriptures.Where(s => s.Book.BookTitle == BookTitle);
            }

            Books = new SelectList(await bookQuery.Distinct().ToListAsync());

            Scripture = await scriptures
                .Include(s => s.Book)
                .ToListAsync();
        }
    }
}
