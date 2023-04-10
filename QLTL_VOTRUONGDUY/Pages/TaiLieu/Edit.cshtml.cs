using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTL_VOTRUONGDUY.Data;
using QLTL_VOTRUONGDUY.Model;

namespace QLTL_VOTRUONGDUY.Pages.TaiLieu
{
    public class EditModel : PageModel
    {
        private readonly QLTL_VOTRUONGDUY.Data.QLTL_VOTRUONGDUYContext _context;

        public EditModel(QLTL_VOTRUONGDUY.Data.QLTL_VOTRUONGDUYContext context)
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

            var tailieu =  await _context.TaiLieu.FirstOrDefaultAsync(m => m.ID == id);
            if (tailieu == null)
            {
                return NotFound();
            }
            TaiLieu = tailieu;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TaiLieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiLieuExists(TaiLieu.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TaiLieuExists(int id)
        {
          return (_context.TaiLieu?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
