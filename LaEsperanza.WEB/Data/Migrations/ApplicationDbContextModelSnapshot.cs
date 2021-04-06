﻿// <auto-generated />
using System;
using LaEsperanza.WEB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LaEsperanza.WEB.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LaEsperanza.WEB.Models.Clasification", b =>
                {
                    b.Property<int>("ClasificationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemType")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("ClasificationId");

                    b.ToTable("Clasifications");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Document")
                        .HasMaxLength(20);

                    b.Property<int>("DocumentTypeId");

                    b.Property<string>("Email");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Phone")
                        .HasMaxLength(10);

                    b.HasKey("CustomerID");

                    b.HasIndex("DocumentTypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.DocumentType", b =>
                {
                    b.Property<int>("DocumentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeDocument")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("DocumentTypeId");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClasificationId");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Lote")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("SupplierId");

                    b.Property<DateTime>("Time");

                    b.Property<int>("UnitId");

                    b.Property<decimal>("UnitPrice");

                    b.Property<int>("UnitsInStock");

                    b.HasKey("ItemId");

                    b.HasIndex("ClasificationId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("UnitId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ItemId");

                    b.Property<DateTime>("OrderTime");

                    b.Property<int?>("PaymentId");

                    b.Property<decimal>("SubTotal");

                    b.Property<int>("SupplierId");

                    b.Property<decimal>("TotalValue");

                    b.Property<decimal>("Valueimp")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("comentario");

                    b.HasKey("OrderId");

                    b.HasIndex("ItemId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.OrderDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<int>("OrderId");

                    b.Property<int?>("ProductiD");

                    b.Property<float>("Quantity");

                    b.Property<decimal>("TotalValue");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("DetailId");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductiD");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Pway")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("PaymentId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.Product", b =>
                {
                    b.Property<int>("ProductiD")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<decimal>("PriceP");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Retiro")
                        .HasMaxLength(200);

                    b.Property<int?>("UnitId");

                    b.HasKey("ProductiD");

                    b.HasIndex("UnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.PurchaseDetail", b =>
                {
                    b.Property<int>("PurchaseDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<int>("PurchaseId");

                    b.Property<float>("Quantity");

                    b.Property<decimal>("TotalValue");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("PurchaseDetailId");

                    b.HasIndex("ItemId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseDetail");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID");

                    b.Property<int?>("ItemId");

                    b.Property<DateTime>("OrderTime");

                    b.Property<int>("PaymentId");

                    b.Property<decimal>("SubTotal");

                    b.Property<decimal>("TotalValue");

                    b.Property<decimal>("Valueimp")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("comentario");

                    b.HasKey("PurchaseId");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ItemId");

                    b.HasIndex("PaymentId");

                    b.ToTable("PurchaseOrder");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mail")
                        .IsRequired();

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("SupplierTypeId");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("SupplierId");

                    b.HasIndex("SupplierTypeId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.SupplierType", b =>
                {
                    b.Property<int>("SupplierTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("SupplierTypeId");

                    b.ToTable("SupplierType");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("UnitId");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.Customer", b =>
                {
                    b.HasOne("LaEsperanza.WEB.Models.DocumentType", "DocumentType")
                        .WithMany("Customers")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.Item", b =>
                {
                    b.HasOne("LaEsperanza.WEB.Models.Clasification", "Clasification")
                        .WithMany("Items")
                        .HasForeignKey("ClasificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LaEsperanza.WEB.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LaEsperanza.WEB.Models.Unit", "Unit")
                        .WithMany("Items")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.Order", b =>
                {
                    b.HasOne("LaEsperanza.WEB.Models.Item")
                        .WithMany("Orders")
                        .HasForeignKey("ItemId");

                    b.HasOne("LaEsperanza.WEB.Models.Payment")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentId");

                    b.HasOne("LaEsperanza.WEB.Models.Supplier", "Supplier")
                        .WithMany("Orders")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.OrderDetail", b =>
                {
                    b.HasOne("LaEsperanza.WEB.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LaEsperanza.WEB.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LaEsperanza.WEB.Models.Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductiD");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.Product", b =>
                {
                    b.HasOne("LaEsperanza.WEB.Models.Unit")
                        .WithMany("Products")
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.PurchaseDetail", b =>
                {
                    b.HasOne("LaEsperanza.WEB.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LaEsperanza.WEB.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.PurchaseOrder", b =>
                {
                    b.HasOne("LaEsperanza.WEB.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LaEsperanza.WEB.Models.Item")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("ItemId");

                    b.HasOne("LaEsperanza.WEB.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LaEsperanza.WEB.Models.Supplier", b =>
                {
                    b.HasOne("LaEsperanza.WEB.Models.SupplierType", "SupplierType")
                        .WithMany("Suppliers")
                        .HasForeignKey("SupplierTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
