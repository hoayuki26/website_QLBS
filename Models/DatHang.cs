using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finaltest.Models
{
    public class DatHang
    {
        public int MaDH { get; set; }
        public int MaKH { get; set; }
        public string Hoten { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Diachi { get; set; }
        public string Ngaydat { get; set; }
        public double Tongtien { get; set; }
    }
}