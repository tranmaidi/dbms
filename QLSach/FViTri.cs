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
    public partial class FViTri : Form
    {
        ViTriDao vitridao = new ViTriDao();
        public FViTri()
        {
            InitializeComponent();
        }     
        private void btnXoa_Click(object sender, EventArgs e)
        {
            ViTri vitri = new ViTri(txtMaViTri.Text, txtKhuVuc.Text,
            txtKe.Text, txtNgan.Text);
            vitridao.ThemViTri(vitri);
            FViTri_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ViTri vitri = new ViTri(txtMaViTri.Text, txtKhuVuc.Text,
            txtKe.Text, txtNgan.Text);
            vitridao.SuaViTri(vitri);
            FViTri_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ViTri vitri = new ViTri(txtMaViTri.Text, txtKhuVuc.Text,
            txtKe.Text, txtNgan.Text);
            vitridao.ThemViTri(vitri);
            FViTri_Load(sender, e);
        }

        private void dtViTri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dtViTri.Rows[e.RowIndex];
            txtMaViTri.Text = selectedRow.Cells["MaVT"].Value.ToString();
            txtKhuVuc.Text = selectedRow.Cells["KhuVuc"].Value.ToString();
            txtKe.Text = selectedRow.Cells["Ke"].Value.ToString();
            txtNgan.Text = selectedRow.Cells["Ngan"].Value.ToString();
        }

        private void FViTri_Load(object sender, EventArgs e)
        {
            dtViTri.DataSource = vitridao.LoadViTri();
        }
    }
}
