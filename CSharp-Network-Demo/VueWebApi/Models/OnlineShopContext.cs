using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VueWebApi.Models;

public partial class OnlineShopContext : DbContext
{
    public OnlineShopContext()
    {
    }

    public OnlineShopContext(DbContextOptions<OnlineShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<GoodsType> GoodsTypes { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<UserOrder> UserOrders { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OnlineShop1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__tb_Custo__B611CB9D92E10A8D");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .HasColumnName("customerID");
            entity.Property(e => e.CostomerEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("costomerEmail");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(100)
                .HasColumnName("customerAddress");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .HasColumnName("customerName");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customerPhone");
            entity.Property(e => e.CustomerPostCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("customerPostCode");
            entity.Property(e => e.CustomerPwd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customerPWD");
            entity.Property(e => e.CustomerRegDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("customerRegDate");
        });

        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.GoodsId).HasName("PK__tmp_ms_x__110ED9D22081CEC9");

            entity.Property(e => e.GoodsId).HasColumnName("goodsID");
            entity.Property(e => e.GoodsDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("goodsDate");
            entity.Property(e => e.GoodsDescript).HasColumnName("goodsDescript");
            entity.Property(e => e.GoodsImage)
                .IsUnicode(false)
                .HasColumnName("goodsImage");
            entity.Property(e => e.GoodsName)
                .HasMaxLength(50)
                .HasColumnName("goodsName");
            entity.Property(e => e.GoodsTypeId).HasColumnName("goodsTypeID");
            entity.Property(e => e.GoodsUnitPrice)
                .HasColumnType("money")
                .HasColumnName("goodsUnitPrice");
            entity.Property(e => e.SellCount).HasColumnName("sellCount");
        });

        modelBuilder.Entity<GoodsType>(entity =>
        {
            entity.HasKey(e => e.GoodsTypeId).HasName("PK__tmp_ms_x__A8F2A2F0A51F5E2E");

            entity.ToTable("GoodsType");

            entity.Property(e => e.GoodsTypeId).HasColumnName("goodsTypeID");
            entity.Property(e => e.GoodsTypeName)
                .HasMaxLength(50)
                .HasColumnName("goodsTypeName");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK__tb_Manag__47E0147FBEEBE55F");

            entity.ToTable("Manager");

            entity.Property(e => e.ManagerId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("managerID");
            entity.Property(e => e.ManagerPwd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("managerPWD");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.GoodsId }).HasName("PK__tmp_ms_x__3919DEE0E4CDACFF");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.GoodsId).HasColumnName("goodsID");
            entity.Property(e => e.GoodsCount).HasColumnName("goodsCount");
        });

        modelBuilder.Entity<UserOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__tmp_ms_x__0809337D4475FC28");

            entity.ToTable("UserOrder");

            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .HasColumnName("customerID");
            entity.Property(e => e.OrderDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.OrderState)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("orderState");
            entity.Property(e => e.TotalMoney)
                .HasColumnType("money")
                .HasColumnName("totalMoney");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
