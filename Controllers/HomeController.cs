using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finaltest.Models;
using System.Data;
using PagedList;

namespace finaltest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // GET: Home
        //Khởi tạo các đối tượng
        
        SanPhamModel dbsp = new SanPhamModel();
        LoaiSPModel dblsp = new LoaiSPModel();
        DatHangModel dbdh = new DatHangModel();
        DatHangDetailModel dbctdh = new DatHangDetailModel();
        public ActionResult Index(int? page = 1)//chỉ định tồn tại
        {

            List<SanPham> dssp = dbsp.getAllSanPham();
            int pageSize = 5;//hiển thị 5 sp trên 1 trang
            int pageNumber = (page ?? 1);

            return View(dssp.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult getAllLoaiSP()
        {
            List<LoaiSP> dslsp = dblsp.getAllLoaiSP();
            return View(dslsp);
        }
        public ActionResult getSPByLoaiSP(string id, int? page = 1)
        {
            var loai = dblsp.getAllLoaiSP();
            ViewBag.loaisp = loai;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var dt = loai.FirstOrDefault(s => s.MaLoai.ToString().Contains(id)).TenLoai;
            ViewBag.tenloai = dt;

            List<SanPham> dssp = dbsp.getSP_LoaiSP(id);
            return View(dssp.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult SPDetail(string id)
        {
            var loai = dblsp.getAllLoaiSP();
            ViewBag.loaisp = loai;

            //lay ve cac san pham tuong tu
            var ds = dbsp.get1SanPham(id);
            //loai bo san pham ma minh da hien thi
            var dssp = dbsp.getSP_LoaiSP(ds.MaLoai).Where(s => s.MaSP != ds.MaSP).ToList();
            ViewBag.sptt = dssp;
            return View(ds);
        }
        //public ActionResult MuaHang(string id)
        //{
        //    //Chưa có sản phẩm thì thêm vào giỏ hàng
        //    List<GioHang> gh = null;
        //    if (Session["giohang"] == null)
        //    {
        //        //khởi tạo giỏ hàng a
        //        GioHang a = new GioHang();
        //        //khai báo biến sp lưu trữ thông tin của sản phẩm đang chọn
        //        var sp = dbsp.get1SanPham(id);//gồm thuộc tính MaSP, tenSP, SL, Dongia, MaLoai, Anh,...
        //        //đưa thông tin của sản phẩm vào giỏ hàng
        //        a.ID = sp.MaSP;
        //        a.Ten = sp.TenSP;
        //        a.Anh = sp.Anh;
        //        a.SL = 1;//mỗi lần mua mặc định cho mua 1 SP
        //        a.Gia = sp.DonGia;
        //        gh = new List<GioHang>();
        //        //thêm sản phẩm a vào giỏ hàng
        //        gh.Add(a);
        //        //thêm dữ liệu vào biến session
        //        Session["giohang"] = gh;
        //    }
        //    //khi có sản phẩm trong giỏ hàng rồi
        //    else
        //    {
        //        //đưa có DL có sẵn từ biến session vào giỏ hàng
        //        gh = (List<GioHang>)Session["giohang"];
        //        //khai báo biến test kiểm tra có phải sản phẩm đang có trong giỏ hàng không
        //        var test = gh.Find(s => s.ID == id);
        //        if (test == null)
        //        {
        //            GioHang a = new GioHang();
        //            var sp = dbsp.get1SanPham(id);
        //            a.ID = sp.MaSP;
        //            a.Ten = sp.TenSP;
        //            a.Anh = sp.Anh;
        //            a.SL = 1;
        //            a.Gia = sp.DonGia;
        //            gh.Add(a);
        //        }
        //        else
        //        {
        //            test.SL = int.Parse(test.SL.ToString()) + 1;
        //        }
        //        //đưa dữ liệu vào biến session
        //        Session["giohang"] = gh;
        //    }
        //    int tongtien = 0;
        //    int soluong = 0;
        //    //duyệt lần lượt từng sản phẩm trong giỏ hàng, mỗi sản phẩm 
        //    foreach (GioHang x in gh)
        //    {
        //        tongtien += x.SL * x.Gia;//tongtien = tongtien + (x.SL*x.Gia);
        //    }
        //    //đưa ra số lượng trong giỏ hàng
        //    soluong = gh.Count;
        //    return Json(new { giohang = gh, tongtien = tongtien, soluong = soluong }, JsonRequestBehavior.AllowGet);

        //    //return RedirectToAction("Index");
        //}
        //public ActionResult xemgiohang()
        //{
        //    int tongtien = 0;
        //    List<GioHang> gh = null;
        //    ViewBag.tongtien = null;
        //    int count = 0;
        //    if (Session["giohang"] != null)
        //    {
        //        gh = (List<GioHang>)Session["giohang"];
        //        foreach (GioHang a in gh)
        //        {
        //            tongtien += a.SL * a.Gia;
        //        }
        //        count = gh.Count;
        //    }
        //    ViewBag.count = count;
        //    ViewBag.tongtien = tongtien;
        //    return View(gh);
        //}
        //public ActionResult loadgiohang()
        //{
        //    List<GioHang> gh = null;
        //    if (Session["giohang"] != null)
        //    {

        //        gh = (List<GioHang>)Session["giohang"];
        //    }
        //    int tongtien = 0;
        //    int soluong = 0;
        //    if (gh != null)
        //    {
        //        foreach (GioHang x in gh)
        //        {
        //            tongtien += x.SL * x.Gia;
        //        }
        //        soluong = gh.Count;
        //    }
        //    return Json(new { giohang = gh, tongtien = tongtien, soluong = soluong }, JsonRequestBehavior.AllowGet);
        //}
        //[HttpGet]
        //public ActionResult checkout()
        //{
        //    int tongtien = 0;
        //    List<GioHang> gh = null;
        //    ViewBag.tongtien = null;
        //    //int count = 0;
        //    if (Session["giohang"] != null)
        //    {
        //        gh = (List<GioHang>)Session["giohang"];
        //        foreach (GioHang a in gh)
        //        {
        //            tongtien += a.SL * a.Gia;
        //        }
        //        //count = gh.Count;
        //    }
        //    //ViewBag.count = count;
        //    ViewBag.tongtien = tongtien;
        //    return View(gh);
        //}
        //[HttpPost]
        //public ActionResult checkout(string ten, string email, string ho, string dienthoai, string diachi)
        //{
        //    int id = 1;
        //    try
        //    {
        //        var dt = dbdh.getalldonhang().Select(s => new { s.MaDH }).OrderByDescending(s => s.MaDH).FirstOrDefault();
        //        id = dt.MaDH + 1;
        //    }
        //    catch (Exception)
        //    {

        //    }


        //    DatHang thongtin = new DatHang();
        //    thongtin.MaKH = 1000;
        //    thongtin.Hoten = string.Format("{0},{1}", ten, ho);
        //    thongtin.Email = email;
        //    thongtin.Phone = int.Parse(dienthoai.ToString());
        //    thongtin.Diachi = diachi;
        //    thongtin.Ngaydat = DateTime.Now.ToShortDateString();
        //    double tongtien = 0;
        //    if (Session["giohang"] != null)
        //    {
        //        var gh = (List<GioHang>)Session["giohang"];
        //        foreach (GioHang a in gh)
        //        {
        //            tongtien += a.SL * a.Gia;
        //        }

        //    }
        //    thongtin.MaDH = id;
        //    thongtin.Tongtien = tongtien;
        //    dbdh.createDH(thongtin);

        //    //đưa sp vào chi tiết đơn hàng
        //    if (Session["giohang"] != null)
        //    {
        //        var gh = (List<GioHang>)Session["giohang"];
        //        foreach (GioHang a in gh)
        //        {
        //            DatHangDetail sp = new DatHangDetail();
        //            sp.MaSP = a.ID;
        //            sp.MaDH = id;
        //            sp.TenSP = a.Ten;
        //            sp.SoLuong = a.SL;
        //            sp.Gia = a.Gia;
        //            sp.Anh = a.Anh;
        //            sp.Tongtien = a.Gia * a.SL;
        //            dbctdh.createCTDH(sp);
        //        }

        //    }
        //    return View();
        //}
        //public ActionResult getCTDHByDH(string id)
        //{
        //    List<DatHangDetail> dssp = dbctdh.getCTDHByDH(id);
        //    return View(dssp);
        //}

        //[HttpGet]
        //public ActionResult giam1sanpham(string id)
        //{
        //    //khai báo 1 giỏ hàng
        //    List<GioHang> gh = null;
        //    //gán giá trị session đang lưu trữ cho biến gh
        //    gh = (List<GioHang>)Session["giohang"];
        //    //khai báo 1 sp test sao cho mã sp trùng với mã sp trong giỏ hàng
        //    var test = gh.Find(s => s.ID.ToString().Contains(id.Trim()));
        //    //khai báo số lượng đang có của sản phẩm test
        //    int soluongsp = int.Parse(test.SL.ToString());
        //    //Nếu số lượng >1
        //    if (soluongsp > 1)
        //    {
        //        //giảm số lượng đi 1
        //        test.SL = soluongsp - 1;
        //    }
        //    else
        //    {
        //        //phai xoa san pham nay trong gio hang 
        //        gh.Remove(test);
        //    }
        //    //lưu lại vào biến session
        //    Session["giohang"] = gh;
        //    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult tang1sanpham(string id)
        //{
        //    List<GioHang> gh = (List<GioHang>)Session["giohang"];
        //    var test = gh.Find(s => s.ID.ToString().Trim() == id.Trim());
        //    if (test != null)
        //    {
        //        test.SL = int.Parse(test.SL.ToString()) + 1;
        //    }
        //    Session["giohang"] = gh;
        //    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult xoa1sanpham(string id)
        //{
        //    List<GioHang> gh = null;
        //    gh = (List<GioHang>)Session["giohang"];
        //    var test = gh.Find(s => s.ID.ToString().Contains(id.Trim()));
        //    if (test != null)
        //        gh.Remove(test);
        //    Session["giohang"] = gh;
        //    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult timkiemsp(string search)
        {
            //List<SanPham> sp = dbsp.getAllSanPham();
            //var tk=sp.Find(s => s.TenSP.Contains(search));
            List<SanPham> sp = dbsp.searchTenSP(search);
            return View(sp);
        }
        public ActionResult Home()
        {
            List<SanPham> dssp = dbsp.getAllSanPham();
            return View(dssp);
        }

    }
}
