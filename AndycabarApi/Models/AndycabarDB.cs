namespace AndycabarApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AndycabarDB : DbContext
    {
        public AndycabarDB()
            : base("name=AndycabarDB")
        {
        }

        public virtual DbSet<Associtation_TransactionProduct> Associtation_TransactionProduct { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Marketer> Marketers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductTransfer> ProductTransfers { get; set; }
        public virtual DbSet<SalesOfficer> SalesOfficers { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<SystemOprator> SystemOprators { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<v_Factors> v_Factors { get; set; }
        public virtual DbSet<v_ProductDetails> v_ProductDetails { get; set; }
        public virtual DbSet<v_ProductSearch> v_ProductSearch { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Business)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Business>()
                .HasMany(e => e.SalesOfficers)
                .WithRequired(e => e.Business)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Transactions)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Profit)
                .HasPrecision(13, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.SalePrice)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.CompanyCost)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Associtation_TransactionProduct)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductBarcode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductTransfers)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductTransfer>()
                .Property(e => e.Barcode)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOfficer>()
                .Property(e => e.NationalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Seller>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.Seller)
                .HasForeignKey(e => e.SellerId);

            modelBuilder.Entity<Store>()
                .Property(e => e.Latitude)
                .HasPrecision(15, 6);

            modelBuilder.Entity<Store>()
                .Property(e => e.Longitude)
                .HasPrecision(15, 6);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Sellers)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Amount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Transaction>()
                .HasMany(e => e.Associtation_TransactionProduct)
                .WithRequired(e => e.Transaction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Customer)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Marketer)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.SalesOfficer)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Seller)
                .WithRequired(e => e.User);

            modelBuilder.Entity<v_Factors>()
                .Property(e => e.Amount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<v_ProductDetails>()
                .Property(e => e.Profit)
                .HasPrecision(13, 2);

            modelBuilder.Entity<v_ProductDetails>()
                .Property(e => e.SalePrice)
                .HasPrecision(12, 2);

            modelBuilder.Entity<v_ProductDetails>()
                .Property(e => e.CompanyCost)
                .HasPrecision(12, 2);

            modelBuilder.Entity<v_ProductDetails>()
                .Property(e => e.Barcode)
                .IsUnicode(false);

            modelBuilder.Entity<v_ProductSearch>()
                .Property(e => e.Barcode)
                .IsUnicode(false);

            modelBuilder.Entity<v_ProductSearch>()
                .Property(e => e.Profit)
                .HasPrecision(13, 2);

            modelBuilder.Entity<v_ProductSearch>()
                .Property(e => e.SalePrice)
                .HasPrecision(12, 2);

            modelBuilder.Entity<v_ProductSearch>()
                .Property(e => e.CompanyCost)
                .HasPrecision(12, 2);
        }
    }
}
