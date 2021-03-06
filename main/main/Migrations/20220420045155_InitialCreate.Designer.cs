// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shared.Models;

#nullable disable

namespace main.Migrations
{
    [DbContext(typeof(AmadeusDbContext))]
    [Migration("20220420045155_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("shared.Models.ARL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ARL");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sura"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Positiva"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Axa Colpatria"
                        });
                });

            modelBuilder.Entity("shared.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "IT"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Financial"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Human Resources"
                        });
                });

            modelBuilder.Entity("shared.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Arl")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<int>("Eps")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Arl");

                    b.HasIndex("Department");

                    b.HasIndex("Eps");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("shared.Models.EPS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EPS");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Compensar"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Salud Total"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sanitas"
                        });
                });

            modelBuilder.Entity("shared.Models.Employee", b =>
                {
                    b.HasOne("shared.Models.ARL", "ArlNavigation")
                        .WithMany("Employee")
                        .HasForeignKey("Arl")
                        .IsRequired()
                        .HasConstraintName("FK__Employee__Arl__01152BA1");

                    b.HasOne("shared.Models.Department", "DepartmentNavigation")
                        .WithMany("Employee")
                        .HasForeignKey("Department")
                        .IsRequired()
                        .HasConstraintName("FK__Employee__Department__01142BA1");

                    b.HasOne("shared.Models.EPS", "EpsNavigation")
                        .WithMany("Employee")
                        .HasForeignKey("Eps")
                        .IsRequired()
                        .HasConstraintName("FK__Employee__Eps__01162BA1");

                    b.Navigation("ArlNavigation");

                    b.Navigation("DepartmentNavigation");

                    b.Navigation("EpsNavigation");
                });

            modelBuilder.Entity("shared.Models.ARL", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("shared.Models.Department", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("shared.Models.EPS", b =>
                {
                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
