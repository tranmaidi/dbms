using QuanLyThuVien.DAL;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.ThuThu
{
    public partial class FCuonSach : Form
    {
        CuonSachDao cuonsachdao = new CuonSachDao();    
        public FCuonSach()
        {
            InitializeComponent();
        }

        private void FCuonSach_Load(object sender, EventArgs e)
        {
            dtCuonSach.DataSource = cuonsachdao.LoadCuonSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CuonSach cuonsach = new CuonSach(txtMaCS.Text, txtMaDS.Text, txtMaVT.Text);
            cuonsachdao.SuaDauSach(cuonsach);
            FCuonSach_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            CuonSach cuonsach = new CuonSach(txtMaCS.Text, txtMaDS.Text, txtMaVT.Text);
            cuonsachdao.XoaCuonSach(cuonsach);
            FCuonSach_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CuonSach cuonsach = new CuonSach(txtMaCS.Text,txtMaDS.Text,txtMaVT.Text);
            cuonsachdao.ThemCuonSach(cuonsach);
            FCuonSach_Load(sender, e);
        }

        private void dtCuonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {         
            DataGridViewRow selectedRow = dtCuonSach.Rows[e.RowIndex];
            txtMaCS.Text = selectedRow.Cells["MaCS"].Value.ToString();
            txtMaDS.Text = selectedRow.Cells["MaDS"].Value.ToString();
            txtMaVT.Text = selectedRow.Cells["MaVT"].Value.ToString();         
        }
    }
}
