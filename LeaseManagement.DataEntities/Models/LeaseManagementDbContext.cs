using System;
using LeaseManagement.BusinessEntities.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LeaseManagement.DataEntities.Models
{
    public partial class LeaseManagementDbContext : DbContext
    {
        public LeaseManagementDbContext()
        {
        }

        public LeaseManagementDbContext(DbContextOptions<LeaseManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccountType> TblAccountType { get; set; }
        public virtual DbSet<TblBodyType> TblBodyType { get; set; }
        public virtual DbSet<TblCar> TblCar { get; set; }
        public virtual DbSet<TblContractType> TblContractType { get; set; }
        public virtual DbSet<TblEmploymentType> TblEmploymentType { get; set; }
        public virtual DbSet<TblFuel> TblFuel { get; set; }
        public virtual DbSet<TblInteriorType> TblInteriorType { get; set; }
        public virtual DbSet<TblMake> TblMake { get; set; }
        public virtual DbSet<TblMileageLimit> TblMileageLimit { get; set; }
        public virtual DbSet<TblPaybackTime> TblPaybackTime { get; set; }
        public virtual DbSet<TblQuote> TblQuote { get; set; }
        public virtual DbSet<TblTransmission> TblTransmission { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblUserBankDetails> TblUserBankDetails { get; set; }
        public virtual DbSet<TblUserEmploymentDetails> TblUserEmploymentDetails { get; set; }
        public virtual DbSet<TblUserPersonalDetails> TblUserPersonalDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DSK-445\\SQL2012;Database=LeaseManagementDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarVM>(entity =>
            {
                entity.HasKey(e => e.CarId);
                entity.ToTable("CarVM");
                entity.Property(e => e.BodyType);
                entity.Property(e => e.CO2Emission);
                entity.Property(e => e.Color);
                entity.Property(e => e.Description);
                entity.Property(e => e.FuelCapacity);
                entity.Property(e => e.FuelComsumption);
                entity.Property(e => e.FuelType);
                entity.Property(e => e.InteriorType);
                entity.Property(e => e.Make);
                entity.Property(e => e.Mileage);
                entity.Property(e => e.Model);
                entity.Property(e => e.ModelDate);
                entity.Property(e => e.Price);
                entity.Property(e => e.Seats);
                entity.Property(e => e.Transmission);
                entity.Property(e => e.ImagePath);
                entity.Property(e => e.IsAvailable);

            });
            
            modelBuilder.Entity<UserVM>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.ToTable("UserVM");
                entity.Property(e => e.Email);
                entity.Property(e => e.Password);
                entity.Property(e => e.Username);
                entity.Property(e => e.ActivationCode);
                entity.Property(e => e.IsVerified);
            });

            modelBuilder.Entity<UserPersonalVM>(entity =>
            {
                entity.HasKey(e => e.UserPersonalId);
                entity.ToTable("UserPersonalVM");
                entity.Property(e=>e.UserId);
                entity.Property(e => e.Firstname);
                entity.Property(e => e.Lastname);
                entity.Property(e => e.Dob);
                entity.Property(e => e.Gender);
                entity.Property(e => e.Contact);
                entity.Property(e => e.HouseNo);
                entity.Property(e => e.Street);
                entity.Property(e => e.City);
                entity.Property(e => e.State);
                entity.Property(e => e.Country);
                entity.Property(e => e.Pincode);
            });

            modelBuilder.Entity<MileageLimitVM>(entity =>
            {
                entity.HasKey(e => e.MileageLimitId);
                entity.ToTable("MileageLimitVM");
                entity.Property(e=>e.Kilometers);
            });

            modelBuilder.Entity<PaybackTimeVM>(entity =>
            {
                entity.HasKey(e=>e.PaybackTimeId);
                entity.ToTable("PaybackTimeVM");
                entity.Property(e => e.Months);
            });

            modelBuilder.Entity<AccountTypeVM>(entity =>
            {
                entity.HasKey(e => e.AccountTypeId);
                entity.ToTable("AccountTypeVM");
                entity.Property(e => e.AccountType);
            });

            modelBuilder.Entity<UserBankVM>(entity =>
            {
                entity.HasKey(e => e.UserBankId);
                entity.ToTable("UserBankVM");
                entity.Property(e => e.UserId);
                entity.Property(e => e.AccountHolderName);
                entity.Property(e => e.AccountNumber);
                entity.Property(e => e.BankAddress);
                entity.Property(e => e.BankBranch);
                entity.Property(e => e.BankCountry);
                entity.Property(e => e.BankName);
                entity.Property(e => e.BankState);
                entity.Property(e => e.AccountTypeId);
                entity.Property(e => e.AccountType);
            });

            modelBuilder.Entity<UserEmploymentVM>(entity =>
            {
                entity.HasKey(e => e.UserEmploymentId);
                entity.ToTable("UserEmploymentVM");
                entity.Property(e => e.UserId);
                entity.Property(e => e.Salary);
                entity.Property(e => e.EmploymentTypeId);
                entity.Property(e => e.CreditScore);
                entity.Property(e => e.ContractId);
                entity.Property(e => e.CompanyName);
                entity.Property(e => e.CompanyAddress);
                entity.Property(e => e.ContractType);
                entity.Property(e => e.EmploymentType);
            });

            modelBuilder.Entity<ContractVM>(entity =>
            {
                entity.HasKey(e => e.ContractId);
                entity.ToTable("ContractVM");
                entity.Property(e => e.ContractType);
            });

            modelBuilder.Entity<EmploymentTypeVM>(entity =>
            {
                entity.HasKey(e => e.EmploymentTypeId);
                entity.ToTable("EmploymentTypeVM");
                entity.Property(e => e.EmploymentType);
            });

            modelBuilder.Entity<QuoteVM>(entity =>
            {
                entity.HasKey(e => e.QuoteId);
                entity.ToTable("QuoteVM");
                entity.Property(e => e.UserId);
                entity.Property(e => e.Price);
                entity.Property(e => e.PaybackTimeId);
                entity.Property(e => e.MileageLimitId);
                entity.Property(e => e.CarId);
            });

            modelBuilder.Entity<TblAccountType>(entity =>
            {
                entity.HasKey(e => e.AccountTypeId);

                entity.ToTable("tblAccountType");

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblBodyType>(entity =>
            {
                entity.HasKey(e => e.BodyTypeId);

                entity.ToTable("tblBodyType");

                entity.Property(e => e.BodyType)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblCar>(entity =>
            {
                entity.HasKey(e => e.CarId);

                entity.ToTable("tblCar");

                entity.Property(e => e.CarId).ValueGeneratedNever();

                entity.Property(e => e.Co2emission)
                    .IsRequired()
                    .HasColumnName("CO2Emission")
                    .HasMaxLength(10);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.FuelCapacity)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FuelComsumption)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.IsAvailable).HasColumnName("isAvailable");

                entity.Property(e => e.Mileage)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModelDate).HasColumnType("datetime");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.BodyType)
                    .WithMany(p => p.TblCar)
                    .HasForeignKey(d => d.BodyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCar_tblBodyType");

                entity.HasOne(d => d.Fuel)
                    .WithMany(p => p.TblCar)
                    .HasForeignKey(d => d.FuelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCar_tblFuel");

                entity.HasOne(d => d.InteriorType)
                    .WithMany(p => p.TblCar)
                    .HasForeignKey(d => d.InteriorTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCar_tblInteriorType");

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.TblCar)
                    .HasForeignKey(d => d.MakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCar_tblMake");

                entity.HasOne(d => d.Transmission)
                    .WithMany(p => p.TblCar)
                    .HasForeignKey(d => d.TransmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCar_tblTransmission");
            });

            modelBuilder.Entity<TblContractType>(entity =>
            {
                entity.HasKey(e => e.ContractId);

                entity.ToTable("tblContractType");

                entity.Property(e => e.ContractType)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblEmploymentType>(entity =>
            {
                entity.HasKey(e => e.EmploymentTypeId);

                entity.ToTable("tblEmploymentType");

                entity.Property(e => e.EmploymentType)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblFuel>(entity =>
            {
                entity.HasKey(e => e.FuelId);

                entity.ToTable("tblFuel");

                entity.Property(e => e.FuelType)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TblInteriorType>(entity =>
            {
                entity.HasKey(e => e.InteriorTypeId);

                entity.ToTable("tblInteriorType");

                entity.Property(e => e.InteriorType)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblMake>(entity =>
            {
                entity.HasKey(e => e.MakeId);

                entity.ToTable("tblMake");

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblMileageLimit>(entity =>
            {
                entity.HasKey(e => e.MileageLimitId);

                entity.ToTable("tblMileageLimit");

                entity.Property(e => e.Kilometers)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TblPaybackTime>(entity =>
            {
                entity.HasKey(e => e.PaybackTimeId);

                entity.ToTable("tblPaybackTime");

                entity.Property(e => e.Months)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TblQuote>(entity =>
            {
                entity.HasKey(e => e.QuoteId);

                entity.ToTable("tblQuote");

                entity.Property(e => e.QuoteId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.TblQuote)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblQuote_tblCar");

                entity.HasOne(d => d.MileageLimit)
                    .WithMany(p => p.TblQuote)
                    .HasForeignKey(d => d.MileageLimitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblQuote_tblMileageLimit");

                entity.HasOne(d => d.PaybackTime)
                    .WithMany(p => p.TblQuote)
                    .HasForeignKey(d => d.PaybackTimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblQuote_tblPaybackTime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblQuote)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblQuote_tblUser");
            });

            modelBuilder.Entity<TblTransmission>(entity =>
            {
                entity.HasKey(e => e.TransmissionId);

                entity.ToTable("tblTransmission");

                entity.Property(e => e.Transmission)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tblUser");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsVerified).HasColumnName("isVerified");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(e => e.ActivationCode);
            });

            modelBuilder.Entity<TblUserBankDetails>(entity =>
            {
                entity.HasKey(e => e.UserBankId);

                entity.ToTable("tblUserBankDetails");

                entity.Property(e => e.AccountHolderName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BankAddress).IsRequired();

                entity.Property(e => e.BankBranch)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BankCountry)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BankState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.TblUserBankDetails)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUserBankDetails_tblAccountType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserBankDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUserBankDetails_tblUser");
            });

            modelBuilder.Entity<TblUserEmploymentDetails>(entity =>
            {
                entity.HasKey(e => e.UserEmploymentId);

                entity.ToTable("tblUserEmploymentDetails");

                entity.Property(e => e.CompanyAddress).IsRequired();

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreditScore)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Salary)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.TblUserEmploymentDetails)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUserEmploymentDetails_tblContractType");

                entity.HasOne(d => d.EmploymentType)
                    .WithMany(p => p.TblUserEmploymentDetails)
                    .HasForeignKey(d => d.EmploymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUserEmploymentDetails_tblEmploymentType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserEmploymentDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUserEmploymentDetails_tblUser");
            });

            modelBuilder.Entity<TblUserPersonalDetails>(entity =>
            {
                entity.HasKey(e => e.UserPersonalId);

                entity.ToTable("tblUserPersonalDetails");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HouseNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pincode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserPersonalDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUserPersonalDetails_tblUser");
            });
        }
    }
}
