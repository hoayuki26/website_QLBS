namespace finaltest.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSP")]
    public partial class LoaiSP
    {
        [Key]
        [StringLength(10)]
        [DisplayName("Mã loại")]
        public string MaLoai { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên loại")]
        public string TenLoai { get; set; }

        [StringLength(50)]
        [DisplayName("Ghi chú")]
        public string Ghichu { get; set; }
    }
}
