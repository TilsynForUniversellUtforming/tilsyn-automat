﻿// <auto-generated />
using System;
using Difi.Sjalvdeklaration.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Difi.Sjalvdeklaration.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
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

                    b.HasData(
                        new { Id = new Guid("626d1226-fdc4-4b01-a6c6-bca01828f0fa"), Code = "1111", CorporateIdentityNumber = "123456789", Name = "Narvesen" },
                        new { Id = new Guid("4f751531-da1d-4b97-8459-4559e73a7b9b"), Code = "2222", CorporateIdentityNumber = "987654321", Name = "Norwegian" },
                        new { Id = new Guid("1a4e0466-af1f-4053-a202-32f82316d565"), Code = "3333", CorporateIdentityNumber = "1122334455", Name = "NSB" },
                        new { Id = new Guid("087a3650-7def-4e2d-bee6-3551ea407e38"), Code = "4444", CorporateIdentityNumber = "1122334455", Name = "Esso" },
                        new { Id = new Guid("1d3f6dce-f67c-4c02-8b66-f26756efddb8"), Code = "5555", CorporateIdentityNumber = "1122334455", Name = "7 - eleven" },
                        new { Id = new Guid("8f41d94e-98aa-44ea-bd1c-54540dcbf395"), Code = "6666", CorporateIdentityNumber = "1122334455", Name = "Norske bank" }
                    );
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

                    b.HasData(
                        new { Id = new Guid("661443bc-0c92-4148-b8c1-d383ac179fbb"), CompanyItemId = new Guid("626d1226-fdc4-4b01-a6c6-bca01828f0fa"), Email = "henrik.juhlin@funka.com", Name = "Henrik Juhlin", Phone = "070-601 75 46" },
                        new { Id = new Guid("9dd2e076-605f-46f0-9315-d5721f5c17da"), CompanyItemId = new Guid("4f751531-da1d-4b97-8459-4559e73a7b9b"), Email = "henrik.juhlin@funka.com", Name = "Henrik Juhlin", Phone = "070-601 75 46" },
                        new { Id = new Guid("0915cd0f-b4d5-4d0f-bc70-9c4897540619"), CompanyItemId = new Guid("1a4e0466-af1f-4053-a202-32f82316d565"), Email = "henrik.juhlin@funka.com", Name = "Henrik Juhlin", Phone = "070-601 75 46" },
                        new { Id = new Guid("1672623b-34fa-40ae-86a3-ea870a36c3cd"), CompanyItemId = new Guid("087a3650-7def-4e2d-bee6-3551ea407e38"), Email = "henrik.juhlin@funka.com", Name = "Henrik Juhlin", Phone = "070-601 75 46" },
                        new { Id = new Guid("c3af421a-9f6b-4362-bd14-b66659428182"), CompanyItemId = new Guid("1d3f6dce-f67c-4c02-8b66-f26756efddb8"), Email = "henrik.juhlin@funka.com", Name = "Henrik Juhlin", Phone = "070-601 75 46" },
                        new { Id = new Guid("0cc68b20-a7b8-4bcd-a743-8b1a79fdd6ab"), CompanyItemId = new Guid("8f41d94e-98aa-44ea-bd1c-54540dcbf395"), Email = "henrik.juhlin@funka.com", Name = "Henrik Juhlin", Phone = "070-601 75 46" }
                    );
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

                    b.HasData(
                        new { Id = new Guid("3a24067c-639e-4868-a03b-8feee401ed2e"), CompanyItemId = new Guid("626d1226-fdc4-4b01-a6c6-bca01828f0fa"), CreatedDate = new DateTime(2018, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), DeadLineDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Automat for betaling på Oslo S", SentInDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 1, UserItemId = new Guid("8e469237-fe4e-4670-b137-e4c831868da4") },
                        new { Id = new Guid("961ac263-6fa8-4910-ab61-5280867e5653"), CompanyItemId = new Guid("4f751531-da1d-4b97-8459-4559e73a7b9b"), CreatedDate = new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), DeadLineDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Billettautomat Gardemoen", SentInDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 0, UserItemId = new Guid("44f1ab9a-029f-499a-9baf-00776a6bcb44") },
                        new { Id = new Guid("ba5d7737-9eb4-4f94-bf9d-cb4aec1fe60c"), CompanyItemId = new Guid("1a4e0466-af1f-4053-a202-32f82316d565"), CreatedDate = new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), DeadLineDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Billettautomat på Oslo S", SentInDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 3, UserItemId = new Guid("8e469237-fe4e-4670-b137-e4c831868da4") },
                        new { Id = new Guid("e4227f36-6925-4994-b761-a5c1d1cccaa3"), CompanyItemId = new Guid("087a3650-7def-4e2d-bee6-3551ea407e38"), CreatedDate = new DateTime(2018, 10, 28, 0, 0, 0, 0, DateTimeKind.Local), DeadLineDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Betalingsautomat Trondheim", SentInDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 3, UserItemId = new Guid("44f1ab9a-029f-499a-9baf-00776a6bcb44") },
                        new { Id = new Guid("7eb9a780-b2ec-4271-92d9-759c63eedd12"), CompanyItemId = new Guid("1d3f6dce-f67c-4c02-8b66-f26756efddb8"), CreatedDate = new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), DeadLineDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Automat Grensen", SentInDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 2, UserItemId = new Guid("8e469237-fe4e-4670-b137-e4c831868da4") },
                        new { Id = new Guid("779167eb-8b92-46ac-9b0f-0f4141165c1c"), CompanyItemId = new Guid("8f41d94e-98aa-44ea-bd1c-54540dcbf395"), CreatedDate = new DateTime(2018, 10, 28, 0, 0, 0, 0, DateTimeKind.Local), DeadLineDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Billettautomat Kristiansand", SentInDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 4, UserItemId = new Guid("44f1ab9a-029f-499a-9baf-00776a6bcb44") }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.RoleItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RoleList");

                    b.HasData(
                        new { Id = new Guid("175b54ba-c29e-46ce-874d-768ba96c0d8d"), Name = "Admin" },
                        new { Id = new Guid("78b6ea9b-f87c-4966-b636-01d648681462"), Name = "Saksbehandlare" },
                        new { Id = new Guid("de09be5a-acd2-4a7f-9e04-af4ca266ca64"), Name = "Verksamhet" }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.UserCompany", b =>
                {
                    b.Property<Guid>("UserItemId");

                    b.Property<Guid>("CompanyItemId");

                    b.HasKey("UserItemId", "CompanyItemId");

                    b.HasIndex("CompanyItemId");

                    b.ToTable("UserCompanyList");

                    b.HasData(
                        new { UserItemId = new Guid("2f5c3c5f-9869-4ef9-a992-4ac8c2d1d751"), CompanyItemId = new Guid("626d1226-fdc4-4b01-a6c6-bca01828f0fa") }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.UserItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("IdPortenSub");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("SocialSecurityNumber");

                    b.HasKey("Id");

                    b.ToTable("UserList");

                    b.HasData(
                        new { Id = new Guid("8e469237-fe4e-4670-b137-e4c831868da4"), Email = "thea@difi.no", IdPortenSub = "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=", Name = "Thea", Phone = "712345678", SocialSecurityNumber = "12089400420" },
                        new { Id = new Guid("44f1ab9a-029f-499a-9baf-00776a6bcb44"), Email = "martin@difi.no", IdPortenSub = "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=", Name = "Martin", Phone = "912345678", SocialSecurityNumber = "12089400269" },
                        new { Id = new Guid("2f5c3c5f-9869-4ef9-a992-4ac8c2d1d751"), IdPortenSub = "8zrqvL9yMbkJAfU_53_WE1jbTFUehgxmf7MADGcv98g=", Name = "", SocialSecurityNumber = "12089400188" }
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
                        new { UserItemId = new Guid("8e469237-fe4e-4670-b137-e4c831868da4"), RoleItemId = new Guid("175b54ba-c29e-46ce-874d-768ba96c0d8d") },
                        new { UserItemId = new Guid("8e469237-fe4e-4670-b137-e4c831868da4"), RoleItemId = new Guid("78b6ea9b-f87c-4966-b636-01d648681462") },
                        new { UserItemId = new Guid("44f1ab9a-029f-499a-9baf-00776a6bcb44"), RoleItemId = new Guid("78b6ea9b-f87c-4966-b636-01d648681462") },
                        new { UserItemId = new Guid("2f5c3c5f-9869-4ef9-a992-4ac8c2d1d751"), RoleItemId = new Guid("de09be5a-acd2-4a7f-9e04-af4ca266ca64") }
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
