namespace AndycabarApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Associtation_TransactionProduct = new HashSet<Associtation_TransactionProduct>();
        }

        [Key]
        [StringLength(50)]
        public string Barcode { get; set; }

        [Required]
        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? Profit { get; set; }

        public decimal SalePrice { get; set; }

        [Required]
        [StringLength(150)]
        public string DetailedName { get; set; }

        public decimal CompanyCost { get; set; }

        public int GroupId { get; set; }

        public byte[] Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Associtation_TransactionProduct> Associtation_TransactionProduct { get; set; }

        public virtual Group Group { get; set; }
    }
}