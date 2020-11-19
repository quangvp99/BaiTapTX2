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
    class TacGiaDAL
    {
        Connection con = new Connection();
        SqlConnection con1;
        public DataTable LoadTacGia()
        {
            return con.LoadData("Select * from TacGia");
        }
        //thêm tác giả
        public bool themAuthor(TacGia tg)
        {
            con1 = con.getConnection();
            try
            {
                con1.Open();
                string SQL = string.Format("insert into TacGia values(@MaTG, @TenTG)");
                SqlCommand cmd = new SqlCommand(SQL, con1);
                cmd.Parameters.AddWithValue("@MaTG", tg.maTG);
                cmd.Parameters.AddWithValue("@TenTG", tg.tenTG);
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
        //sửa tác giả
        public bool SuaAuthor(TacGia tg)
        {
            con1 = con.getConnection();
            try
            {
                con1.Open();
                string SQL = string.Format("UPDATE TacGia SET TenTG =@TenTG where  MaTG =@MaTG ");

                SqlCommand cmd = new SqlCommand(SQL, con1);
                cmd.Parameters.AddWithValue("@MaTG", tg.maTG);
                cmd.Parameters.AddWithValue("@TenTg", tg.tenTG);

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
        //Xóa tác giả
        public bool XoaAuthor(TacGia tg)
        {
            con1 = con.getConnection();
            try
            {
                con1.Open();
                string SQL = string.Format("DELETE FROM TacGia WHERE MaTG =@MaTG");

                SqlCommand cmd = new SqlCommand(SQL, con1);
                cmd.Parameters.AddWithValue("@MaTG", tg.maTG);
                cmd.Parameters.AddWithValue("@TenTG", tg.tenTG);
               
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
