﻿// <auto-generated />

using System;
using Difi.Sjalvdeklaration.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181030103903_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        new { Id = new Guid("51f48375-7d96-422e-a129-4bc03d5abedd"), Code = "1111", CorporateIdentityNumber = "123456789", Name = "Narvesen" },
                        new { Id = new Guid("c7aa255b-1a09-4dcc-bc8d-061f44353aec"), Code = "2222", CorporateIdentityNumber = "987654321", Name = "Norwegian" },
                        new { Id = new Guid("e4f8d018-e745-4471-a3cd-80e5ddec071c"), Code = "3333", CorporateIdentityNumber = "1122334455", Name = "NSB" },
                        new { Id = new Guid("f9eafa03-f494-4794-a327-3bb959d268d8"), Code = "4444", CorporateIdentityNumber = "1122334455", Name = "Esso" },
                        new { Id = new Guid("9bf11062-4de1-4fde-b807-fdc9405d57c0"), Code = "5555", CorporateIdentityNumber = "1122334455", Name = "7 - eleven" },
                        new { Id = new Guid("2ddb0183-bb9a-4c6d-bd63-6bfac0afe045"), Code = "6666", CorporateIdentityNumber = "1122334455", Name = "Norske bank" }
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
                        new { Id = new Guid("c008576e-a5d7-4b68-83a1-072d9af27496"), CompanyItemId = new Guid("51f48375-7d96-422e-a129-4bc03d5abedd"), Email = "henrik.juhlin@funka.com", Name = "Henrik Juhlin", Phone = "070-601 75 46" },
                        new { Id = new Guid("bf1cae40-31d5-4be5-a19f-7088ac55312d"), CompanyItemId = new Guid("c7aa255b-1a09-4dcc-bc8d-061f44353aec"), Email = "henrik.juhlin@funka.com", Name = "Henrik Juhlin", Phone = "070-601 75 46" },
                        new { Id = new Guid("0448a490-87f3-48a4-b283-2bae744d50b3"), CompanyItemId = new Guid("e4f8d018-e745-4471-a3cd-80e5ddec071c"), Email = "henrik.juhlin@funka.com", Name = "Henrik Juhlin", Phone = "070-601 75 46" },
                        new { Id = new Guid("14398b07-0c6d-4945-88c7-0ce6eff71111"), CompanyItemId = new Guid("f9eafa03-f494-4794-a327-3bb959d268d8"), Email = "henrik.juhlin@funka.com", Name = "Henrik Juhlin", Phone = "070-601 75 46" },
                        new { Id = new Guid("36f61efa-04b1-4dcf-8574-18402fc1e68a"), CompanyItemId = new Guid("9bf11062-4de1-4fde-b807-fdc9405d57c0"), Email = "henrik.juhlin@funka.com", Name = "Henrik Juhlin", Phone = "070-601 75 46" },
                        new { Id = new Guid("95e64f0b-bab2-4b1e-8988-c9a91daf6165"), CompanyItemId = new Guid("2ddb0183-bb9a-4c6d-bd63-6bfac0afe045"), Email = "henrik.juhlin@funka.com", Name = "Henrik Juhlin", Phone = "070-601 75 46" }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.DeclarationItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyItemId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.Property<Guid>("UserItemId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyItemId");

                    b.HasIndex("UserItemId");

                    b.ToTable("DeclarationList");

                    b.HasData(
                        new { Id = new Guid("2d73f979-3f9f-4ebd-9a4c-f777fe15074f"), CompanyItemId = new Guid("51f48375-7d96-422e-a129-4bc03d5abedd"), CreatedDate = new DateTime(2018, 10, 20, 0, 0, 0, 0, DateTimeKind.Local), Name = "Automat for betaling på Oslo S", Status = 1, UserItemId = new Guid("54864875-bfa9-4435-919e-907f945c4634") },
                        new { Id = new Guid("42ffe6ce-3922-42e0-a962-9c93b912dfe3"), CompanyItemId = new Guid("c7aa255b-1a09-4dcc-bc8d-061f44353aec"), CreatedDate = new DateTime(2018, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), Name = "Billettautomat Gardemoen", Status = 0, UserItemId = new Guid("2c22c3e7-3e79-4e72-a967-130ffe7a3dda") },
                        new { Id = new Guid("cc3f99f1-665f-4a29-bded-7c82c26531d9"), CompanyItemId = new Guid("e4f8d018-e745-4471-a3cd-80e5ddec071c"), CreatedDate = new DateTime(2018, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), Name = "Billettautomat på Oslo S", Status = 3, UserItemId = new Guid("54864875-bfa9-4435-919e-907f945c4634") },
                        new { Id = new Guid("9443e26b-d738-4df7-96f8-9a753dbaeb7c"), CompanyItemId = new Guid("f9eafa03-f494-4794-a327-3bb959d268d8"), CreatedDate = new DateTime(2018, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), Name = "Betalingsautomat Trondheim", Status = 3, UserItemId = new Guid("2c22c3e7-3e79-4e72-a967-130ffe7a3dda") },
                        new { Id = new Guid("3f523e86-22c9-4190-8c01-f05dcb18078a"), CompanyItemId = new Guid("9bf11062-4de1-4fde-b807-fdc9405d57c0"), CreatedDate = new DateTime(2018, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), Name = "Automat Grensen", Status = 2, UserItemId = new Guid("54864875-bfa9-4435-919e-907f945c4634") },
                        new { Id = new Guid("367d7568-abaa-4ce9-a4f3-e829e8450c68"), CompanyItemId = new Guid("2ddb0183-bb9a-4c6d-bd63-6bfac0afe045"), CreatedDate = new DateTime(2018, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), Name = "Billettautomat Kristiansand", Status = 4, UserItemId = new Guid("2c22c3e7-3e79-4e72-a967-130ffe7a3dda") }
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
                        new { Id = new Guid("ed085d53-7077-428e-8280-5f7b7ee45533"), Name = "Admin" },
                        new { Id = new Guid("575b7e24-8b5f-4f1b-b797-064ad5d4b29f"), Name = "Saksbehandlare" },
                        new { Id = new Guid("e2b7e34a-43b1-4537-8887-7d4b938beb99"), Name = "Verksamhet" }
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
                        new { UserItemId = new Guid("4528be50-8862-47bd-8cef-554889d3ba98"), CompanyItemId = new Guid("51f48375-7d96-422e-a129-4bc03d5abedd") }
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
                        new { Id = new Guid("54864875-bfa9-4435-919e-907f945c4634"), IdPortenSub = "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=", Name = "Thea", SocialSecurityNumber = "12089400420" },
                        new { Id = new Guid("2c22c3e7-3e79-4e72-a967-130ffe7a3dda"), IdPortenSub = "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=", Name = "Martin", SocialSecurityNumber = "12089400269" },
                        new { Id = new Guid("4528be50-8862-47bd-8cef-554889d3ba98"), IdPortenSub = "8zrqvL9yMbkJAfU_53_WE1jbTFUehgxmf7MADGcv98g=", Name = "", SocialSecurityNumber = "12089400188" }
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
                        new { UserItemId = new Guid("54864875-bfa9-4435-919e-907f945c4634"), RoleItemId = new Guid("ed085d53-7077-428e-8280-5f7b7ee45533") },
                        new { UserItemId = new Guid("54864875-bfa9-4435-919e-907f945c4634"), RoleItemId = new Guid("575b7e24-8b5f-4f1b-b797-064ad5d4b29f") },
                        new { UserItemId = new Guid("2c22c3e7-3e79-4e72-a967-130ffe7a3dda"), RoleItemId = new Guid("575b7e24-8b5f-4f1b-b797-064ad5d4b29f") },
                        new { UserItemId = new Guid("4528be50-8862-47bd-8cef-554889d3ba98"), RoleItemId = new Guid("e2b7e34a-43b1-4537-8887-7d4b938beb99") }
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
