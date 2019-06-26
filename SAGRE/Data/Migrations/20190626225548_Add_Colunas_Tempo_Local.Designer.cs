﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SAGRE.Data;

namespace SAGRE.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190626225548_Add_Colunas_Tempo_Local")]
    partial class Add_Colunas_Tempo_Local
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SAGRE.Models.AtividadesModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescricaoAtividade");

                    b.Property<bool>("Inativo");

                    b.Property<string>("NomeAtividade");

                    b.HasKey("ID");

                    b.ToTable("AtividadesModel");
                });

            modelBuilder.Entity("SAGRE.Models.BoletimModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Atividade")
                        .IsRequired();

                    b.Property<DateTime?>("Data")
                        .IsRequired();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("Flag");

                    b.Property<string>("HoraInicio");

                    b.Property<string>("HoraTermino");

                    b.Property<string>("Local")
                        .IsRequired();

                    b.Property<string>("NomeFiscal")
                        .IsRequired();

                    b.Property<string>("Setor")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<string>("TempoDuracao");

                    b.HasKey("ID");

                    b.ToTable("BoletimModel");
                });

            modelBuilder.Entity("SAGRE.Models.GruposRiscoModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<bool>("Inativo");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("GruposRiscoModel");
                });

            modelBuilder.Entity("SAGRE.Models.MetodosAnalise.AnaliseNASATLXModel", b =>
                {
                    b.Property<int>("ID_Analise")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ID");

                    b.Property<string>("escalaEsforco");

                    b.Property<string>("escalaFisica");

                    b.Property<string>("escalaFrustacao");

                    b.Property<string>("escalaMental");

                    b.Property<string>("escalaPerformace");

                    b.Property<string>("escalaTemporal");

                    b.Property<string>("rangeDE");

                    b.Property<string>("rangeDF");

                    b.Property<string>("rangeDM");

                    b.Property<string>("rangeDT");

                    b.Property<string>("rangeFR");

                    b.Property<string>("rangePE");

                    b.HasKey("ID_Analise");

                    b.HasIndex("ID")
                        .IsUnique();

                    b.ToTable("AnaliseNASATLXModel");
                });

            modelBuilder.Entity("SAGRE.Models.MetodosAnalise.AnalisePosturaModel", b =>
                {
                    b.Property<int>("ID_Analise")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcaoDescricao");

                    b.Property<string>("IB");

                    b.Property<string>("IBDescricao");

                    b.Property<string>("IC");

                    b.Property<string>("ICDescricao");

                    b.Property<int>("ID");

                    b.Property<string>("IE");

                    b.Property<string>("IEDescricao");

                    b.Property<string>("IP");

                    b.Property<string>("IPDescricao");

                    b.Property<int>("Index");

                    b.HasKey("ID_Analise");

                    b.HasIndex("ID");

                    b.ToTable("AnalisePosturaModel");
                });

            modelBuilder.Entity("SAGRE.Models.MetodosAnalise.ClassificaoOWAS", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumBraco");

                    b.Property<int>("NumCategoria");

                    b.Property<int>("NumCosta");

                    b.Property<int>("NumForca");

                    b.Property<int>("NumPernas");

                    b.HasKey("ID");

                    b.ToTable("ClassificaoOWAS");
                });

            modelBuilder.Entity("SAGRE.Models.SetorModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<bool>("Inativo");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Sigla");

                    b.HasKey("ID");

                    b.ToTable("SetorModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SAGRE.Models.MetodosAnalise.AnaliseNASATLXModel", b =>
                {
                    b.HasOne("SAGRE.Models.BoletimModel", "BoletimModel")
                        .WithOne("listanasa")
                        .HasForeignKey("SAGRE.Models.MetodosAnalise.AnaliseNASATLXModel", "ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SAGRE.Models.MetodosAnalise.AnalisePosturaModel", b =>
                {
                    b.HasOne("SAGRE.Models.BoletimModel", "BoletimModel")
                        .WithMany("ListaAnalisePostura")
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
