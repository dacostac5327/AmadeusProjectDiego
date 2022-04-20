using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.Models
{
    public class AmadeusDbContext : DbContext
    {
        public AmadeusDbContext(DbContextOptions<AmadeusDbContext> options) : base(options)
        { 
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ARL> ARL { get; set; }
        public DbSet<EPS> EPS { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasData(new List<Department>() { new Department() {
                    Id=1,
                    Name = "IT"
                },
                new Department() {
                    Id=2,
                    Name = "Financial"
                },
                new Department() {
                    Id=3,
                    Name = "Human Resources"
                }
                }) ;
            });

            modelBuilder.Entity<ARL>(entity =>
            {
                entity.HasData(new List<ARL>() { new ARL() {
                    Id=1,
                    Name = "Sura"
                },
                new ARL() {
                    Id=2,
                    Name = "Positiva"
                },
                new ARL() {
                    Id=3,
                    Name = "Axa Colpatria"
                }
                });
            });

            modelBuilder.Entity<EPS>(entity =>
            {
                entity.HasData(new List<EPS>() { new EPS() {
                    Id=1,
                    Name = "Compensar"
                },
                new EPS() {
                    Id=2,
                    Name = "Salud Total"
                },
                new EPS() {
                    Id=3,
                    Name = "Sanitas"
                }
                });
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Department)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Department__01142BA1");

                entity.HasOne(d => d.ArlNavigation)
                   .WithMany(p => p.Employee)
                   .HasForeignKey(d => d.Arl)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK__Employee__Arl__01152BA1");

                entity.HasOne(d => d.EpsNavigation)
                   .WithMany(p => p.Employee)
                   .HasForeignKey(d => d.Eps)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK__Employee__Eps__01162BA1");
            });


        }
    }
}
