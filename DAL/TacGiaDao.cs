using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.ThuThu;

namespace QuanLyThuVien.DAL
{
    class TacGiaDao
    {
        public DataTable LoadTacGia()
        {
            string query = "select * from View_TacGia";
            return DbConnection.Instance.Load(query);
        }
        public void ThemTacGia(TacGia tacgia)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Proc_ThemTacGia", DbConnection.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaTG", SqlDbType.NVarChar, 10).Value = tacgia.Matg;
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 100).Value = tacgia.Ten;
                cmd.Parameters.Add("@Sdt", SqlDbType.NVarChar, 10).Value = tacgia.Std;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = tacgia.Email;
                if (DbConnection.conn.State == ConnectionState.Closed)
                {
                    DbConnection.Instance.OpenConnection();
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm tác giả thành công!");
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
        public void XoaTacGia(TacGia tacgia)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Proc_XoaTacGia", DbConnection.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaTG", SqlDbType.NVarChar, 10).Value = tacgia.Matg;
                if (DbConnection.conn.State == ConnectionState.Closed)
                {
                    DbConnection.Instance.OpenConnection();
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa tác giả thành công!");
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
        public void SuaTacGia(TacGia tacgia)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Proc_SuaTacGia", DbConnection.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaTG", SqlDbType.NVarChar, 10).Value = tacgia.Matg;
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 100).Value = tacgia.Ten;
                cmd.Parameters.Add("@Sdt", SqlDbType.NVarChar, 10).Value = tacgia.Std;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = tacgia.Email;
                if (DbConnection.conn.State == ConnectionState.Closed)
                {
                    DbConnection.Instance.OpenConnection();
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thông tin tác giả thành công!");
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
