using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace REST_API_TO_DB.Models
{
    public partial class RESTAPI2DBContext : DbContext
    {
        public RESTAPI2DBContext(DbContextOptions<RESTAPI2DBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Projection> Projections { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.ID)
                      .HasName("PK_Schedule_ID");
            });
            modelBuilder.Entity<Projection>(entity =>
            {
                entity.HasKey(e => e.ID)
                      .HasName("PK_Projection_ID");
            });
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_UserInfo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

    //public class Projection
    //{
    //    public string Color { get; set; }
    //    public string Description { get; set; }
    //    public DateTime Start { get; set; }
    //    public int minutes { get; set; }
    //}

    //public class Schedule
    //{
    //    public int ContractTimeMinutes { get; set; }
    //    public DateTime Date { get; set; }
    //    public bool IsFullDayAbsence { get; set; }
    //    public string Name { get; set; }
    //    public string PersonId { get; set; }
    //    public List<Projection> Projection { get; set; }
    //}

    //public class ScheduleResult
    //{
    //    public List<Schedule> Schedules { get; set; }
    //}

    //public class Root
    //{
    //    public int Id { get; set; }
    //    public ScheduleResult ScheduleResult { get; set; }
    //}
}
