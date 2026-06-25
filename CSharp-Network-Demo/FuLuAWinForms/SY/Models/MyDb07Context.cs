using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FuLuAWinForms.SY.Models;

public partial class MyDb07Context : DbContext
{
    public MyDb07Context()
    {
    }

    public MyDb07Context(DbContextOptions<MyDb07Context> options)
        : base(options)
    {
    }

    public virtual DbSet<SY07Student> SY07Student { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;AttachDbFileName=D:\\ls\\V4B2Source\\FuLuAWinForms\\SY\\MyDb07.mdf");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SY07Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07A54139F5");

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
