using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace finaltest.Models
{
    public class DatHangDetailModel
    {
        dataconnection db = new dataconnection();
        public void createCTDH(DatHangDetail x)
        {
            string sql = "insert into DatHangDetail values('" + x.MaDH + "','" + x.MaSP + "',N'" + x.TenSP + "','" + x.Anh + "','" + x.SoLuong + "','" + x.Gia + "','" + x.GiamGia + "','" + x.Tongtien + "')";
            db.ghidulieu(sql);
        }
        public List<DatHangDetail> getCTDHByDH(string id)
        {

            DataTable dt = db.laydulieu("Select * from DatHangDetail where MaDH = '" + id + "'");
            List<DatHangDetail> li = new List<DatHangDetail>();
            foreach (DataRow dr in dt.Rows)
            {
                DatHangDetail sp = new DatHangDetail();
                sp.MaDH = int.Parse(dr[1].ToString());
                sp.TenSP = dr[3].ToString();
                sp.Anh = dr[4].ToString();
                sp.SoLuong = int.Parse(dr[5].ToString());
                sp.Gia = int.Parse(dr[6].ToString());
                sp.GiamGia = double.Parse(dr[7].ToString());
                sp.Tongtien = double.Parse(dr[8].ToString());
                li.Add(sp);
            }
            return li;
        }
    }
}