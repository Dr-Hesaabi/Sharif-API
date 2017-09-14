namespace AndycabarApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_ProductSearch
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Barcode { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Description { get; set; }

        public decimal? Profit { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal SalePrice { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal CompanyCost { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(150)]
        public string ProductName { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupId { get; set; }

        [StringLength(50)]
        public string GroupName { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessId { get; set; }

        public byte[] Image { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string BusinessName { get; set; }

        [Key]
        [Column(Order = 8)]
        public string Address { get; set; }

        public byte[] Logo { get; set; }
    }
}
