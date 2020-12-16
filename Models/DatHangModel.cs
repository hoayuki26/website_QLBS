using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace finaltest.Models
{
    public class DatHangModel
    {
        dataconnection db = new dataconnection();
        public void createDH(DatHang x)
        {
            string sql = "insert into DatHang values('" + x.MaKH + "',N'" + x.Hoten + "','" + x.Email + "','" + x.Phone + "',N'" + x.Diachi + "','" + x.Ngaydat + "','" + x.Tongtien + "')";
            db.ghidulieu(sql);
        }
        //public void createCTDH(DatHang x)
        //{
        //    string sql = "insert into DatHangDetail values('" + x.MaDH + "',N'" + x.Hoten + "','" + x.Email + "','" + x.Phone + "',N'" + x.Diachi + "','" + x.Ngaydat + "','" + x.Tongtien + "')";
        //    db.ghidulieu(sql);
        //}
        public List<DatHang> getalldonhang()
        {
            DataTable dt = db.laydulieu("Select * from DatHang");
            List<DatHang> li = new List<DatHang>();
            foreach (DataRow dr in dt.Rows)
            {
                DatHang nv = new DatHang();
                nv.MaDH = int.Parse(dr[0].ToString());
                nv.MaKH = int.Parse(dr[1].ToString());
                nv.Hoten = dr[2].ToString();
                nv.Email = dr[3].ToString();
                nv.Phone = int.Parse(dr[4].ToString());
                nv.Diachi = dr[5].ToString();
                nv.Ngaydat = dr[6].ToString();
                nv.Tongtien = double.Parse(dr[7].ToString());
                li.Add(nv);
            }
            return li;

        }
    }
}