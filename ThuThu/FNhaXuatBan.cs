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
    public partial class FNhaXuatBan : Form
    {
        NhaXuatBanDao dao = new NhaXuatBanDao();
        public FNhaXuatBan()
        {
            InitializeComponent();
            dtNhaXuatBan.DataSource = dao.LoadNhaXuaBan();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhaXuatBan nhaxuatbanmoi = new NhaXuatBan(txtMaNXB.Text, txtTenNXB.Text,
                txtDiaChi.Text, txtEmail.Text, txtSdt.Text);
            dao.ThemNhaXuatBan(nhaxuatbanmoi);
            dtNhaXuatBan.DataSource = dao.LoadNhaXuaBan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhaXuatBan nhaxuatbanmoi = new NhaXuatBan(txtMaNXB.Text, txtTenNXB.Text,
                txtDiaChi.Text, txtEmail.Text, txtSdt.Text);
            dao.XoaNhaXuatBan(nhaxuatbanmoi);
            dtNhaXuatBan.DataSource = dao.LoadNhaXuaBan();
        }

        private void dtNhaXuatBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dtNhaXuatBan.Rows[e.RowIndex];
            txtMaNXB.Text = selectedRow.Cells["MaNXB"].Value.ToString();
            txtTenNXB.Text = selectedRow.Cells["Ten"].Value.ToString();
            txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
            txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
            txtSdt.Text = selectedRow.Cells["Sdt"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhaXuatBan nhaxuatbanmoi = new NhaXuatBan(txtMaNXB.Text, txtTenNXB.Text,
                txtDiaChi.Text, txtEmail.Text, txtSdt.Text);
            dao.SuaNhaXuatBan(nhaxuatbanmoi);
            dtNhaXuatBan.DataSource = dao.LoadNhaXuaBan();
        }
    }
}
