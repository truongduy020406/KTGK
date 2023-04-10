using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLTL_VOTRUONGDUY.Model;

namespace QLTL_VOTRUONGDUY.Data
{
    public class QLTL_VOTRUONGDUYContext : DbContext
    {
        public QLTL_VOTRUONGDUYContext (DbContextOptions<QLTL_VOTRUONGDUYContext> options)
            : base(options)
        {
        }

        public DbSet<QLTL_VOTRUONGDUY.Model.TaiLieu> TaiLieu { get; set; } = default!;
    }
}
