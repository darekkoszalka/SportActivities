// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Running.Infrastructure.Data;

#nullable disable

namespace Running.Infrastructure.Migrations
{
    [DbContext(typeof(RunningDbContext))]
    [Migration("20220831091608_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Running.Domain.Entities.Run", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Distance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Pulse")
                        .HasColumnType("int");

                    b.Property<int>("PulseMax")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("Time")
                        .HasColumnType("time");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfRunId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.HasIndex("TypeOfRunId");

                    b.ToTable("Runs");
                });

            modelBuilder.Entity("Running.Domain.Entities.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TrainingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Running.Domain.Entities.TypeOfRun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TypesOfRun");
                });

            modelBuilder.Entity("Running.Domain.Entities.Run", b =>
                {
                    b.HasOne("Running.Domain.Entities.Training", "Training")
                        .WithMany("Runs")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Running.Domain.Entities.TypeOfRun", "TypeOfRun")
                        .WithMany("Runs")
                        .HasForeignKey("TypeOfRunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");

                    b.Navigation("TypeOfRun");
                });

            modelBuilder.Entity("Running.Domain.Entities.Training", b =>
                {
                    b.Navigation("Runs");
                });

            modelBuilder.Entity("Running.Domain.Entities.TypeOfRun", b =>
                {
                    b.Navigation("Runs");
                });
#pragma warning restore 612, 618
        }
    }
}
