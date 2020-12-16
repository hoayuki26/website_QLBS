using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finaltest.Models
{
    public class DatHangDetail
    {
        public int MaCTDH { get; set; }
        public int MaDH { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Anh { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public double GiamGia { get; set; }
        public double Tongtien { get; set; }
    }
}