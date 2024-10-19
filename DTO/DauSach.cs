using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    class DauSach
    {
        private string mads;
        private string matg;
        private string manxb;
        private string ten;
        private string theloai;

        public DauSach(string mads, string matg, string manxb, string ten, string theloai)
        {
            this.mads = mads;
            this.matg = matg;
            this.manxb = manxb;
            this.ten = ten;
            this.theloai = theloai;
        }

        public string Mads { get => mads; set => mads = value; }
        public string Matg { get => matg; set => matg = value; }
        public string Manxb { get => manxb; set => manxb = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Theloai { get => theloai; set => theloai = value; }
    }
}
