
using Microsoft.EntityFrameworkCore;
using Vezzeta.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Specialization> Specializations { get; set; }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<DiscountCode> DiscountCodes { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Request> Requests { get; set; } // Updated DbSet for Request entity

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("your_connection_string"); // Replace with your actual connection string
}