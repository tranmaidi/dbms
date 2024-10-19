using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    class CuonSach
    {
        private string macs;
        private string mads;
        private string mavt;

        public CuonSach(string macs, string mads, string mavt)
        {
            this.macs = macs;
            this.mads = mads;
            this.mavt = mavt;
        }

        public string Macs { get => macs; set => macs = value; }
        public string Mads { get => mads; set => mads = value; }
        public string Mavt { get => mavt; set => mavt = value; }
    }
}
