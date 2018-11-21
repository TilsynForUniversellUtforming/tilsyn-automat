﻿// <auto-generated />
using System;
using Difi.Sjalvdeklaration.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.LogDb
{
    [DbContext(typeof(LogDbContext))]
    partial class LogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.LogItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CallParameter1");

                    b.Property<string>("CallParameter2");

                    b.Property<string>("Class");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Function");

                    b.Property<string>("ResultException");

                    b.Property<Guid>("ResultId");

                    b.Property<string>("ResultString");

                    b.Property<bool>("ResultSucceeded");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("LogList");
                });
#pragma warning restore 612, 618
        }
    }
}
