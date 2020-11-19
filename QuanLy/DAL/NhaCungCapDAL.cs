using QuanLy.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy.DAL
{
    class NhaCungCapDAL
    {
        Connection con = new Connection();
        SqlConnection con1;
        public DataTable LoadNhaCungCap()
        {
            return con.LoadData("Select * from NhaCungCap");
        }
        //thêm nha cung cấp
        public bool themNhaCungCap(NhaCungCap ncc)
        {
            con1 = con.getConnection();
            try
            {
                con1.Open();
                string SQL = string.Format("insert into NhaCungCap values(@MaNCC, @TenNCC, @DiaChi, @SDT)");
                SqlCommand cmd = new SqlCommand(SQL, con1);
                cmd.Parameters.AddWithValue("@MaNCC", ncc.maNCC);
                cmd.Parameters.AddWithValue("@TenNCC", ncc.tenNCC);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.diaChi);
                cmd.Parameters.AddWithValue("@SDT", ncc.sdt);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception)
            {

            }
            finally
            {
                // Dong ket noi
                con1.Close();
            }
            return false;
        }
        //sửa nhà cung cấp
        public bool SuaNhaCungCap(NhaCungCap ncc)
        {
            con1 = con.getConnection();
            try
            {
                con1.Open();
                string SQL = string.Format("UPDATE NhaCungCap SET TenNCC =@TenNCC, DiaChi =@DiaChi, SDT=@SDT  where  MaNCC =@MaNCC ");

                SqlCommand cmd = new SqlCommand(SQL, con1);
                cmd.Parameters.AddWithValue("@MaNCC", ncc.maNCC);
                cmd.Parameters.AddWithValue("@TenNCC", ncc.tenNCC);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.diaChi);
                cmd.Parameters.AddWithValue("@SDT", ncc.sdt);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception)
            {

            }
            finally
            {
                con1.Close();
            }

            return false;
        }
        //Xóa nhà cung cấp
        public bool XoaNhaCungCap(NhaCungCap ncc)
        {
            con1 = con.getConnection();
            try
            {
                con1.Open();
                string SQL = string.Format("DELETE FROM NhaCungCap WHERE MaNCC =@MaNCC");

                SqlCommand cmd = new SqlCommand(SQL, con1);
                cmd.Parameters.AddWithValue("@MaNCC", ncc.maNCC);
                cmd.Parameters.AddWithValue("@TenNCC", ncc.tenNCC);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.diaChi);
                cmd.Parameters.AddWithValue("@SDT", ncc.sdt);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception)
            {

            }
            finally
            {
                con1.Close();
            }

            return false;
        }
    }
}
