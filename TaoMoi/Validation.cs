using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;

namespace phamledangvuong.TaoMoi
{
    public class DanhMuc
    {
        public string TenDanhMuc { get; set; }
        public string Loai { get; set; }

        private bool Validation()
        {
            if (string.IsNullOrWhiteSpace(TenDanhMuc))
            {
                MessageBox.Show("Tên danh mục không được để trống");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Loai))
            {
                MessageBox.Show("Phải chọn loại danh mục");
                return false;
            }

            return true;
        }

        private void LuuDanhMuc(object obj)
        {
            if (!Validation()) return;

            using (var db = new MyDbContext())
            {
                var dm = new DanhMuc
                {
                    TenDanhMuc = TenDanhMuc,
                    Loai = Loai
                };

                db.DanhMucs.Add(dm);
                db.SaveChanges();
            }

            MessageBox.Show("Lưu thành công!");
        }
    }
}
