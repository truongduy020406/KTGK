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
    public class IndexModel : PageModel
    {
        private readonly QLTL_VOTRUONGDUY.Data.QLTL_VOTRUONGDUYContext _context;

        public IndexModel(QLTL_VOTRUONGDUY.Data.QLTL_VOTRUONGDUYContext context)
        {
            _context = context;
        }

        public IList<QLTL_VOTRUONGDUY.Model.TaiLieu> TaiLieu { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TaiLieu != null)
            {
                TaiLieu = await _context.TaiLieu.ToListAsync();
            }
        }
    }
}
