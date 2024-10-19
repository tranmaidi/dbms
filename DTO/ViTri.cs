using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    class ViTri
    {
        private string mavt;
        private string khuvuc;
        private string ke;
        private string ngan;

        public ViTri(string mavt, string khuvuc, string ke, string ngan)
        {
            this.Mavt = mavt;
            this.Khuvuc = khuvuc;
            this.Ke = ke;
            this.Ngan = ngan;
        }

        public string Mavt { get => mavt; set => mavt = value; }
        public string Khuvuc { get => khuvuc; set => khuvuc = value; }
        public string Ke { get => ke; set => ke = value; }
        public string Ngan { get => ngan; set => ngan = value; }
    }
}
