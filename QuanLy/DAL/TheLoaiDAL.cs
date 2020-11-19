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
    class TheLoaiDAL
    {
        Connection con = new Connection();
        SqlConnection con1;
        public DataTable LoadType()
        {
            return con.LoadData("Select * from TheLoai");
        }
        //thêm thể loại
        public bool themType(TheLoai tl)
        {
            con1 = con.getConnection();
            try
            {
                con1.Open();
                string SQL = string.Format("insert into TheLoai values(@MaTL, @TenTL)");
                SqlCommand cmd = new SqlCommand(SQL, con1);
                cmd.Parameters.AddWithValue("@MaTL", tl.maTL);
                cmd.Parameters.AddWithValue("@TenTL", tl.tenTL);
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
        //sửa thể loại
        public bool SuaType(TheLoai tl)
        {
            con1 = con.getConnection();
            try
            {
                con1.Open();
                string SQL = string.Format("UPDATE TheLoai SET TenTL =@TenTL where  MaTL =@MaTL ");

                SqlCommand cmd = new SqlCommand(SQL, con1);
                cmd.Parameters.AddWithValue("@MaTL", tl.maTL);
                cmd.Parameters.AddWithValue("@TenTL", tl.tenTL);

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
        //Xóa thể loại
        public bool XoaType(TheLoai tl)
        {
            con1 = con.getConnection();
            try
            {
                con1.Open();
                string SQL = string.Format("DELETE FROM TheLoai WHERE MaTL =@MaTL");

                SqlCommand cmd = new SqlCommand(SQL, con1);
                cmd.Parameters.AddWithValue("@MaTL", tl.maTL);
                cmd.Parameters.AddWithValue("@TenTL", tl.tenTL);

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
