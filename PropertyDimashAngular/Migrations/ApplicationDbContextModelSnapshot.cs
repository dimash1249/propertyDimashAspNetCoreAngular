﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyDimashAngular.Data;

#nullable disable

namespace PropertyDimashAngular.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "Administrator_id",
                            ConcurrencyStamp = "1",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "Moderator_id",
                            ConcurrencyStamp = "2",
                            Name = "Moderator",
                            NormalizedName = "MODERATOR"
                        },
                        new
                        {
                            Id = "Reporter_id",
                            ConcurrencyStamp = "3",
                            Name = "Reporter",
                            NormalizedName = "REPORTER"
                        },
                        new
                        {
                            Id = "User_id",
                            ConcurrencyStamp = "4",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "Dimash_id",
                            RoleId = "Moderator_id"
                        },
                        new
                        {
                            UserId = "Reporterid",
                            RoleId = "Reporter_id"
                        },
                        new
                        {
                            UserId = "Administratorid",
                            RoleId = "Administrator_id"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PropertyDimashAngular.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "Dimash_id",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f415931f-96b5-443f-91ce-5bfbb6602dc8",
                            Email = "nogaybaevd11@list.ru",
                            EmailConfirmed = true,
                            FirstName = "Dimash",
                            LastName = "Nogaybaev",
                            LockoutEnabled = false,
                            NormalizedEmail = "nogaybaevd11@list.ru",
                            NormalizedUserName = "nogaybaevd11@list.ru",
                            PasswordHash = "AQAAAAIAAYagAAAAEGBceqFUfO9ammdJfNVsEcp/gfuJ0tkZSCxIUNWlwQzqwZvC2yKYmbDkSkZMFOf8Jw==",
                            PhoneNumberConfirmed = false,
                            ProfileImage = new byte[0],
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "nogaybaevd11@list.ru"
                        },
                        new
                        {
                            Id = "Reporterid",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "12a53c63-30eb-4667-9ade-d98912c9a704",
                            Email = "reporter@list.ru",
                            EmailConfirmed = true,
                            FirstName = "Reporter",
                            LastName = "Reporter",
                            LockoutEnabled = false,
                            NormalizedEmail = "reporter@list.ru",
                            NormalizedUserName = "reporter@list.ru",
                            PasswordHash = "AQAAAAIAAYagAAAAEPwY9KNr5bceJhQltVjFdupOiBcceNon1+FZf5+8493b7qcPds0lWoZauP9QC8vz1A==",
                            PhoneNumberConfirmed = false,
                            ProfileImage = new byte[0],
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "reporter@list.ru"
                        },
                        new
                        {
                            Id = "Administratorid",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "91255bf3-cca6-45d9-9ab4-9e41d1da96c1",
                            Email = "administrator@list.ru",
                            EmailConfirmed = true,
                            FirstName = "Administrator",
                            LastName = "Administrator",
                            LockoutEnabled = false,
                            NormalizedEmail = "administrator@list.ru",
                            NormalizedUserName = "administrator@list.ru",
                            PasswordHash = "AQAAAAIAAYagAAAAELtGpLyJrjc/KNlE3q6yHyalAtU/Q7i6LF+rF6dUbECCQz23c4s83R1dwyzoChwo1Q==",
                            PhoneNumberConfirmed = false,
                            ProfileImage = new byte[0],
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "administrator@list.ru"
                        });
                });

            modelBuilder.Entity("PropertyDimashAngular.Models.News", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageAuthor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageNews")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("NewsType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublishedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("PropertyDimashAngular.Models.Property", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddressNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressStreet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AreaKitchen")
                        .HasColumnType("float");

                    b.Property<double>("AreaLiving")
                        .HasColumnType("float");

                    b.Property<string>("Bathroom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Different")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("HeightOfCeiling")
                        .HasColumnType("float");

                    b.Property<string>("Internet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("PropertyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<string>("Security")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalArea")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfBuilding")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserTelephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfBuilding")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Properties");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Property");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PropertyDimashAngular.Models.PropertyImage", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PropertyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyImages");
                });

            modelBuilder.Entity("PropertyDimashAngular.Models.ResidentialComplex", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddressNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressStreet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentialComplexName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ResidentialComplexes");

                    b.HasData(
                        new
                        {
                            Id = "ResidentialComplexId",
                            AddressNumber = "6",
                            AddressStreet = "Residential complex",
                            ResidentialComplexName = "Residential complex"
                        });
                });

            modelBuilder.Entity("PropertyDimashAngular.Models.Flat", b =>
                {
                    b.HasBaseType("PropertyDimashAngular.Models.Property");

                    b.Property<string>("Balcony")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("BalconyGlazed")
                        .HasColumnType("bit");

                    b.Property<string>("Door")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Floor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("FormerDormitory")
                        .HasColumnType("bit");

                    b.Property<string>("Parking")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PropertyFloor")
                        .HasColumnType("int");

                    b.Property<string>("PropertyFurnished")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentialComplexId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("TotalFloor")
                        .HasColumnType("int");

                    b.HasIndex("ResidentialComplexId");

                    b.HasDiscriminator().HasValue("Flat");
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
                    b.HasOne("PropertyDimashAngular.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PropertyDimashAngular.Data.ApplicationUser", null)
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

                    b.HasOne("PropertyDimashAngular.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PropertyDimashAngular.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PropertyDimashAngular.Models.News", b =>
                {
                    b.HasOne("PropertyDimashAngular.Data.ApplicationUser", "User")
                        .WithMany("News")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PropertyDimashAngular.Models.Property", b =>
                {
                    b.HasOne("PropertyDimashAngular.Data.ApplicationUser", "User")
                        .WithMany("Properties")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PropertyDimashAngular.Models.PropertyImage", b =>
                {
                    b.HasOne("PropertyDimashAngular.Models.Property", "Property")
                        .WithMany("Images")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("PropertyDimashAngular.Models.Flat", b =>
                {
                    b.HasOne("PropertyDimashAngular.Models.ResidentialComplex", "ResidentialComplex")
                        .WithMany("Properties")
                        .HasForeignKey("ResidentialComplexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResidentialComplex");
                });

            modelBuilder.Entity("PropertyDimashAngular.Data.ApplicationUser", b =>
                {
                    b.Navigation("News");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("PropertyDimashAngular.Models.Property", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("PropertyDimashAngular.Models.ResidentialComplex", b =>
                {
                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}
