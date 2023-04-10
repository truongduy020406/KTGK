using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLTL_VOTRUONGDUY.Data;
using QLTL_VOTRUONGDUY.Model;

namespace QLTL_VOTRUONGDUY.Pages.TaiLieu
{
    public class CreateModel : PageModel
    {
        private readonly QLTL_VOTRUONGDUY.Data.QLTL_VOTRUONGDUYContext _context;

        public CreateModel(QLTL_VOTRUONGDUY.Data.QLTL_VOTRUONGDUYContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TaiLieu TaiLieu { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TaiLieu == null || TaiLieu == null)
            {
                return Page();
            }

            _context.TaiLieu.Add(TaiLieu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
