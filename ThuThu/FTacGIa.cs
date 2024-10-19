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
    public partial class FTacGIa : Form
    {
        TacGiaDao tacgiadao = new TacGiaDao();
        public FTacGIa()
        {
            InitializeComponent();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TacGia tacgia = new TacGia(txtMaTG.Text, txtTen.Text, txtEmail.Text, txtSdt.Text);
            tacgiadao.SuaTacGia(tacgia);
            FTacGIa_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            TacGia tacgia = new TacGia(txtMaTG.Text, txtTen.Text, txtEmail.Text, txtSdt.Text);
            tacgiadao.XoaTacGia(tacgia);
            FTacGIa_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TacGia tacgia = new TacGia(txtMaTG.Text,txtTen.Text,txtEmail.Text,txtSdt.Text);
            tacgiadao.ThemTacGia(tacgia);
            FTacGIa_Load(sender, e);
;        }

        private void FTacGIa_Load(object sender, EventArgs e)
        {
            dtTacGia.DataSource = tacgiadao.LoadTacGia();
        }

        private void dtTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dtTacGia.Rows[e.RowIndex];
            txtMaTG.Text = selectedRow.Cells["MaTG"].Value.ToString();
            txtTen.Text = selectedRow.Cells["Ten"].Value.ToString();
            txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
            txtSdt.Text = selectedRow.Cells["Sdt"].Value.ToString();     
        }
    }
}
