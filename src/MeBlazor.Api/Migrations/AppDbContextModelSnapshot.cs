﻿// <auto-generated />
using MeBlazor.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeBlazor.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("MeBlazor.Shared.Tasks.TaskItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("INTEGER")
                        .HasColumnName("iscomplete");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("taskname");

                    b.HasKey("Id");

                    b.ToTable("TaskItems");
                });
#pragma warning restore 612, 618
        }
    }
}
