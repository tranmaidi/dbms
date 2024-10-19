using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    class TacGia
    {
        private string matg;
        private string ten;
        private string email;
        private string std;

        public TacGia(string matg, string ten, string email, string std)
        {
            this.matg = matg;
            this.ten = ten;
            this.email = email;
            this.std = std;
        }

        public string Matg { get => matg; set => matg = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Email { get => email; set => email = value; }
        public string Std { get => std; set => std = value; }
    }
}
