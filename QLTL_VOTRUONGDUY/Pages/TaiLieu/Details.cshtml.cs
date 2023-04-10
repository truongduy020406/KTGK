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
    public class DetailsModel : PageModel
    {
        private readonly QLTL_VOTRUONGDUY.Data.QLTL_VOTRUONGDUYContext _context;

        public DetailsModel(QLTL_VOTRUONGDUY.Data.QLTL_VOTRUONGDUYContext context)
        {
            _context = context;
        }

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
    }
}
