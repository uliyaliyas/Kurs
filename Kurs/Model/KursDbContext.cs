using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kurs.Model;

public partial class KursDbContext : DbContext
{
    public KursDbContext()
    {
    }

    public KursDbContext(DbContextOptions<KursDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Magazine> Magazines { get; set; }

    public virtual DbSet<Rubric> Rubrics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\User\\source\\repos\\Kurs\\Kurs\\bin\\Debug\\net8.0-windows\\KursDB.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.ArticlesId);

            entity.Property(e => e.ArticlesId).HasColumnName("Articles_ID");
            entity.Property(e => e.AuthorId).HasColumnName("Author_ID");
            entity.Property(e => e.MagazineId).HasColumnName("Magazine_ID");
            entity.Property(e => e.RubricsId).HasColumnName("Rubrics_ID");

            entity.HasOne(d => d.Author).WithMany(p => p.Articles)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Magazine).WithMany(p => p.Articles)
                .HasForeignKey(d => d.MagazineId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Rubrics).WithMany(p => p.Articles)
                .HasForeignKey(d => d.RubricsId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Author");

            entity.Property(e => e.AuthorId).HasColumnName("Author_ID");
            entity.Property(e => e.Email).HasColumnName("EMail");
            entity.Property(e => e.Fio).HasColumnName("FIO");
        });

        modelBuilder.Entity<Magazine>(entity =>
        {
            entity.HasKey(e => e.MagazinesId);

            entity.Property(e => e.MagazinesId).HasColumnName("Magazines_ID");
        });

        modelBuilder.Entity<Rubric>(entity =>
        {
            entity.HasKey(e => e.RubricsId);

            entity.Property(e => e.RubricsId).HasColumnName("Rubrics_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
