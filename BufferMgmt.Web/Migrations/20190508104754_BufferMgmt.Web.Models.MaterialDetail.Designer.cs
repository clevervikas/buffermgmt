﻿// <auto-generated />
using BufferMgmt.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BufferMgmt.Web.Migrations
{
    [DbContext(typeof(BufferMgmtContext))]
    [Migration("20190508104754_BufferMgmt.Web.Models.MaterialDetail")]
    partial class BufferMgmtWebModelsMaterialDetail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BufferMgmt.Web.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchName");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("BufferMgmt.Web.Models.BufferSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId");

                    b.Property<decimal>("BufferStock");

                    b.Property<int>("CustomerId");

                    b.Property<int>("MaterialCodeId");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MaterialCodeId");

                    b.ToTable("BufferSize");
                });

            modelBuilder.Entity("BufferMgmt.Web.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BufferMgmt.Web.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GradeName");

                    b.HasKey("Id");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("BufferMgmt.Web.Models.MaterialCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaterialCodeName");

                    b.HasKey("Id");

                    b.ToTable("MaterialCodes");
                });

            modelBuilder.Entity("BufferMgmt.Web.Models.MaterialDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId");

                    b.Property<decimal>("BufferStock");

                    b.Property<int>("CustomerId");

                    b.Property<int>("GradeId");

                    b.Property<int>("MaterialCodeId");

                    b.Property<int>("RefLength");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("GradeId");

                    b.HasIndex("MaterialCodeId");

                    b.ToTable("MaterialDetails");
                });

            modelBuilder.Entity("BufferMgmt.Web.Models.BufferSize", b =>
                {
                    b.HasOne("BufferMgmt.Web.Models.Branch", "Branch")
                        .WithMany("BufferSize")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BufferMgmt.Web.Models.Customer", "Customer")
                        .WithMany("BufferSize")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BufferMgmt.Web.Models.MaterialCode", "MaterialCode")
                        .WithMany("BufferSize")
                        .HasForeignKey("MaterialCodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BufferMgmt.Web.Models.MaterialDetail", b =>
                {
                    b.HasOne("BufferMgmt.Web.Models.Branch", "Branch")
                        .WithMany("MaterialDetail")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BufferMgmt.Web.Models.Customer", "Customer")
                        .WithMany("MaterialDetail")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BufferMgmt.Web.Models.Grade", "Grade")
                        .WithMany("MaterialDetail")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BufferMgmt.Web.Models.MaterialCode", "MaterialCode")
                        .WithMany("MaterialDetail")
                        .HasForeignKey("MaterialCodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
