using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLy.BUL;
using QuanLy.DAL;
using QuanLy.DTO;

namespace QuanLy
{
    public partial class UsTimKiem : UserControl
    {
        SachBUL book = new SachBUL();
        HoaDonBUL hd = new HoaDonBUL();
        PhieuNhapHangBUL PN = new PhieuNhapHangBUL();


        public UsTimKiem()
        {
            InitializeComponent();
        }

        private void UsTimKiem_Load(object sender, EventArgs e)
        {

        }
        private void ClearTextBoxSach()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
        }

        //Tìm Kiếm Sách Theo tên Sách
        private void btnSearchBook_Click(object sender, EventArgs e)
        {

            if(txtTenSach.Text != "" || txtMaSach.Text !="" )
            {
                MessageBox.Show("Tìm kiếm thành công");
                dGV_Sach.DataSource = book.TimKiemSach(txtMaSach.Text, txtTenSach.Text);

            }
            else
            {
               
                   MessageBox.Show("Bạn Phải Nhập thông tin trước khi tìm kiếm");
            }
        }

        private void btnThoatSach_Click(object sender, EventArgs e)
        {
            ClearTextBoxSach();
            dGV_Sach.DataSource = book.TimKiemSach(txtMaSach.Text, txtTenSach.Text);
            MessageBox.Show("Hủy thành công");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ClearTextBoxSach();
            dGV_Sach.DataSource = book.LoadSach();
        }
        private void btnXuatDLSach_Click(object sender, EventArgs e)
        {
            ExportToExcel excel = new ExportToExcel();
            //lấy về nguồn dữ liệu
            DataTable dt = (DataTable)dGV_Sach.DataSource;
            excel.Export(dt, "Danh Sách 1", "Quản Lý Sách", "Mã sách", "Tên sách", "Thể loại", "Tác giả", "Đơn giá bán", "Số lượng có","");


        }
        /*
        * Tìm kiếm theo hóa đơn
        * 
        */
        private void ClearTextBox1()
        {
            txtSHD.Text = "";
            txtNhanVien.Text = "";
        }

        //Tìm kiếm tất cả
        private void btnLaod1_Click(object sender, EventArgs e)
        {
            ClearTextBox1();
            dGV_SHD.DataSource = hd.LoadAll();
        }

        //hủy
        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            ClearTextBox1();
            dGV_SHD.DataSource = hd.SearchBill(txtSHD.Text, txtNhanVien.Text);
            MessageBox.Show("Hủy thành công");
        }

        private void btnSearchSHD_Click(object sender, EventArgs e)
        {
            if (txtSHD.Text != "" || txtNhanVien.Text != "")
            {
                MessageBox.Show("Tìm kiếm thành công");
                dGV_SHD.DataSource = hd.SearchBill(txtSHD.Text, txtNhanVien.Text);

            }
            else
            {

                MessageBox.Show("Bạn Phải Nhập thông tin trước khi tìm kiếm");
            }
        }

        //xuất dữ liệu excel
        private void btnXuatDL_Click(object sender, EventArgs e)
        {
            ExportToExcel excel = new ExportToExcel();
            //lấy về nguồn dữ liệu
            DataTable dt = (DataTable)dGV_SHD.DataSource;
            excel.Export(dt, "Danh Sách 2", "Hóa Đơn Bán", "Số HD", "Ngày lập", "Khách hàng", "Nhân viên", "Số lượng bán", "Đơn giá bán", "");
        }
        /*
         * Phiếu nhập 
         * tìm kiếm
         * Xuất dữ liệu
         * 
         */
        private void ClearTextBox2()
        {
            txtSoPhieu.Text = "";
            txtNV.Text = "";
        }
        private void btnTKSP_Click(object sender, EventArgs e)
        {
            if (txtSoPhieu.Text != "" || txtNV.Text != "")
            {
                MessageBox.Show("Tìm kiếm thành công");
                dGV_SP.DataSource = PN.SearchPhieuNhap(txtSoPhieu.Text, txtNV.Text);

            }
            else
            {

                MessageBox.Show("Bạn Phải Nhập thông tin trước khi tìm kiếm");
            }
        }

        private void btnHuySP_Click(object sender, EventArgs e)
        {
            ClearTextBox2();
            dGV_SP.DataSource = PN.SearchPhieuNhap(txtSoPhieu.Text, txtNV.Text);
            MessageBox.Show("Hủy thành công");

        }

        private void btnLoad2_Click(object sender, EventArgs e)
        {
            ClearTextBox2();
            dGV_SP.DataSource = PN.loadAll();
        }

        private void btnXuatDLSP_Click(object sender, EventArgs e)
        {
            ExportToExcel excel = new ExportToExcel();
            //lấy về nguồn dữ liệu
            DataTable dt = (DataTable)dGV_SP.DataSource;
            excel.Export(dt, "Danh Sách 3", "Hóa Đơn Nhập", "Số phiếu", "Mã nhân viên", "Ngày lập", "Nhà cung cấp", "Mã sách", "Số lượng nhập", "Đơn giá nhập");
        }

        /*
         * 
         * 
         */

    }
}
