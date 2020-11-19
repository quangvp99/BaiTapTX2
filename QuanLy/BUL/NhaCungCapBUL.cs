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
    class NhaCungCapBUL
    {
       NhaCungCapDAL tg = new NhaCungCapDAL();
        public DataTable LoadNCC()
        {
            return tg.LoadNhaCungCap();
        }
        public bool themNCC(NhaCungCap TG)
        {
            return tg.themNhaCungCap(TG);
        }

        public bool suaNCC(NhaCungCap TG)
        {
            return tg.SuaNhaCungCap(TG);
        }

        public bool xoaNCC(NhaCungCap TG)
        {
            return tg.XoaNhaCungCap(TG);
        }
    }
}
