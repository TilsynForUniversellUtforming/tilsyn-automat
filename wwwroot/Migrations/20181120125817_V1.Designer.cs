﻿// <auto-generated />
using System;
using Difi.Sjalvdeklaration.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181120125817_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Company.CompanyItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessAddressCity");

                    b.Property<string>("BusinessAddressStreet");

                    b.Property<string>("BusinessAddressZip");

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("CorporateIdentityNumber")
                        .IsRequired();

                    b.Property<string>("CustomAddressCity");

                    b.Property<string>("CustomAddressStreet");

                    b.Property<string>("CustomAddressZip");

                    b.Property<string>("CustomName");

                    b.Property<string>("ExternalId");

                    b.Property<string>("IndustryGroupAggregated");

                    b.Property<string>("IndustryGroupCode");

                    b.Property<string>("IndustryGroupDescription");

                    b.Property<string>("InstitutionalSectorCode");

                    b.Property<string>("InstitutionalSectorDescription");

                    b.Property<string>("LocationAddressCity");

                    b.Property<string>("LocationAddressStreet");

                    b.Property<string>("LocationAddressZip");

                    b.Property<string>("MailingAddressCity");

                    b.Property<string>("MailingAddressStreet");

                    b.Property<string>("MailingAddressZip");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("OwenerCorporateIdentityNumber");

                    b.HasKey("Id");

                    b.ToTable("CompanyList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Company.ContactPersonItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyItemId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("PhoneCountryCode");

                    b.HasKey("Id");

                    b.HasIndex("CompanyItemId");

                    b.ToTable("ContactPersonList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data.AnswerData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AnswerItemId");

                    b.Property<bool>("Bool");

                    b.Property<Guid?>("ImageId");

                    b.Property<int>("Int");

                    b.Property<int>("ResultId");

                    b.Property<Guid>("RuleDataId");

                    b.Property<string>("String");

                    b.Property<int>("TypeOfAnswerId");

                    b.HasKey("Id");

                    b.HasIndex("AnswerItemId");

                    b.HasIndex("ImageId");

                    b.HasIndex("ResultId");

                    b.HasIndex("RuleDataId");

                    b.HasIndex("TypeOfAnswerId");

                    b.ToTable("AnswerData");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data.OutcomeData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DeclarationTestItemId");

                    b.Property<Guid>("IndicatorItemId");

                    b.Property<Guid>("RequirementItemId");

                    b.Property<int>("ResultId");

                    b.Property<string>("ResultText");

                    b.HasKey("Id");

                    b.HasIndex("DeclarationTestItemId");

                    b.HasIndex("IndicatorItemId");

                    b.HasIndex("RequirementItemId");

                    b.HasIndex("ResultId");

                    b.ToTable("OutcomeData");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data.RuleData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("OutcomeDataId");

                    b.Property<int>("ResultId");

                    b.Property<Guid>("RuleItemId");

                    b.HasKey("Id");

                    b.HasIndex("OutcomeDataId");

                    b.HasIndex("ResultId");

                    b.HasIndex("RuleItemId");

                    b.ToTable("RuleData");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyItemId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DeadlineDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("SentInDate");

                    b.Property<int>("Status");

                    b.Property<Guid>("UserItemId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyItemId");

                    b.HasIndex("UserItemId");

                    b.ToTable("DeclarationList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationTestItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CaseNumber");

                    b.Property<Guid>("DeclarationItemId");

                    b.Property<string>("DescriptionInText");

                    b.Property<int?>("FinishedStatusId");

                    b.Property<Guid?>("Image1Id");

                    b.Property<Guid?>("Image2Id");

                    b.Property<int?>("SupplierAndVersionId");

                    b.Property<string>("SupplierAndVersionOther");

                    b.Property<int?>("TypeOfMachineId");

                    b.Property<int?>("TypeOfTestId");

                    b.HasKey("Id");

                    b.HasIndex("DeclarationItemId")
                        .IsUnique();

                    b.HasIndex("FinishedStatusId");

                    b.HasIndex("Image1Id");

                    b.HasIndex("Image2Id");

                    b.HasIndex("SupplierAndVersionId");

                    b.HasIndex("TypeOfMachineId");

                    b.HasIndex("TypeOfTestId");

                    b.ToTable("DeclarationTestItem");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.AnswerItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Bool");

                    b.Property<int>("MaxInt");

                    b.Property<int>("MinInt");

                    b.Property<int>("Order");

                    b.Property<string>("Question");

                    b.Property<Guid>("RuleItemId");

                    b.Property<int>("TypeOfAnswerId");

                    b.Property<Guid>("ViewIfOtherFaildId");

                    b.Property<bool>("ViewIfOtherFailed");

                    b.HasKey("Id");

                    b.HasIndex("RuleItemId");

                    b.HasIndex("TypeOfAnswerId");

                    b.ToTable("AnswerList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.DeclarationTestGroup", b =>
                {
                    b.Property<Guid>("TestGroupItemId");

                    b.Property<Guid>("DeclarationItemId");

                    b.Property<int>("Order");

                    b.HasKey("TestGroupItemId", "DeclarationItemId");

                    b.HasIndex("DeclarationItemId");

                    b.ToTable("DeclarationTestGroupList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.IndicatorItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastChanged");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.ToTable("IndicatorList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.IndicatorTestGroup", b =>
                {
                    b.Property<Guid>("TestGroupItemId");

                    b.Property<Guid>("IndicatorItemId");

                    b.HasKey("TestGroupItemId", "IndicatorItemId");

                    b.HasIndex("IndicatorItemId");

                    b.ToTable("IndicatorTestGroupList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.IndicatorUserPrerequisite", b =>
                {
                    b.Property<Guid>("IndicatorItemId");

                    b.Property<int>("ValueListUserPrerequisiteId");

                    b.HasKey("IndicatorItemId", "ValueListUserPrerequisiteId");

                    b.HasIndex("ValueListUserPrerequisiteId");

                    b.ToTable("IndicatorUserPrerequisite");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.RequirementItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid>("IndicatorItemId");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.HasIndex("IndicatorItemId");

                    b.ToTable("RequirementList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.RequirementUserPrerequisite", b =>
                {
                    b.Property<Guid>("RequirementItemId");

                    b.Property<int>("ValueListUserPrerequisiteId");

                    b.HasKey("RequirementItemId", "ValueListUserPrerequisiteId");

                    b.HasIndex("ValueListUserPrerequisiteId");

                    b.ToTable("RequirementUserPrerequisiteList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.RuleItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ChapterItemId");

                    b.Property<string>("HelpText");

                    b.Property<string>("Illustration");

                    b.Property<Guid?>("IndicatorItemId");

                    b.Property<int>("Order");

                    b.Property<Guid>("RequirementItemId");

                    b.Property<Guid>("StandardItemId");

                    b.Property<string>("ToolsNeed");

                    b.HasKey("Id");

                    b.HasIndex("ChapterItemId");

                    b.HasIndex("IndicatorItemId");

                    b.HasIndex("RequirementItemId");

                    b.HasIndex("StandardItemId");

                    b.ToTable("RuleList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Standard.ChapterItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChapterHeading");

                    b.Property<string>("ChapterNumber");

                    b.Property<Guid>("StandardItemId");

                    b.HasKey("Id");

                    b.HasIndex("StandardItemId");

                    b.ToTable("ChapterList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Standard.StandardItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Standard");

                    b.HasKey("Id");

                    b.ToTable("StandardList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.TestGroupItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TestGroupList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ImageItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Path");

                    b.HasKey("Id");

                    b.ToTable("ImageList");
                });

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

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.User.RoleItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAdminRole");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RoleList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.User.UserCompany", b =>
                {
                    b.Property<Guid>("UserItemId");

                    b.Property<Guid>("CompanyItemId");

                    b.HasKey("UserItemId", "CompanyItemId");

                    b.HasIndex("CompanyItemId");

                    b.ToTable("UserCompanyList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.User.UserItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryCode");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<DateTime>("LastOnline");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired();

                    b.Property<string>("Title");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.ToTable("UserList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.User.UserRole", b =>
                {
                    b.Property<Guid>("UserItemId");

                    b.Property<Guid>("RoleItemId");

                    b.HasKey("UserItemId", "RoleItemId");

                    b.HasIndex("RoleItemId");

                    b.ToTable("UserRoleList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListFinishedStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("VlFinishedStatusList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("VlTypeOfAnswer");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfMachine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("VlTypeOfMachineList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("VlTypeOfResult");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfSupplierAndVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("VlTypeOfSupplierAndVersionList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("VlTypeOfTestList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListUserPrerequisite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("VlUserPrerequisiteList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Company.ContactPersonItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Company.CompanyItem")
                        .WithMany("ContactPersonList")
                        .HasForeignKey("CompanyItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data.AnswerData", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.AnswerItem", "AnswerItem")
                        .WithMany("AnswerDataList")
                        .HasForeignKey("AnswerItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ImageItem", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfResult", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data.RuleData")
                        .WithMany("AnswerDataList")
                        .HasForeignKey("RuleDataId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfAnswer", "TypeOfAnswer")
                        .WithMany()
                        .HasForeignKey("TypeOfAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data.OutcomeData", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationTestItem")
                        .WithMany("OutcomeDataList")
                        .HasForeignKey("DeclarationTestItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.IndicatorItem", "Indicator")
                        .WithMany("OutcomeDataList")
                        .HasForeignKey("IndicatorItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.RequirementItem", "Requirement")
                        .WithMany()
                        .HasForeignKey("RequirementItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfResult", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data.RuleData", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data.OutcomeData", "OutcomeData")
                        .WithMany("RuleDataList")
                        .HasForeignKey("OutcomeDataId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfResult", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.RuleItem", "Rule")
                        .WithMany()
                        .HasForeignKey("RuleItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Company.CompanyItem", "Company")
                        .WithMany("DeclarationList")
                        .HasForeignKey("CompanyItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.User.UserItem", "User")
                        .WithMany()
                        .HasForeignKey("UserItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationTestItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationItem", "DeclarationItem")
                        .WithOne("DeclarationTestItem")
                        .HasForeignKey("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationTestItem", "DeclarationItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListFinishedStatus", "FinishedStatus")
                        .WithMany()
                        .HasForeignKey("FinishedStatusId");

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ImageItem", "Image1")
                        .WithMany()
                        .HasForeignKey("Image1Id");

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ImageItem", "Image2")
                        .WithMany()
                        .HasForeignKey("Image2Id");

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfSupplierAndVersion", "SupplierAndVersion")
                        .WithMany()
                        .HasForeignKey("SupplierAndVersionId");

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfMachine", "TypeOfMachine")
                        .WithMany()
                        .HasForeignKey("TypeOfMachineId");

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfTest", "TypeOfTest")
                        .WithMany()
                        .HasForeignKey("TypeOfTestId");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.AnswerItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.RuleItem", "RuleItem")
                        .WithMany("AnswerList")
                        .HasForeignKey("RuleItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfAnswer", "TypeOfAnswer")
                        .WithMany()
                        .HasForeignKey("TypeOfAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.DeclarationTestGroup", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationItem", "DeclarationItem")
                        .WithMany("TestGroupList")
                        .HasForeignKey("DeclarationItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.TestGroupItem", "TestGroupItem")
                        .WithMany("DeclarationList")
                        .HasForeignKey("TestGroupItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.IndicatorTestGroup", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.TestGroupItem", "TestGroupItem")
                        .WithMany("IndicatorList")
                        .HasForeignKey("IndicatorItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.IndicatorItem", "IndicatorItem")
                        .WithMany("TestGroupList")
                        .HasForeignKey("TestGroupItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.IndicatorUserPrerequisite", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.IndicatorItem", "IndicatorItem")
                        .WithMany("IndicatorUserPrerequisiteList")
                        .HasForeignKey("IndicatorItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListUserPrerequisite", "ValueListUserPrerequisite")
                        .WithMany()
                        .HasForeignKey("ValueListUserPrerequisiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.RequirementItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.IndicatorItem", "Indicator")
                        .WithMany()
                        .HasForeignKey("IndicatorItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.RequirementUserPrerequisite", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.RequirementItem", "RequirementItem")
                        .WithMany("RequirementUserPrerequisiteList")
                        .HasForeignKey("RequirementItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListUserPrerequisite", "ValueListUserPrerequisite")
                        .WithMany()
                        .HasForeignKey("ValueListUserPrerequisiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.RuleItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Standard.ChapterItem", "Chapter")
                        .WithMany("RuleList")
                        .HasForeignKey("ChapterItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.IndicatorItem")
                        .WithMany("RuleList")
                        .HasForeignKey("IndicatorItemId");

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.RequirementItem", "Requirement")
                        .WithMany("RuleList")
                        .HasForeignKey("RequirementItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Standard.StandardItem", "Standard")
                        .WithMany("RuleList")
                        .HasForeignKey("StandardItemId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Standard.ChapterItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Standard.StandardItem", "Standard")
                        .WithMany()
                        .HasForeignKey("StandardItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.User.UserCompany", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Company.CompanyItem", "CompanyItem")
                        .WithMany("UserList")
                        .HasForeignKey("CompanyItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.User.UserItem", "UserItem")
                        .WithMany("CompanyList")
                        .HasForeignKey("UserItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.User.UserRole", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.User.RoleItem", "RoleItem")
                        .WithMany("UserList")
                        .HasForeignKey("RoleItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.User.UserItem", "UserItem")
                        .WithMany("RoleList")
                        .HasForeignKey("UserItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}