﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rika_OrderProvider.Infrastructure.Data.Contexts;

#nullable disable

namespace Rika_OrderProvider.Infrastructure.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    partial class OrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Rika_OrderProvider.Infrastructure.Data.Entities.OrderAddressEntity", b =>
                {
                    b.Property<string>("OrderAddressId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderAddressId");

                    b.ToTable("OrderAddresses");
                });

            modelBuilder.Entity("Rika_OrderProvider.Infrastructure.Data.Entities.OrderCustomerEntity", b =>
                {
                    b.Property<string>("OrderCustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderCustomerId");

                    b.ToTable("OrderCustomers");
                });

            modelBuilder.Entity("Rika_OrderProvider.Infrastructure.Data.Entities.OrderEntity", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("OrderAddressId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrderCustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipmentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex("OrderAddressId");

                    b.HasIndex("OrderCustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Rika_OrderProvider.Infrastructure.Data.Entities.OrderProductEntity", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("ArticleNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId", "ArticleNumber");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Rika_OrderProvider.Infrastructure.Data.Entities.OrderEntity", b =>
                {
                    b.HasOne("Rika_OrderProvider.Infrastructure.Data.Entities.OrderAddressEntity", "OrderAddress")
                        .WithMany("Orders")
                        .HasForeignKey("OrderAddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Rika_OrderProvider.Infrastructure.Data.Entities.OrderCustomerEntity", "OrderCustomer")
                        .WithMany("Orders")
                        .HasForeignKey("OrderCustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OrderAddress");

                    b.Navigation("OrderCustomer");
                });

            modelBuilder.Entity("Rika_OrderProvider.Infrastructure.Data.Entities.OrderProductEntity", b =>
                {
                    b.HasOne("Rika_OrderProvider.Infrastructure.Data.Entities.OrderEntity", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Rika_OrderProvider.Infrastructure.Data.Entities.OrderAddressEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Rika_OrderProvider.Infrastructure.Data.Entities.OrderCustomerEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Rika_OrderProvider.Infrastructure.Data.Entities.OrderEntity", b =>
                {
                    b.Navigation("OrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
