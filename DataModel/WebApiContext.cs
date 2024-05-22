using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MeetWebApi.DataModel;

public partial class WebApiContext : DbContext
{
    public WebApiContext()
    {
    }

    public WebApiContext(DbContextOptions<WebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountInfo> AccountInfos { get; set; }

    public virtual DbSet<Meet> Meets { get; set; }

    public virtual DbSet<MeetAddress> MeetAddresses { get; set; }

    public virtual DbSet<MeetRoomAddress> MeetRoomAddresses { get; set; }

    public virtual DbSet<MeetingUserRelationship> MeetingUserRelationships { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Localhost;Database=Meet;uid=sa;Password=123456;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountInfo>(entity =>
        {
            entity.HasKey(e => e.AccountId);

            entity.ToTable("AccountInfo");
        });

        modelBuilder.Entity<Meet>(entity =>
        {
            entity.HasKey(e => e.MeetId).HasName("PK__Meet__0ED7DF3BAA5A0274");

            entity.ToTable("Meet");

            entity.Property(e => e.MeetId).HasColumnName("meetId");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.MeetCreateTime)
                .HasColumnType("datetime")
                .HasColumnName("meetCreateTime");
            entity.Property(e => e.MeetEndTime)
                .HasColumnType("datetime")
                .HasColumnName("meetEndTime");
            entity.Property(e => e.MeetMessage)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("meetMessage");
            entity.Property(e => e.MeetStartTime)
                .HasColumnType("datetime")
                .HasColumnName("meetStartTime");
            entity.Property(e => e.MeetTitle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("meetTitle");
            entity.Property(e => e.MeetingRoom)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("meetingRoom");
            entity.Property(e => e.Regular).HasColumnName("regular");
        });

        modelBuilder.Entity<MeetAddress>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MeetAddress");

            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.MeetAddressName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UpdataTime)
                .HasColumnType("datetime")
                .HasColumnName("updataTime");
        });

        modelBuilder.Entity<MeetRoomAddress>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MeetRoomAddress");

            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.RoomAddress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("roomAddress");
            entity.Property(e => e.RoomId).HasColumnName("roomId");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("updateTime");
        });

        modelBuilder.Entity<MeetingUserRelationship>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MeetingUserRelationship _pk");

            entity.ToTable("MeetingUserRelationship ");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
