using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Entities
{
    public partial class RecruitmentDBContext : DbContext
    {
        public RecruitmentDBContext()
        {
        }

        public RecruitmentDBContext(DbContextOptions<RecruitmentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlackListed> BlackListed { get; set; }
        public virtual DbSet<BusinessUnit> BusinessUnit { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Consultant> Consultant { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Interview> Interview { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<PositionHistory> PositionHistory { get; set; }
        public virtual DbSet<PositionSkills> PositionSkills { get; set; }
        public virtual DbSet<ShortListedCandidate> ShortListedCandidate { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<User> User { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-95HKV32;Database=RecruitmentDB;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<BlackListed>(entity =>
            {
                entity.Property(e => e.BlacklistedId).HasColumnName("BlacklistedID");

                entity.Property(e => e.AlterCellPhone).HasMaxLength(10);

                entity.Property(e => e.CellPhone)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ConsultanatId).HasColumnName("ConsultanatID");

                entity.Property(e => e.DecisionStatus)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Feedback).IsRequired();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Idnumber)
                    .IsRequired()
                    .HasColumnName("IDNumber")
                    .HasMaxLength(13);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Race)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.WorkNumber).HasMaxLength(10);
            });

            modelBuilder.Entity<BusinessUnit>(entity =>
            {
                entity.Property(e => e.BusinessUnitId).HasColumnName("BusinessUnitID");

                entity.Property(e => e.BusinessUnitName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.ManagerContactNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ManagerEmail)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.ManagerFirstName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.ManagerLastName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Sodimension)
                    .IsRequired()
                    .HasColumnName("SODimension")
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.AlterCellPhone).HasMaxLength(10);

                entity.Property(e => e.CellPhone)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ConsultantId).HasColumnName("ConsultantID");

                entity.Property(e => e.DecisionStatus)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.FeedBack).IsRequired();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Idnumber)
                    .IsRequired()
                    .HasColumnName("IDNumber")
                    .HasMaxLength(13);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Race)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.WorkNumber).HasMaxLength(10);

                entity.HasOne(d => d.Consultant)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.ConsultantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Candidate_Consultant");
            });

            modelBuilder.Entity<Consultant>(entity =>
            {
                entity.Property(e => e.ConsultantId).HasColumnName("ConsultantID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Document1)
                    .IsRequired()
                    .HasColumnName("Document");

                entity.Property(e => e.DocumentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TestType).HasMaxLength(50);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_Candidate");
            });

            modelBuilder.Entity<Interview>(entity =>
            {
                entity.Property(e => e.InterviewId).HasColumnName("InterviewID");

                entity.Property(e => e.InterviewDate).HasColumnType("date");

                entity.Property(e => e.InterviewType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShortlistedCandidateId).HasColumnName("ShortlistedCandidateID");

                entity.HasOne(d => d.ShortlistedCandidate)
                    .WithMany(p => p.Interview)
                    .HasForeignKey(d => d.ShortlistedCandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Interview_ShortListedCandidate");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.BusinessUnitId).HasColumnName("BusinessUnitID");

                entity.Property(e => e.Competency)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.DateUploaded).HasColumnType("date");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.PositionLevel)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.PositionTitle)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.PositionType)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.Position)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Position_BusinessUnit");
            });

            modelBuilder.Entity<PositionHistory>(entity =>
            {
                entity.HasKey(e => e.PosistionHistoryId);

                entity.Property(e => e.PosistionHistoryId).HasColumnName("PosistionHistoryID");

                entity.Property(e => e.BusinessUnitId).HasColumnName("BusinessUnitID");

                entity.Property(e => e.Competency)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.DateUploaded).HasColumnType("date");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.PositionLevel)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.PositionTitle)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<PositionSkills>(entity =>
            {
                entity.HasKey(e => e.PositionSkillId);

                entity.Property(e => e.PositionSkillId)
                    .HasColumnName("PositionSkillID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.Responsibility)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.PositionSkills)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PositionSkills_Position");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.PositionSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PositionSkills_Skill");
            });

            modelBuilder.Entity<ShortListedCandidate>(entity =>
            {
                entity.Property(e => e.ShortListedCandidateId).HasColumnName("ShortListedCandidateID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.ShortListedCandidate)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShortListedCandidate_Candidate");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.ShortListedCandidate)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShortListedCandidate_Position");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ConsultantId).HasColumnName("ConsultantID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Consultant)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.ConsultantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Consultant");
            });
        }
    }
}
