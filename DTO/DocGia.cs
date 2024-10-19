using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.DTO
{
    class DocGia : Nguoi
    {
        private DateTime ngaysinh;
        public DateTime NgaySinh
        {
            get { return ngaysinh; } set {  ngaysinh = value; }
        }
        public DocGia(string ma, string ten, string diachi, string email, string sdt, string gioitinh,DateTime ngaysinh) 
            : base(ma,ten, diachi, email,sdt,gioitinh)
        {
            NgaySinh = ngaysinh;
        }
    }
}
