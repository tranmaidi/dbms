using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    class ChiTietPhieuMuon
    {
        private string mapm;
        private CuonSach cuonsach;

        public ChiTietPhieuMuon(string mapm, CuonSach cuonsach)
        {
            this.mapm = mapm;
            this.cuonsach = cuonsach;
        }

        public string Mapm { get => mapm; set => mapm = value; }
        internal CuonSach Cuonsach { get => cuonsach; set => cuonsach = value; }
    }
}
