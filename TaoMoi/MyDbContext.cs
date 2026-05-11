using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace phamledangvuong.TaoMoi
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("Data Source=.;Initial Catalog=QuanLySanPham;Integrated Security=True")
        {
        }

        public DbSet<DanhMuc> DanhMucs { get; set; }
    }
}
