using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.DAL;
using QuanLyThuVien.DTO;
namespace QuanLyThuVien.ThuThu
{
    public partial class FDocGia : Form
    {     
        DocGiaDao daodg = new DocGiaDao();
        public FDocGia()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DocGia dg = new DocGia(txtMaDocGia.Text, txtTen.Text, txtDiaChi.Text, txtEmail.Text, txtSoDienThoai.Text, cbbGioiTinh.Text, dtpNgaySinh.Value);
            daodg.ThemDocGia(dg);
            FDocGia_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DocGia dg = new DocGia(txtMaDocGia.Text, txtTen.Text, txtDiaChi.Text, txtEmail.Text, txtSoDienThoai.Text, cbbGioiTinh.Text, dtpNgaySinh.Value);
            daodg.XoaDocGia(dg);
            FDocGia_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DocGia dg = new DocGia(txtMaDocGia.Text, txtTen.Text, txtDiaChi.Text, txtEmail.Text, txtSoDienThoai.Text, cbbGioiTinh.Text, dtpNgaySinh.Value);
            daodg.SuaDocGia(dg);
            FDocGia_Load(sender, e);
        }

        private void FDocGia_Load(object sender, EventArgs e)
        {
            dtDocGia.DataSource = daodg.LoadDocGia();
        }

        private void dtDocgia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtDocGia.Rows[e.RowIndex];
                txtMaDocGia.Text = row.Cells["MaDG"].Value.ToString();
                txtTen.Text = row.Cells["Ten"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["Sdt"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                cbbGioiTinh.SelectedItem = row.Cells["GioiTinh"].Value.ToString();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
