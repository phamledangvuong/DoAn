using Microsoft.Win32;
using phamledangvuong.TaoMoi;
using phamledangvuong.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace phamledangvuong.ThemSP
{
    public class SanPhamViewModel : BaseViewModel
    {
        public class DanhMuc
        {
            public int Id { get; set; }
            public string TenDanhMuc { get; set; }
            public string Loai { get; set; }
        }
        public class SanPham
        {
            public int Id { get; set; }

            public string TenSanPham { get; set; }
            public double Gia { get; set; }
            public int SoLuong { get; set; }

            public int DanhMucId { get; set; }
            public DanhMuc DanhMuc { get; set; }

            public string Image { get; set; }
        }
        public class MyDbContext : DbContext
        {
            public DbSet<SanPham> SanPhams { get; set; }
            public DbSet<DanhMuc> DanhMucs { get; set; }
        }

        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath;
            set { _imagePath = value; OnPropertyChanged(nameof(ImagePath)); }
        }

        private string _tenSanPham;
        public string TenSanPham
        {
            get => _tenSanPham;
            set { _tenSanPham = value; OnPropertyChanged(nameof(TenSanPham)); }
        }

        private double _gia;
        public double Gia
        {
            get => _gia;
            set { _gia = value; OnPropertyChanged(nameof(Gia)); }
        }

        private int _soLuong;
        public int SoLuong
        {
            get => _soLuong;
            set { _soLuong = value; OnPropertyChanged(nameof(SoLuong)); }
        }

        private DanhMuc _danhMucSelected;
        public DanhMuc DanhMucSelected
        {
            get => _danhMucSelected;
            set { _danhMucSelected = value; OnPropertyChanged(nameof(DanhMucSelected)); }
        }

        public ICommand ChonAnhCommand { get; set; }
        public ICommand ThemCommand { get; set; }

        public SanPhamViewModel()
        {
            ChonAnhCommand = new RelayCommand(ChonAnh);
            ThemCommand = new RelayCommand(ThemSanPham);
        }

        private void ChonAnh(object obj)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.png";

            if (dlg.ShowDialog() == true)
            {
                ImagePath = dlg.FileName;
            }
        }

        private void ThemSanPham(object obj)
        {
            if (string.IsNullOrWhiteSpace(TenSanPham))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!");
                return;
            }
            if (Gia <= 0)
            {
                MessageBox.Show("Giá phải lớn hơn 0!");
                return;
            }
            if (SoLuong < 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }
            if (DanhMucSelected == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục!");
                return;
            }
            if (string.IsNullOrEmpty(ImagePath))
            {
                MessageBox.Show("Chọn ảnh!");
                return;
            }
            try
            {
                using (var db = new MyDbContext())
                {
                    string folder = "Images";
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath);
                    string newPath = Path.Combine(folder, fileName);

                    File.Copy(ImagePath, newPath, true);

                    var sp = new SanPham
                    {
                        TenSanPham = TenSanPham,
                        Gia = Gia,
                        SoLuong = SoLuong,
                        DanhMucId = DanhMucSelected.Id,
                        Image = newPath
                    };

                    db.SanPhams.Add(sp);
                    db.SaveChanges();
                }

                MessageBox.Show("Thêm sản phẩm thành công!");

                TenSanPham = "";
                Gia = 0;
                SoLuong = 0;
                DanhMucSelected = null;
                ImagePath = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
