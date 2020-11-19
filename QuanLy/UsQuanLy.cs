using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLy.DTO;
using QuanLy.BUL;

namespace QuanLy
{
    public partial class UsQuanLy : UserControl
    {
        NhanVienBUL nv = new NhanVienBUL();
        SachBUL sach = new SachBUL();
        TacGiaBUL tg = new TacGiaBUL();
        TheLoaiBUL tl = new TheLoaiBUL();
        NhaCungCapBUL NCC = new NhaCungCapBUL();

        public UsQuanLy()
        {
            InitializeComponent();
        }

        private void UsQuanLy_Load(object sender, EventArgs e)
        {
            dGV_NhanVien.DataSource= nv.LoadNhanVien();
            dGV_Sach.DataSource = sach.LoadSach();
            dDV_TacGia.DataSource = tg.LoadAuthor();
            dGVTheLoai.DataSource = tl.LoadType();
            dGV_NCC.DataSource = NCC.LoadNCC();
            ComboBox_theLoai();
            comboBox_TacGia();

        }
       /*
        * 1. Quản lý nhân viên
        * thêm
        * sửa x
        * xóa
        * load
        * 
        */
        private void ClearTextBox()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtGioiTinh.Clear();
            dTG_NgaySinh.Value = Convert.ToDateTime(DateTime.Today.ToString());
            txtDiaChi.Clear();
            txtSDTNV.Clear();
        }
        private void btnThem_NhanVien_Click(object sender, EventArgs e)
        {
            if(txtMaNV.Text != "" && txtTenNV.Text != ""&& txtGioiTinh.Text !="" && txtDiaChi.Text !="" && txtSDTNV.Text !="")
            {
                NhanVien nhanvien;
                nhanvien = new NhanVien(txtMaNV.Text, txtTenNV.Text,txtGioiTinh.Text,Convert.ToDateTime(dTG_NgaySinh.Value.ToString("MM/dd/yyyy")), txtDiaChi.Text, txtSDTNV.Text);
                if(nv.themNhanVien(nhanvien))
                {
                    dGV_NhanVien.DataSource = nv.LoadNhanVien();
                    MessageBox.Show("Thêm mới thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm mới không thành công!");
                }
                ClearTextBox();
            }
            else
            {
                MessageBox.Show("Nhập thông tin trước khi thêm mới!");
            }    
        }

