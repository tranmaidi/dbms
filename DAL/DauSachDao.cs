using QuanLyThuVien.DTO;
using QuanLyThuVien.ThuThu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.DAL
{
    class DauSachDao
    {
        public DataTable LoadDauSach()
        {
            string query = "select * from View_DauSach";
            return DbConnection.Instance.Load(query);
        }

        public void ThemDauSach(DauSach dausach)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Proc_ThemDauSach", DbConnection.conn);
                cmd.CommandType = CommandType.StoredProcedure;             
                cmd.Parameters.Add("@MaDS", SqlDbType.NVarChar,10).Value = dausach.Mads;
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 100).Value = dausach.Ten;
                cmd.Parameters.Add("@TheLoai", SqlDbType.NVarChar, 50).Value = dausach.Theloai;
                cmd.Parameters.Add("@MaTG", SqlDbType.NVarChar, 10).Value = dausach.Matg;
                cmd.Parameters.Add("@MaNXB", SqlDbType.VarChar, 10).Value = dausach.Manxb;                      
                if (DbConnection.conn.State == ConnectionState.Closed)
                {
                    DbConnection.Instance.OpenConnection();
                }             
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm đầu sách thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                
                if (DbConnection.conn.State == ConnectionState.Open)
                {
                    DbConnection.Instance.CloseConnection();
                }
            }
        }
        public void XoaDauSach(DauSach dausach)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Proc_XoaDauSach", DbConnection.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaDS", SqlDbType.NVarChar, 10).Value = dausach.Mads;        
                if (DbConnection.conn.State == ConnectionState.Closed)
                {
                    DbConnection.Instance.OpenConnection();
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa đầu sách thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {

                if (DbConnection.conn.State == ConnectionState.Open)
                {
                    DbConnection.Instance.CloseConnection();
                }
            }
        }
        public void SuaDauSach(DauSach dausach)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Proc_SuaDauSach", DbConnection.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaDS", SqlDbType.NVarChar, 10).Value = dausach.Mads;
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 100).Value = dausach.Ten;
                cmd.Parameters.Add("@TheLoai", SqlDbType.NVarChar, 50).Value = dausach.Theloai;
                cmd.Parameters.Add("@MaTG", SqlDbType.NVarChar, 10).Value = dausach.Matg;
                cmd.Parameters.Add("@MaNXB", SqlDbType.VarChar, 10).Value = dausach.Manxb;
                if (DbConnection.conn.State == ConnectionState.Closed)
                {
                    DbConnection.Instance.OpenConnection();
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm đầu sách thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {

                if (DbConnection.conn.State == ConnectionState.Open)
                {
                    DbConnection.Instance.CloseConnection();
                }
            }
        }
    }
}
