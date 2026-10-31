using Microsoft.EntityFrameworkCore;

namespace BTTH8
{
    public class QLTVDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Sửa chuỗi kết nối cho đúng với máy của bạn
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\MSSQLLocalDB;Database=QLTVDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => c.Name);
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(100);

            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Book>().Property(b => b.Id).HasMaxLength(20);
            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired().HasMaxLength(300);
            modelBuilder.Entity<Book>().Property(b => b.Category).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(b => b.Price).HasColumnType("decimal(18,0)");
            modelBuilder.Entity<Book>().Ignore(b => b.NumberOfCopies);
            modelBuilder.Entity<Book>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(b => b.Category)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookCopy>().HasKey(bc => bc.BookCopyID);
            modelBuilder.Entity<BookCopy>().Property(bc => bc.BookCopyID).HasMaxLength(30);
            modelBuilder.Entity<BookCopy>().Property(bc => bc.BookId).HasMaxLength(20);
            modelBuilder.Entity<BookCopy>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCopies)
                .HasForeignKey(bc => bc.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}