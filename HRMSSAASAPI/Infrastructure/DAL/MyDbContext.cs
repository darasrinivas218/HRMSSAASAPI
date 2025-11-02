using HRMSSAASAPI.Application.DTOs;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace HRMSSAASAPI.Infrastructure.DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<TimesheetMaster> TimesheetMaster { get; set; }
        public DbSet<TimesheetDetail> TimesheetDetails { get; set; }
        public DbSet<WeeklyUpdate> WeeklyUpdates { get; set; }
        public DbSet<ImmigrationDetail> ImmigrationDetails { get; set; }
        public DbSet<PasswordResetRequest> PasswordResetRequests { get; set; }
        public DbSet<Payroll> Payroll { get; set; }
        public DbSet<EmployeeBankDetail> EmployeeBankDetails { get; set; }
        public DbSet<ClientBankDetail> ClientBankDetails { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<InvoiceSummaryDto> InvoiceSummaries { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddress { get; set; }
        public DbSet<ClientAddress> ClientAddress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // DTO is keyless since it's not a table
            modelBuilder.Entity<InvoiceSummaryDto>().HasNoKey();
        }
    }

}

    




