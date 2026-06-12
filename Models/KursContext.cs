using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KursMVVM.Models;

public partial class KursContext : DbContext
{
    public KursContext()
    {
        Database.EnsureCreated();
    }

    public KursContext(DbContextOptions<KursContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<FactOrder> FactOrders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=kurs.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient);

            entity.ToTable("Client");

            entity.Property(e => e.IdClient).HasColumnName("id_client");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.IdDelivery);

            entity.ToTable("Delivery");

            entity.Property(e => e.IdDelivery).HasColumnName("id_delivery");
        });

        modelBuilder.Entity<FactOrder>(entity =>
        {
            entity.HasKey(e => e.IdFact);

            entity.ToTable("FactOrder");

            entity.Property(e => e.IdFact)
                .ValueGeneratedNever()
                .HasColumnName("id_fact");
            entity.Property(e => e.IdDelivery).HasColumnName("id_delivery");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");

            entity.HasOne(d => d.IdDeliveryNavigation).WithMany(p => p.FactOrders)
                .HasForeignKey(d => d.IdDelivery)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.FactOrders)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder);

            entity.ToTable("Order");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct);

            entity.ToTable("Product");

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
