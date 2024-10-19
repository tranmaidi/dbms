using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    abstract class Nguoi
    {
        private string ma;
        private string ten;
        private string diachi;
        private string email;
        private string sdt;
        private string gioitinh;

        protected Nguoi(string ma, string ten, string diachi, string email, string sdt, string gioitinh)
        {
            this.Ma = ma;
            this.Ten = ten;
            this.Diachi = diachi;
            this.Email = email;
            this.Sdt = sdt;
            this.Gioitinh = gioitinh;
        }

        public string Ma { get => ma; set => ma = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Email { get => email; set => email = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
    }
}
