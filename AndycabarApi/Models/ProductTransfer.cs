namespace AndycabarApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductTransfer")]
    public partial class ProductTransfer
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductBarcode { get; set; }

        public DateTime ProduceEvent { get; set; }

        public DateTime EntranceEvent { get; set; }

        public DateTime BarcodeEvent { get; set; }

        public DateTime SaleEvent { get; set; }

        public virtual Product Product { get; set; }
    }
}
