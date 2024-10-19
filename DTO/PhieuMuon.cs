using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    class PhieuMuon
    {
        private string mapm;
        private string madg;
        private string matt;
        private DateTime ngaymuon;
        private DateTime ngaytra;
        private List<ChiTietPhieuMuon> chitietphiemuonlist;

        public PhieuMuon(string mapm, string madg, string matt, DateTime ngaymuon, DateTime ngaytra, List<ChiTietPhieuMuon> chitietphiemuonlist)
        {
            this.mapm = mapm;
            this.madg = madg;
            this.matt = matt;
            this.ngaymuon = ngaymuon;
            this.ngaytra = ngaytra;
            this.chitietphiemuonlist = chitietphiemuonlist;
        }

        public string Mapm { get => mapm; set => mapm = value; }
        public string Madg { get => madg; set => madg = value; }
        public string Matt { get => matt; set => matt = value; }
        public DateTime Ngaymuon { get => ngaymuon; set => ngaymuon = value; }
        public DateTime Ngaytra { get => ngaytra; set => ngaytra = value; }
        internal List<ChiTietPhieuMuon> Chitietphiemuonlist { get => chitietphiemuonlist; set => chitietphiemuonlist = value; }
    }
}
