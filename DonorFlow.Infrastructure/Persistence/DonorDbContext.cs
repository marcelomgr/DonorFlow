using DonorFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DonorFlow.Infrastructure.Persistence
{
    public class DonorDbContext : DbContext
    {
        public DonorDbContext(DbContextOptions<DonorDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Donor> Donors { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);
                e.HasIndex(u => u.Email).IsUnique();

                // Propriedades herdadas de User
                e.Property(u => u.CPF).IsRequired().HasMaxLength(11);
                e.Property(u => u.Password).IsRequired();
                e.Property(u => u.Status).IsRequired();
                e.Property(u => u.Role).IsRequired();
                e.Property(u => u.FullName).IsRequired().HasMaxLength(100);
                e.Property(u => u.Email).IsRequired().HasMaxLength(100);
                e.Property(u => u.BirthDate).IsRequired();
                e.Property(u => u.Gender).IsRequired();

                // ValueObject
                e.OwnsOne(u => u.Location, loc =>
                {
                    loc.Property(l => l.Cep).HasColumnName("Cep");
                    loc.Property(l => l.Address).HasColumnName("Address");
                    loc.Property(l => l.District).HasColumnName("District");
                    loc.Property(l => l.City).HasColumnName("City");
                    loc.Property(l => l.State).HasColumnName("State");
                });
            });

            builder.Entity<Donor>(e =>
            {
                e.HasKey(d => d.Id);
                e.HasIndex(d => d.Email).IsUnique();

                e.Property(d => d.FullName).IsRequired().HasMaxLength(100);
                e.Property(d => d.Email).IsRequired().HasMaxLength(100);
                e.Property(d => d.BirthDate).IsRequired();
                e.Property(d => d.Gender).IsRequired();

                e.Property(d => d.Weight).IsRequired();
                e.Property(d => d.BloodType).IsRequired();
                e.Property(d => d.RhFactor).IsRequired();

                // ValueObject
                e.OwnsOne(d => d.Location, loc =>
                {
                    loc.Property(l => l.Cep).HasColumnName("Cep");
                    loc.Property(l => l.Address).HasColumnName("Address");
                    loc.Property(l => l.District).HasColumnName("District");
                    loc.Property(l => l.City).HasColumnName("City");
                    loc.Property(l => l.State).HasColumnName("State");
                });
            });

            base.OnModelCreating(builder);
        }
    }
}
