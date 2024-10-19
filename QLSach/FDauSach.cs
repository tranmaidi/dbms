using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.DAL;
using QuanLyThuVien.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyThuVien.ThuThu
{
   
    public partial class FDauSach : Form
    {
        DauSachDao dao= new DauSachDao();
        public FDauSach()
        {
            InitializeComponent();         
            dtDauSach.DataSource = dao.LoadDauSach(); 
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DauSach dausachmoi = new DauSach(txtMaDauSach.Text,txtMaTacGia.Text,
                txtMaNhaXuatBan.Text,txtTen.Text,txtTheLoai.Text);
            dao.ThemDauSach(dausachmoi);
            dtDauSach.DataSource = dao.LoadDauSach();
        }

        private void dtDauSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dtDauSach.Rows[e.RowIndex];
            txtMaDauSach.Text = selectedRow.Cells["MaDS"].Value.ToString();
            txtTen.Text = selectedRow.Cells["Ten"].Value.ToString();
            txtMaTacGia.Text = selectedRow.Cells["MaTG"].Value.ToString();
            txtMaNhaXuatBan.Text = selectedRow.Cells["MaNXB"].Value.ToString();
            txtTheLoai.Text = selectedRow.Cells["TheLoai"].Value.ToString();
    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DauSach dausachmoi = new DauSach(txtMaDauSach.Text, txtMaTacGia.Text,
                 txtMaNhaXuatBan.Text, txtTen.Text, txtTheLoai.Text);
            dao.XoaDauSach(dausachmoi);
            dtDauSach.DataSource = dao.LoadDauSach();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            DauSach dausachmoi = new DauSach(txtMaDauSach.Text, txtMaTacGia.Text,
              txtMaNhaXuatBan.Text, txtTen.Text, txtTheLoai.Text);
            dao.SuaDauSach(dausachmoi);
            dtDauSach.DataSource = dao.LoadDauSach();
        }
    }
}
