﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Social_orm.Data;

namespace Social_orm.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Social_orm.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeneficiarID")
                        .HasColumnType("int");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("missings")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roomnumber")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiarID")
                        .IsUnique();

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("Social_orm.Models.Aid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeneficiarID")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiarID");

                    b.ToTable("aids");
                });

            modelBuilder.Entity("Social_orm.Models.Belongings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeneficiarID")
                        .HasColumnType("int");

                    b.Property<int>("cars")
                        .HasColumnType("int");

                    b.Property<int>("houses")
                        .HasColumnType("int");

                    b.Property<int>("lands")
                        .HasColumnType("int");

                    b.Property<int?>("rentIncomeAmount")
                        .HasColumnType("int");

                    b.Property<string>("rentIncomeType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiarID")
                        .IsUnique();

                    b.ToTable("belongings");
                });

            modelBuilder.Entity("Social_orm.Models.Beneficiar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HandicapType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HealthStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Insured")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecordNumber")
                        .HasColumnType("int");

                    b.Property<string>("RecordPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Beneficiars");
                });

            modelBuilder.Entity("Social_orm.Models.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeneficiarID")
                        .HasColumnType("int");

                    b.Property<string>("EducationLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationalInstitute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HandicapType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HealthStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Insured")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("monthlyContribution")
                        .HasColumnType("int");

                    b.Property<int?>("yearlyCost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiarID");

                    b.ToTable("children");
                });

            modelBuilder.Entity("Social_orm.Models.Disease", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeneficiarID")
                        .HasColumnType("int");

                    b.Property<int>("ChildID")
                        .HasColumnType("int");

                    b.Property<string>("DiseaseType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicineCost")
                        .HasColumnType("int");

                    b.Property<string>("MedicineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WifeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BeneficiarID")
                        .IsUnique();

                    b.HasIndex("ChildID")
                        .IsUnique();

                    b.HasIndex("WifeID")
                        .IsUnique();

                    b.ToTable("diseases");
                });

            modelBuilder.Entity("Social_orm.Models.Loans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeneficiarID")
                        .HasColumnType("int");

                    b.Property<int?>("OtherDebts")
                        .HasColumnType("int");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<string>("paymentfrequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("paymentvalue")
                        .HasColumnType("int");

                    b.Property<string>("reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiarID")
                        .IsUnique();

                    b.ToTable("loans");
                });

            modelBuilder.Entity("Social_orm.Models.SocialHelp", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeneficiarID")
                        .HasColumnType("int");

                    b.Property<string>("InstitutionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<string>("duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BeneficiarID")
                        .IsUnique();

                    b.ToTable("socialHelps");
                });

            modelBuilder.Entity("Social_orm.Models.Wife", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeneficiarID")
                        .HasColumnType("int");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HandicapType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HealthStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Insured")
                        .HasColumnType("bit");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiarID")
                        .IsUnique();

                    b.ToTable("Wives");
                });

            modelBuilder.Entity("Social_orm.Models.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeneficiarID")
                        .HasColumnType("int");

                    b.Property<int>("ChildID")
                        .HasColumnType("int");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfWork")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WifeID")
                        .HasColumnType("int");

                    b.Property<string>("sector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiarID")
                        .IsUnique();

                    b.HasIndex("ChildID")
                        .IsUnique();

                    b.HasIndex("WifeID")
                        .IsUnique();

                    b.ToTable("works");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Social_orm.Models.Address", b =>
                {
                    b.HasOne("Social_orm.Models.Beneficiar", "beneficiar")
                        .WithOne("address")
                        .HasForeignKey("Social_orm.Models.Address", "BeneficiarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Social_orm.Models.Aid", b =>
                {
                    b.HasOne("Social_orm.Models.Beneficiar", "beneficiar")
                        .WithMany("aids")
                        .HasForeignKey("BeneficiarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Social_orm.Models.Belongings", b =>
                {
                    b.HasOne("Social_orm.Models.Beneficiar", "beneficiar")
                        .WithOne("belongings")
                        .HasForeignKey("Social_orm.Models.Belongings", "BeneficiarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Social_orm.Models.Child", b =>
                {
                    b.HasOne("Social_orm.Models.Beneficiar", "beneficiar")
                        .WithMany("children")
                        .HasForeignKey("BeneficiarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Social_orm.Models.Disease", b =>
                {
                    b.HasOne("Social_orm.Models.Beneficiar", "beneficiar")
                        .WithOne("disease")
                        .HasForeignKey("Social_orm.Models.Disease", "BeneficiarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Social_orm.Models.Child", "child")
                        .WithOne("disease")
                        .HasForeignKey("Social_orm.Models.Disease", "ChildID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Social_orm.Models.Wife", "wife")
                        .WithOne("disease")
                        .HasForeignKey("Social_orm.Models.Disease", "WifeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Social_orm.Models.Loans", b =>
                {
                    b.HasOne("Social_orm.Models.Beneficiar", "beneficiar")
                        .WithOne("loan")
                        .HasForeignKey("Social_orm.Models.Loans", "BeneficiarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Social_orm.Models.SocialHelp", b =>
                {
                    b.HasOne("Social_orm.Models.Beneficiar", "beneficiar")
                        .WithOne("socialHelp")
                        .HasForeignKey("Social_orm.Models.SocialHelp", "BeneficiarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Social_orm.Models.Wife", b =>
                {
                    b.HasOne("Social_orm.Models.Beneficiar", "beneficiar")
                        .WithOne("wife")
                        .HasForeignKey("Social_orm.Models.Wife", "BeneficiarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Social_orm.Models.Work", b =>
                {
                    b.HasOne("Social_orm.Models.Beneficiar", "beneficiar")
                        .WithOne("work")
                        .HasForeignKey("Social_orm.Models.Work", "BeneficiarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Social_orm.Models.Child", "child")
                        .WithOne("work")
                        .HasForeignKey("Social_orm.Models.Work", "ChildID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Social_orm.Models.Wife", "wife")
                        .WithOne("work")
                        .HasForeignKey("Social_orm.Models.Work", "WifeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
