using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace finaltest.Models
{
    public class SanPhamModel
    {
        //khởi tạo 1 đối tượng thuộc lớp dataconnection
        dataconnection dbsp = new dataconnection();

        //lấy tất cả các sản phẩm
        public List<SanPham> getAllSanPham()
        {
            DataTable dt = dbsp.laydulieu("Select * from SanPham");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr[0].ToString();
                sp.TenSP = dr[1].ToString();
                sp.MoTa = dr[2].ToString();
                sp.SoLuong = int.Parse(dr[3].ToString());
                sp.DonGia = int.Parse(dr[4].ToString());
                sp.MaLoai = dr[5].ToString();
                sp.Anh = dr[6].ToString();
                li.Add(sp);
            }
            return li;

        }
        public SanPham get1SanPham(string id)
        {
            DataTable dt = dbsp.laydulieu("Select * from SanPham where MaSP='" + id + "'");

            SanPham sp = new SanPham();
            sp.MaSP = dt.Rows[0][0].ToString();
            sp.TenSP = dt.Rows[0][1].ToString();
            sp.MoTa = dt.Rows[0][2].ToString();
            sp.SoLuong = int.Parse(dt.Rows[0][3].ToString());
            sp.DonGia = int.Parse(dt.Rows[0][4].ToString());
            sp.MaLoai = dt.Rows[0][5].ToString();
            sp.Anh = dt.Rows[0][6].ToString();
            return sp;
        }
        public void createSanPham(SanPham x)
        {
            string sql = "insert into SanPham values('" + x.MaSP + "','" + x.TenSP + "','" + x.MoTa + "','" + x.SoLuong + "','" + x.DonGia + "','" + x.MaLoai + "','" + x.Anh + "')";
            dbsp.ghidulieu(sql);
        }
        public string getdate(string t)
        {
            DateTime dt = DateTime.Parse(t);
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;

        }
        public void delete1SanPham(string id)
        {
            string sql = "delete from SanPham where MaSP='" + id + "'";
            dbsp.ghidulieu(sql);
        }
        public void edit1SanPham(SanPham x)
        {
            string sql = "Update SanPham set TenSP=N'" + x.TenSP + "',MoTa=N'" + x.MoTa + "', SoLuong='" + x.SoLuong + "', DonGia='" + x.DonGia + "', MaLoai='" + x.MaLoai + "', Anh='" + x.Anh + "' where MaSP='" + x.MaSP + "'";
            dbsp.ghidulieu(sql);
        }
        public List<SanPham> getSP_LoaiSP(string id)
        {

            DataTable dt = dbsp.laydulieu("Select * from SanPham where MaLoai = '" + id + "'");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr[0].ToString();
                sp.TenSP = dr[1].ToString();
                sp.MoTa = dr[2].ToString();
                sp.SoLuong = int.Parse(dr[3].ToString());
                sp.DonGia = int.Parse(dr[4].ToString());
                sp.MaLoai = dr[5].ToString();
                sp.Anh = dr[6].ToString();
                li.Add(sp);
            }
            return li;
        }
        public List<SanPham> searchTenSP(string id)
        {
            DataTable dt = dbsp.laydulieu(string.Format("Select * from SanPham where TenSP like N'%{0}%'", id));
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr[0].ToString();
                sp.TenSP = dr[1].ToString();
                sp.MoTa = dr[2].ToString();
                sp.SoLuong = int.Parse(dr[3].ToString());
                sp.DonGia = int.Parse(dr[4].ToString());
                sp.MaLoai = dr[5].ToString();
                sp.Anh = dr[6].ToString();
                li.Add(sp);
            }
            return li;
        }
    }
}
