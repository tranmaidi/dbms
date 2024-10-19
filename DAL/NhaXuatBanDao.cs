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
    class NhaXuatBanDao
    {
        public DataTable LoadNhaXuaBan()
        {
            return DbConnection.Instance.Load("Select * from View_NhaXuatBan");
        }

        public void ThemNhaXuatBan(NhaXuatBan nhaxuatban)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("proc_ThemNhaXuatBan", DbConnection.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaNXB", SqlDbType.VarChar, 10).Value = nhaxuatban.Manxb;
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 100).Value = nhaxuatban.Ten;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 255).Value = nhaxuatban.Diachi;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = nhaxuatban.Email;
                cmd.Parameters.Add("@Sdt", SqlDbType.VarChar, 10).Value = nhaxuatban.Sdt;
                if (DbConnection.conn.State == ConnectionState.Closed)
                {
                    DbConnection.Instance.OpenConnection();
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Nhà Xuất Bản thành công!");
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
        public void XoaNhaXuatBan(NhaXuatBan nhaXuatBan)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Proc_XoaNhaXuatBan", DbConnection.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaNXB", SqlDbType.VarChar, 10).Value = nhaXuatBan.Manxb;
                if (DbConnection.conn.State == ConnectionState.Closed)
                {
                    DbConnection.Instance.OpenConnection();
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!");
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
        public void SuaNhaXuatBan(NhaXuatBan nhaxuatban)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Proc_SuaNhaXuaBan", DbConnection.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaNXB", SqlDbType.VarChar, 10).Value = nhaxuatban.Manxb;
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 100).Value = nhaxuatban.Ten;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 255).Value = nhaxuatban.Diachi;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = nhaxuatban.Email;
                cmd.Parameters.Add("@Sdt", SqlDbType.VarChar, 10).Value = nhaxuatban.Sdt;
                if (DbConnection.conn.State == ConnectionState.Closed)
                {
                    DbConnection.Instance.OpenConnection();
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!");
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
