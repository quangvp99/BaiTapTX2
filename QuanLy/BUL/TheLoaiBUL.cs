using QuanLy.DAL;
using QuanLy.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy.BUL
{
    class TheLoaiBUL
    {
        TheLoaiDAL tl = new TheLoaiDAL();
        public DataTable LoadType()
        {
            return tl.LoadType();
        }
        public bool themType(TheLoai TG)
        {
            return tl.themType(TG);
        }

        public bool suaType(TheLoai TG)
        {
            return tl.SuaType(TG);
        }

        public bool xoaType(TheLoai TG)
        {
            return tl.XoaType(TG);
        }
    }
}
