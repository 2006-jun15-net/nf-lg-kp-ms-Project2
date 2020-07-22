using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TheHub.DataAccess.Model
{
    public partial class Project2Context : DbContext
    {
        public Project2Context()
        {
        }

        public Project2Context(DbContextOptions<Project2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CommentLikes> CommentLikes { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Following> Following { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<MediaTypes> MediaTypes { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<ReviewLikes> ReviewLikes { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommentLikes>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CommentId })
                    .HasName("PK_UserId_CommentId");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentLikes)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentLikes_CommentId_Users");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentLikes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CommentLikes_UserId_Users");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__Comments__C3B4DFCA970FC13E");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Comments_UserId_Users");
            });

            modelBuilder.Entity<Following>(entity =>
            {
                entity.HasKey(e => new { e.FollowerId, e.FollowingId })
                    .HasName("PK_FollowerId_FollowingId");

                entity.HasOne(d => d.FollowingNavigation)
                    .WithMany(p => p.Following)
                    .HasForeignKey(d => d.FollowingId)
                    .HasConstraintName("FK_Following_FollowingId_Users");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.Property(e => e.Composer).HasMaxLength(255);

                entity.Property(e => e.MediaName).HasMaxLength(255);

                entity.Property(e => e.MediaUrl).HasColumnName("MediaURL");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_Media_GenreId_Genre");

                entity.HasOne(d => d.MediaTypes)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.MediaTypesId)
                    .HasConstraintName("FK_Media_MediaTypesId_MediaTypes");
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.Property(e => e.MediaTypeName).HasMaxLength(255);
            });

            modelBuilder.Entity<MediaTypes>(entity =>
            {
                entity.Property(e => e.MediaTypesName).HasMaxLength(255);
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.HasKey(e => e.NotificationId)
                    .HasName("PK__Notifica__20CF2E122833CCBC");

                entity.Property(e => e.NotificationType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.HasOne(d => d.Reciver)
                    .WithMany(p => p.NotificationsReciver)
                    .HasForeignKey(d => d.ReciverId)
                    .HasConstraintName("FK_Notificatoins_Reciver_UserId_Users");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.NotificationsSender)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK_Notifications_Sender_UserId_Users");
            });

            modelBuilder.Entity<ReviewLikes>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ReviewId })
                    .HasName("PK_UserId_ReviewId");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewLikes)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewLikes_ReviewId_Users");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReviewLikes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ReviewLikes_UserId_Users");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__Reviews__74BC79CE5CE77355");

                entity.Property(e => e.Content).IsRequired();

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.MediaId)
                    .HasConstraintName("FK_Reviews_MediaId_Media");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Reviews_UserId_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4CEE7218B0");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__A9D1053443A70A57")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Users__C9F28456415B317F")
                    .IsUnique();

                entity.Property(e => e.Bio)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Picture).HasMaxLength(255);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
