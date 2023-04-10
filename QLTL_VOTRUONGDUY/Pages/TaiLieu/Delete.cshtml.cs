using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTL_VOTRUONGDUY.Data;
using QLTL_VOTRUONGDUY.Model;

namespace QLTL_VOTRUONGDUY.Pages.TaiLieu
{
    public class DeleteModel : PageModel
    {
        private readonly QLTL_VOTRUONGDUY.Data.QLTL_VOTRUONGDUYContext _context;

        public DeleteModel(QLTL_VOTRUONGDUY.Data.QLTL_VOTRUONGDUYContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TaiLieu TaiLieu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TaiLieu == null)
            {
                return NotFound();
            }

            var tailieu = await _context.TaiLieu.FirstOrDefaultAsync(m => m.ID == id);

            if (tailieu == null)
            {
                return NotFound();
            }
            else 
            {
                TaiLieu = tailieu;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TaiLieu == null)
            {
                return NotFound();
            }
            var tailieu = await _context.TaiLieu.FindAsync(id);

            if (tailieu != null)
            {
                TaiLieu = tailieu;
                _context.TaiLieu.Remove(TaiLieu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
