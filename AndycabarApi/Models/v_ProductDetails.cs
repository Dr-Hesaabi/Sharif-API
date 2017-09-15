namespace AndycabarApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_ProductDetails
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Description { get; set; }

        public decimal? Profit { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal SalePrice { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(150)]
        public string DetailedName { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal CompanyCost { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupId { get; set; }

        public byte[] Image { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Barcode { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ProductId { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime ProduceEvent { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime EntranceEvent { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime BarcodeEvent { get; set; }

        [Key]
        [Column(Order = 11)]
        public DateTime SaleEvent { get; set; }

        [Key]
        [Column(Order = 12)]
        public DateTime SubmitEvent { get; set; }

        [Key]
        [Column(Order = 13)]
        public DateTime ExpireEvent { get; set; }
    }
}
