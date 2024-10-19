using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    class NhaXuatBan
    {
        private string manxb;
        private string ten;
        private string diachi;
        private string email;
        private string sdt;

        public NhaXuatBan(string manxb, string ten, string diachi, string email, string sdt)
        {
            this.manxb = manxb;
            this.ten = ten;
            this.diachi = diachi;
            this.email = email;
            this.sdt = sdt;
        }

        public string Manxb { get => manxb; set => manxb = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Email { get => email; set => email = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}
