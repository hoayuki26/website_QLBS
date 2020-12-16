namespace finaltest.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã khách hàng")]
        public int MaKH { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Họ tên")]
        public string Hoten { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Số điện thoại")]
        public int? SDT { get; set; }

        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
    }
}
