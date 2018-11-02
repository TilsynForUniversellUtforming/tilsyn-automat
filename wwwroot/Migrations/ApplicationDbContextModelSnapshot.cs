﻿// <auto-generated />

using System;
using Difi.Sjalvdeklaration.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.CompanyItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CorporateIdentityNumber");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CompanyList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ContactPersonItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyItemId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("CompanyItemId");

                    b.ToTable("ContactPersonList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.DeclarationItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyItemId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DeadLineDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("SentInDate");

                    b.Property<int>("Status");

                    b.Property<Guid>("UserItemId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyItemId");

                    b.HasIndex("UserItemId");

                    b.ToTable("DeclarationList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.RoleItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RoleList");

                    b.HasData(
                        new { Id = new Guid("bc0d58a4-8872-4ef9-87fd-392ff9a23164"), Name = "Admin" },
                        new { Id = new Guid("4e4e0a39-54ed-4a39-88b7-b0b006fd109c"), Name = "Saksbehandlare" },
                        new { Id = new Guid("12ab8a0e-8d47-48cc-bcc8-7d8c5e50eceb"), Name = "Verksamhet" }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.UserCompany", b =>
                {
                    b.Property<Guid>("UserItemId");

                    b.Property<Guid>("CompanyItemId");

                    b.HasKey("UserItemId", "CompanyItemId");

                    b.HasIndex("CompanyItemId");

                    b.ToTable("UserCompanyList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.UserItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("IdPortenSub");

                    b.Property<DateTime>("LastOnline");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("SocialSecurityNumber");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("UserList");

                    b.HasData(
                        new { Id = new Guid("08fff097-7a05-452c-aa18-e93e8bd9516c"), Created = new DateTime(2018, 11, 1, 10, 7, 7, 450, DateTimeKind.Local), Email = "martin@difi.no", IdPortenSub = "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=", LastOnline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Martin Swartling", Phone = "912345678", SocialSecurityNumber = "12089400420", Title = "Avdelingssjef" },
                        new { Id = new Guid("d99e0f7f-9a5a-42c2-bd45-66a9f7cf09dd"), Created = new DateTime(2018, 11, 1, 10, 7, 7, 451, DateTimeKind.Local), Email = "thea@difi.no", IdPortenSub = "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=", LastOnline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Thea Sneve", Phone = "712345678", SocialSecurityNumber = "12089400269", Title = "Handläggare" }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.UserRole", b =>
                {
                    b.Property<Guid>("UserItemId");

                    b.Property<Guid>("RoleItemId");

                    b.HasKey("UserItemId", "RoleItemId");

                    b.HasIndex("RoleItemId");

                    b.ToTable("UserRoleList");

                    b.HasData(
                        new { UserItemId = new Guid("08fff097-7a05-452c-aa18-e93e8bd9516c"), RoleItemId = new Guid("bc0d58a4-8872-4ef9-87fd-392ff9a23164") },
                        new { UserItemId = new Guid("08fff097-7a05-452c-aa18-e93e8bd9516c"), RoleItemId = new Guid("4e4e0a39-54ed-4a39-88b7-b0b006fd109c") },
                        new { UserItemId = new Guid("d99e0f7f-9a5a-42c2-bd45-66a9f7cf09dd"), RoleItemId = new Guid("4e4e0a39-54ed-4a39-88b7-b0b006fd109c") }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ContactPersonItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.CompanyItem")
                        .WithMany("ContactPersonList")
                        .HasForeignKey("CompanyItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.DeclarationItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.CompanyItem", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.UserItem", "User")
                        .WithMany()
                        .HasForeignKey("UserItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.UserCompany", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.CompanyItem", "CompanyItem")
                        .WithMany("UserList")
                        .HasForeignKey("CompanyItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.UserItem", "UserItem")
                        .WithMany("CompanyList")
                        .HasForeignKey("UserItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.UserRole", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.RoleItem", "RoleItem")
                        .WithMany("UserList")
                        .HasForeignKey("RoleItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.UserItem", "UserItem")
                        .WithMany("RoleList")
                        .HasForeignKey("UserItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
