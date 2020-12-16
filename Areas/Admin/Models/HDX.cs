namespace finaltest.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HDX")]
    public partial class HDX
    {
        [Key]
        [StringLength(10)]
        [DisplayName("Mã hóa đơn")]
        public string MaHD { get; set; }

        [DisplayName("Mã khách hàng")]
        public int? MaKH { get; set; }

        [StringLength(10)]
        [DisplayName("Mã sản phẩm")]
        public string MaSP { get; set; }

        [DisplayName("Số lượng")]
        public int? SL { get; set; }

        [DisplayName("Ngày bán")]
        public DateTime? NgayBan { get; set; }

        [DisplayName("Tổng tiền")]
        public double? Tongtien { get; set; }
    }
}
