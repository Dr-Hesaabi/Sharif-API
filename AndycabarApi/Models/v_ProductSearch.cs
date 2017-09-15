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
        public string Description { get; set; }

        public decimal? Profit { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal SalePrice { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal CompanyCost { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(150)]
        public string ProductName { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupId { get; set; }

        [StringLength(50)]
        public string GroupName { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessId { get; set; }

        public byte[] imageGroup { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string BusinessName { get; set; }

        [Key]
        [Column(Order = 7)]
        public string Address { get; set; }

        public byte[] Logo { get; set; }

        public byte[] imageProduct { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string Barcode { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime ProduceEvent { get; set; }

        public DateTime? EntranceEvent { get; set; }

        public DateTime? BarcodeEvent { get; set; }

        public DateTime? SaleEvent { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime SubmitEvent { get; set; }

        [Key]
        [Column(Order = 11)]
        public DateTime ExpireEvent { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long productId { get; set; }
    }
}
