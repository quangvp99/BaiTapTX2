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
    class TacGiaBUL
    {
        TacGiaDAL tg = new TacGiaDAL();
        public DataTable LoadAuthor()
        {
            return tg.LoadTacGia();
        }
        public bool themAuthor(TacGia TG)
        {
            return tg.themAuthor(TG);
        }

        public bool suaAuthor(TacGia TG)
        {
            return tg.SuaAuthor(TG);
        }

        public bool xoaAuthor(TacGia TG)
        {
            return tg.XoaAuthor(TG);
        }
    }
}
