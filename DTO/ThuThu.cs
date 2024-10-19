using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    class ThuThu:Nguoi
    {
        private DateTime ngaysinh;
        public DateTime NgaySinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }
        public ThuThu(string ma, string ten, string diachi, string email, string sdt, string gioitinh, DateTime ngaysinh)
            : base(ma, ten, diachi, email, sdt, gioitinh)
        {
            NgaySinh = ngaysinh;
        }
    }
}
