using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.DAL;

namespace QuanLyThuVien.ThuThu
{
    public partial class FCuonSachViTri : Form
    {
        public FCuonSachViTri()
        {
            InitializeComponent();
        }

        private void FCuonSachViTri_Load(object sender, EventArgs e)
        {
            dtCuonSachViTri.DataSource = DbConnection.Instance.Load("select * from View_ThongTinCuonSachViTri");
        }
    }
}
