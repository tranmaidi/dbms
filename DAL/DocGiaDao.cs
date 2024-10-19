using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.DAL;
using QuanLyThuVien.ThuThu;
using System.Data;

namespace QuanLyThuVien.DAL
{
    class DocGiaDao
    {
        public DataTable LoadDocGia()
        {
            string query = "select * from View_DocGia";
            return DbConnection.Instance.Load(query);
        }
        public void ThemDocGia(DocGia dg)
        {
            try
            {
                DbConnection.Instance.OpenConnection();
                using (SqlCommand command = new SqlCommand("Proc_ThemDocGia", DbConnection.conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaDG", dg.Ma);
                    command.Parameters.AddWithValue("@GioiTinh", dg.Gioitinh);
                    command.Parameters.AddWithValue("@Ten", dg.Ten);
                    command.Parameters.AddWithValue("@DiaChi", dg.Diachi);
                    command.Parameters.AddWithValue("@Email", dg.Email);
                    command.Parameters.AddWithValue("@Sdt", dg.Sdt);
                    command.Parameters.AddWithValue("@NgaySinh", dg.NgaySinh);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm độc giả thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm độc giả thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                DbConnection.conn.Close();
            }
        }
        public void XoaDocGia(DocGia dg)
        {
            try
            {
                DbConnection.conn.Open();
                using (SqlCommand command = new SqlCommand("Proc_XoaDocGia", DbConnection.conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaDG", dg.Ma);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa độc giả Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa độc giả Thất Bại");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                DbConnection.conn.Close();
            }


        }
        public void SuaDocGia(DocGia dg)
        {
            try
            {
                DbConnection.conn.Open();
                using (SqlCommand command = new SqlCommand("Proc_SuaDocGia", DbConnection.conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("MaDG", dg.Ma);
                    command.Parameters.AddWithValue("@GioiTinh", dg.Gioitinh);
                    command.Parameters.AddWithValue("@Ten", dg.Ten);
                    command.Parameters.AddWithValue("@DiaChi", dg.Diachi);
                    command.Parameters.AddWithValue("@Email", dg.Email);
                    command.Parameters.AddWithValue("@Sdt", dg.Sdt);
                    command.Parameters.AddWithValue("@NgaySinh", dg.NgaySinh);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa thông tin độc giả thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin độc giả thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DbConnection.conn.Close();
            }
        }
    }
}