        private void btn_SuaNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "" && txtGioiTinh.Text !="" && txtTenNV.Text != "" && txtDiaChi.Text != "" && txtSDTNV.Text != "")
            {
                NhanVien nhanvien = new NhanVien(txtMaNV.Text, txtTenNV.Text, txtGioiTinh.Text, Convert.ToDateTime(dTG_NgaySinh.Value.ToString("MM/dd/yyyy")), txtDiaChi.Text, txtSDTNV.Text);

                if (nv.suaNhanVien(nhanvien))
                {
                    dGV_NhanVien.DataSource = nv.LoadNhanVien();
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Sửa không thành công!");
                }
                ClearTextBox();
            }
            else
            {
                MessageBox.Show("Nhập thông tin trước khi sửa!");
            }
        }

        private void btn_XoaNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "" )
            {
                NhanVien nhanvien = new NhanVien(txtMaNV.Text, txtTenNV.Text, txtGioiTinh.Text, Convert.ToDateTime(dTG_NgaySinh.Value.ToString("MM/dd/yyyy")), txtDiaChi.Text, txtSDTNV.Text);
                if (nv.xoaNhanVien(nhanvien))
                {
                    dGV_NhanVien.DataSource = nv.LoadNhanVien();
                    MessageBox.Show("Xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công!");
                }
                ClearTextBox();
            }
            else
            {
                MessageBox.Show("Cần nhập thông tin trước khi xóa!");
            }
        }

        private void dGV_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dGV_NhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dGV_NhanVien.CurrentRow.Cells["TenNV"].Value.ToString();
            txtGioiTinh.Text = dGV_NhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString();
            dTG_NgaySinh.Text = dGV_NhanVien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txtDiaChi.Text = dGV_NhanVien.CurrentRow.Cells["diaChiNV"].Value.ToString();
            txtSDTNV.Text = dGV_NhanVien.CurrentRow.Cells["SDTNV"].Value.ToString();
        }
        /*
         * Quản lý sách
         * thêm
         * sửa
         * xóa
         * load
         */
         
         private void ComboBox_theLoai()
        {
            cbb_TheLoai.DataSource = sach.TheLoai();
            cbb_TheLoai.DisplayMember = "MaTL";
            cbb_TheLoai.ValueMember = "MaTL";
            cbb_TheLoai.SelectedIndex = -1;
        }

        private void comboBox_TacGia()
        {
            cbb_TacGia.DataSource = sach.TacGia();
            cbb_TacGia.DisplayMember = "MaTG";
            cbb_TacGia.ValueMember = "MaTG";
            cbb_TacGia.SelectedIndex = -1;
        }
        
        private void ClearText()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtSoLuong.Clear();
            txtPrice.Clear();
            cbb_TacGia.SelectedIndex = -1;
            cbb_TheLoai.SelectedIndex = -1;
        }
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text != "" && txtTenSach.Text != "" && txtSoLuong.Text != "" && txtPrice.Text != "" && cbb_TheLoai.SelectedValue.ToString() != "" && cbb_TacGia.SelectedValue.ToString() != "")
            {
                Sach s =  new Sach(txtMaSach.Text, txtTenSach.Text, cbb_TheLoai.SelectedValue.ToString(), cbb_TacGia.SelectedValue.ToString(), Convert.ToSingle(txtPrice.Text), Convert.ToInt32(txtSoLuong.Text));
                if (sach.ThemSach(s))
                {
                    dGV_Sach.DataSource = sach.LoadSach();
                    MessageBox.Show("Thêm mới thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm mới không thành công!");
                }
                ClearText();
            }
            else
            {
                MessageBox.Show("Nhập thông tin trước khi thêm mới!");
            }
        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text != "" && txtTenSach.Text != "" && txtSoLuong.Text != "" && txtPrice.Text != "" && cbb_TheLoai.SelectedValue.ToString() != "" &&  cbb_TacGia.SelectedValue.ToString() != "")
            {
                Sach s = new Sach(txtMaSach.Text, txtTenSach.Text, cbb_TheLoai.SelectedValue.ToString(), cbb_TacGia.SelectedValue.ToString(), Convert.ToSingle(txtPrice.Text), Convert.ToInt32(txtSoLuong.Text));
                if (sach.SuaSach(s))
                {
                    dGV_Sach.DataSource = sach.LoadSach();
                    MessageBox.Show(" sửa thành công!");
                }
                else
                {
                    MessageBox.Show("sửa không thành công!");
                }
                ClearText();
            }
            else
            {
                MessageBox.Show("Nhập thông tin trước khi sửa!");
            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text != "" && txtTenSach.Text != "" && txtSoLuong.Text != "" && txtPrice.Text != "" && cbb_TheLoai.SelectedValue.ToString() != "" && cbb_TacGia.SelectedValue.ToString() != "")
            {
                Sach s = new Sach(txtMaSach.Text, txtTenSach.Text, cbb_TheLoai.SelectedValue.ToString(), cbb_TacGia.SelectedValue.ToString(), Convert.ToSingle(txtPrice.Text), Convert.ToInt32(txtSoLuong.Text));
                if (sach.XoaSach(s))
                {
                    dGV_Sach.DataSource = sach.LoadSach();
                    MessageBox.Show("Xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công!");
                }
                ClearText();
            }
            else
            {
                MessageBox.Show("Nhập thông tin trước khi xóa!");
            }
        }

        private void dGV_Sach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSach.Text = dGV_Sach.CurrentRow.Cells["MaSach"].Value.ToString();
            txtTenSach.Text = dGV_Sach.CurrentRow.Cells["TenSach"].Value.ToString();
            txtSoLuong.Text = dGV_Sach.CurrentRow.Cells["SoLuongCo"].Value.ToString();
            txtPrice.Text = dGV_Sach.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            cbb_TheLoai.Text = dGV_Sach.CurrentRow.Cells["MaTL"].Value.ToString();
            cbb_TacGia.Text = dGV_Sach.CurrentRow.Cells["MaTG"].Value.ToString();
        }

        /*
         * 3. Quản lý tác giả 
         *thêm
         *sửa
         *xóa
         *load dữ liệu
         *
         */
        private void ClearTextTG()
        {
            txt_maTG.Clear();
            txt_TenTG.Clear();
        }

        private void btn_ThemTG_Click(object sender, EventArgs e)
        {
            if (txt_maTG.Text != "" && txt_TenTG.Text != "" )
            {
                TacGia tacgia;
                tacgia = new TacGia(txt_maTG.Text, txt_TenTG.Text);
                if (tg.themAuthor(tacgia))
                {
                    dDV_TacGia.DataSource = tg.LoadAuthor();
                    MessageBox.Show("Thêm mới thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm mới không thành công!");
                }
                ClearTextTG();
            }
            else
            {
                MessageBox.Show("Nhập thông tin trước khi thêm mới!");
            }
        }

        private void btn_SuaTG_Click(object sender, EventArgs e)
        {
            if (txt_maTG.Text != "" && txt_TenTG.Text != "")
            {
                TacGia tacgia;
                tacgia = new TacGia(txt_maTG.Text, txt_TenTG.Text);
                if (tg.suaAuthor(tacgia))
                {
                    dDV_TacGia.DataSource = tg.LoadAuthor();
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Sửa không thành công!");
                }
                ClearTextTG();
            }
            else
            {
                MessageBox.Show("Nhập thông tin trước khi sửa!");
            }
        }

        private void btn_XoaTG_Click(object sender, EventArgs e)
        {
            if (txt_maTG.Text != "")
            {
                TacGia tacgia;
                tacgia = new TacGia(txt_maTG.Text, txt_TenTG.Text);
                if (tg.xoaAuthor(tacgia))
                {
                    dDV_TacGia.DataSource = tg.LoadAuthor();
                    MessageBox.Show("Xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công! Vui lòng Kiểm tra lại");
                }
                ClearTextTG();
            }
            else
            {
                MessageBox.Show("Cần nhập thông tin trước khi xóa!");
            }
           
        }

        private void dDV_TacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_maTG.Text = dDV_TacGia.CurrentRow.Cells["MaTG1"].Value.ToString();
            txt_TenTG.Text = dDV_TacGia.CurrentRow.Cells["TenTG"].Value.ToString();
        }

        /*
         * 4. Thể loại
         * thêm
         * sưa
         * xóa
         * load
         * 
         * 
         */
        private void DeleteText2()
        {
            txtmaTL.Clear();
            txtTenTL.Clear();
        }
        private void btnThemTL_Click(object sender, EventArgs e)
        {
            if (txtmaTL.Text != "" && txtTenTL.Text != "")
            {
                TheLoai theloai;
                theloai = new TheLoai(txtmaTL.Text, txtTenTL.Text);
                if (tl.themType(theloai))
                {
                    dGVTheLoai.DataSource = tl.LoadType();
                    MessageBox.Show("Thêm mới thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm mới không thành công!Vui lòng kiểm tra lại!");
                }
                DeleteText2();
            }
            else
            {
                MessageBox.Show("Nhập thông tin trước khi thêm mới!");
            }
        }

        private void btnSuaTL_Click(object sender, EventArgs e)
        {
            if (txtmaTL.Text != "" && txtTenTL.Text != "")
            {
                TheLoai theloai;
                theloai = new TheLoai(txtmaTL.Text, txtTenTL.Text);
                if (tl.suaType(theloai))
                {
                    dGVTheLoai.DataSource = tl.LoadType();
                    MessageBox.Show(" Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Sửa không thành công!Vui lòng kiểm tra lại!");
                }
                DeleteText2();
            }
            else
            {
                MessageBox.Show("Nhập thông tin trước khi sửa!");
            }
        }

        private void btnXoaTL_Click(object sender, EventArgs e)
        {
            if (txtmaTL.Text != "")
            {
                TheLoai theloai;
                theloai = new TheLoai(txtmaTL.Text, txtTenTL.Text);
                if (tl.xoaType(theloai))
                {
                    dGVTheLoai.DataSource = tl.LoadType();
                    MessageBox.Show("Xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công! Vui lòng Kiểm tra lại");
                }
                DeleteText2();
            }
            else
            {
                MessageBox.Show("Cần nhập thông tin trước khi xóa!");
            }
        }

        private void dGVTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaTL.Text = dGVTheLoai.CurrentRow.Cells["MaTL1"].Value.ToString();
            txtTenTL.Text = dGVTheLoai.CurrentRow.Cells["TenTL"].Value.ToString();
        }

        /*
         * 5. Nhà cung cấp
         * thêm
         * sửa
         * xóa
         * Load
         * 
         */
        private void DeleteText3()
        {
            txtmaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChiNCC.Clear();
            txtSDTncc.Clear();
        }
        private void DisEnabledComboBox(bool e)
        {
            cbb_TacGia.Enabled = !e;
            cbb_TheLoai.Enabled = !e;
        }
        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            if (txtmaNCC.Text != "" && txtTenNCC.Text != "" && txtDiaChiNCC.Text != "" && txtSDTncc.Text != "")
            {
                NhaCungCap nc;
                nc = new NhaCungCap(txtmaNCC.Text, txtTenNCC.Text, txtDiaChiNCC.Text, txtSDTncc.Text);
              
                if (NCC.themNCC(nc))
                {
                    dGV_NCC.DataSource = NCC.LoadNCC();
                    MessageBox.Show("Thêm mới thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm mới không thành công!Vui lòng kiểm tra lại!");
                }
                DeleteText3();
            }
            else
            {
                MessageBox.Show("Nhập thông tin trước khi thêm mới!");
            }
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            if (txtmaNCC.Text != "" && txtTenNCC.Text != "" && txtDiaChiNCC.Text != "" && txtSDTncc.Text != "")
            {
                NhaCungCap nc;
                nc = new NhaCungCap(txtmaNCC.Text, txtTenNCC.Text, txtDiaChiNCC.Text, txtSDTncc.Text);

                if (NCC.suaNCC(nc))
                {
                    dGV_NCC.DataSource = NCC.LoadNCC();
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Sửa không thành công!Vui lòng kiểm tra lại!");
                }
                DeleteText3();
            }
            else
            {
                MessageBox.Show("Nhập thông tin trước khi sửa!");
            }
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            if (txtmaNCC.Text != "")
            {
                NhaCungCap nc;
                nc = new NhaCungCap(txtmaNCC.Text, txtTenNCC.Text, txtDiaChiNCC.Text, txtSDTncc.Text);
                if (NCC.xoaNCC(nc))
                {
                    dGV_NCC.DataSource = NCC.LoadNCC();
                    MessageBox.Show("Xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công! Vui lòng Kiểm tra lại");
                }
                DeleteText3();
            }
            else
            {
                MessageBox.Show("Cần nhập thông tin trước khi xóa!");
            }

        }

        private void dGV_NCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaNCC.Text = dGV_NCC.CurrentRow.Cells["MaNCC1"].Value.ToString();
            txtTenNCC.Text = dGV_NCC.CurrentRow.Cells["TenNCC"].Value.ToString();
            txtDiaChiNCC.Text = dGV_NCC.CurrentRow.Cells["DiaChi1"].Value.ToString();
            txtSDTncc.Text = dGV_NCC.CurrentRow.Cells["SDT1"].Value.ToString();
        }

        private void btnXuatDuLieu_Click(object sender, EventArgs e)
        {
            ExportToExcel excel = new ExportToExcel();
            //lấy về nguồn dữ liệu
            DataTable dt = (DataTable) dGV_Sach.DataSource;
            excel.Export(dt, "Danh Sách thứ 0", "Quản Lý sách", "Mã sách", "Tên sách", "Thể loại", "Tác giả", "Đơn giá bán", "Số lượng có","");

        }
    }
}
