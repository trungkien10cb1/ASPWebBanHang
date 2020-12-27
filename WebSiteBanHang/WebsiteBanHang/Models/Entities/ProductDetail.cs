namespace WebsiteBanHang.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductDetail")]
    public partial class ProductDetail
    {
        [Key]
        [StringLength(50)]
        public string masanpham { get; set; }

        [StringLength(10)]
        public string ram { get; set; }

        [StringLength(20)]
        public string diacung { get; set; }

        [StringLength(20)]
        public string vga { get; set; }

        [StringLength(20)]
        public string manhinh { get; set; }

        [StringLength(20)]
        public string vixuly { get; set; }

        public virtual Product Product { get; set; }
    }
}
