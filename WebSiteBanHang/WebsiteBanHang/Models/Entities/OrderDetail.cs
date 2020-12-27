namespace WebsiteBanHang.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string masanpham { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long madathang { get; set; }

        public int? soluong { get; set; }

        public decimal? dongia { get; set; }

        public virtual Order Order { get; set; }
    }
}
