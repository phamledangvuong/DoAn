using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace phamledangvuong.ViewModel
{
    public class SanPham : BaseViewModel
    {
        public string TenSanPham { get; set; }
        public double Gia { get; set; }
        public int SoLuong { get; set; }
        public object DanhMucSelected { get; set; }
        public object NCCSelected { get; set; }

        public DateTime NgayNhap { get; set; } = DateTime.Now;
        public string MoTa { get; set; }
        public bool ConHang { get; set; }
        public string ImagePath { get; set; }
        public ICommand ChonAnhCommand { get; set; }
        public ICommand ThemCommand { get; set; }

        public SanPham()
        {
            ChonAnhCommand = new RelayCommand(ChonAnh);
            ThemCommand = new RelayCommand(ThemSanPham);
        }
        private void ChonAnh(object obj)
        {
        }
        private void ThemSanPham(object obj)
        {
        }
    }
}
