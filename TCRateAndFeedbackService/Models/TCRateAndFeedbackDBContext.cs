using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TCRateAndFeedbackService.Models
{
    public partial class TCRateAndFeedbackDBContext : DbContext
    {
        public TCRateAndFeedbackDBContext()
        {
        }

        public TCRateAndFeedbackDBContext(DbContextOptions<TCRateAndFeedbackDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserReview> UserReview { get; set; }
        public virtual DbSet<UserReviewType> UserReviewType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserReview>(entity =>
            {
                entity.HasKey(e => e.LngReviewId)
                    .HasName("PK__tbl_User__F975D81D8DA6BC22");

                entity.ToTable("tbl_UserReview");

                entity.Property(e => e.LngReviewId).HasColumnName("lng_review_id");

                entity.Property(e => e.DtmTimeSubmitted)
                    .HasColumnName("dtm_time_submitted")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntRatingId).HasColumnName("int_rating_id");

                entity.Property(e => e.StrComment)
                    .HasColumnName("str_comment")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StrUsername)
                    .IsRequired()
                    .HasColumnName("str_username")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IntRating)
                    .WithMany(p => p.UserReview)
                    .HasForeignKey(d => d.IntRatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_UserR__int_r__4BAC3F29");
            });

            modelBuilder.Entity<UserReviewType>(entity =>
            {
                entity.HasKey(e => e.LngRatingId)
                    .HasName("PK__tbl_User__A3A1766CC8173755");

                entity.ToTable("tbl_UserReviewType");

                entity.Property(e => e.LngRatingId)
                    .HasColumnName("lng_rating_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StrRatingName)
                    .IsRequired()
                    .HasColumnName("str_rating_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
