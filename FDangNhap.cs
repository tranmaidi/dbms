using QuanLyThuVien.ThuThu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.DAL
{
    public partial class FDangNhap : Form
    {     
        public FDangNhap()
        {
            InitializeComponent(); 
        }


        private void txtTaiKhoan_Enter(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "Tên đăng nhập")
            {
                txtTaiKhoan.Text = "";
            }    
        }

        private void txtTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                txtTaiKhoan.Text = "Tên đăng nhập";
            }
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Mật khẩu")
            {
                txtMatKhau.Text = "";
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                txtMatKhau.Text = "Mật khẩu";
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text=="admin")
            {
                FManHinhChinh fmanhinhchinh = new FManHinhChinh();
                this.Hide();
                fmanhinhchinh.ShowDialog();
                fmanhinhchinh = null;
                this.Show();
                
            }    
        }
    }
}
