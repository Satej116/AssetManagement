using AssetManagement.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Contexts
{
    public class AssetManagementDbContext : DbContext
    {
        public AssetManagementDbContext(DbContextOptions<AssetManagementDbContext> options)
            : base(options)
        {
        }

        // Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetCategory> AssetCategories { get; set; }
        public DbSet<AssetStatusMaster> AssetStatusMasters { get; set; }
        public DbSet<AssetAllocation> AssetAllocations { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<ServiceStatusMaster> ServiceStatusMasters { get; set; }
        public DbSet<AuditRequest> AuditRequests { get; set; }
        public DbSet<AuditStatusMaster> AuditStatusMasters { get; set; }
        public DbSet<AdminLog> AdminLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key for AssetAllocation
            modelBuilder.Entity<AssetAllocation>()
                .HasKey(a => new { a.AssetId, a.EmployeeId });

            // User and Employee (1:1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<User>(u => u.EmployeeId);

            // User and Role (Many-to-1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee and Role (Many-to-1)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId);

            // Asset and Category (Many-to-1)
            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Assets)
                .HasForeignKey(a => a.CategoryId);

            // Asset and Status (Many-to-1)
            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Status)
                .WithMany(s => s.Assets)
                .HasForeignKey(a => a.StatusId);

            // ServiceRequest and Asset (Many-to-1)
            modelBuilder.Entity<ServiceRequest>()
                .HasOne(sr => sr.Asset)
                .WithMany(a => a.ServiceRequests)
                .HasForeignKey(sr => sr.AssetId);

            // ServiceRequest and Employee (Many-to-1)
            modelBuilder.Entity<ServiceRequest>()
                .HasOne(sr => sr.Employee)
                .WithMany(e => e.ServiceRequests)
                .HasForeignKey(sr => sr.EmployeeId);

            // ServiceRequest and Status (Many-to-1)
            modelBuilder.Entity<ServiceRequest>()
                .HasOne(sr => sr.Status)
                .WithMany(ss => ss.ServiceRequests)
                .HasForeignKey(sr => sr.StatusId);

            // AuditRequest and Asset (Many-to-1)
            modelBuilder.Entity<AuditRequest>()
                .HasOne(ar => ar.Asset)
                .WithMany(a => a.AuditRequests)
                .HasForeignKey(ar => ar.AssetId);

            // AuditRequest and Employee (Many-to-1)
            modelBuilder.Entity<AuditRequest>()
                .HasOne(ar => ar.Employee)
                .WithMany(e => e.AuditRequests)
                .HasForeignKey(ar => ar.EmployeeId);

            // AuditRequest and Status (Many-to-1)
            modelBuilder.Entity<AuditRequest>()
                .HasOne(ar => ar.Status)
                .WithMany(s => s.AuditRequests)
                .HasForeignKey(ar => ar.StatusId);

            // AdminLog and Employee (Many-to-1)
            modelBuilder.Entity<AdminLog>()
                .HasOne(al => al.Admin)
                .WithMany(e => e.AdminLogs)
                .HasForeignKey(al => al.AdminId);
        }
    }
}
