using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace phamledangvuong.ViewModel
{
    public class DanhMuc : BaseViewModel
    {
        private string _tenDanhMuc;
        public string TenDanhMuc
        {
            get => _tenDanhMuc;
            set { _tenDanhMuc = value; OnPropertyChanged(nameof(TenDanhMuc)); }
        }
        private string _loai;
        public string Loai
        {
            get => _loai;
            set { _loai = value; OnPropertyChanged(nameof(Loai)); }
        }
        public ICommand LuuCommand { get; set; }

        public DanhMuc()
        {
            LuuCommand = new RelayCommand(LuuDanhMuc);
        }

        private void LuuDanhMuc(object obj)
        {
        }
    }
}
