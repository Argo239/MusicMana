using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MusicMana.Models;

namespace MusicManaApi.DataAccess;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Collect> Collects { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<MusicMana.Models.File> Files { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<Lyric> Lyrics { get; set; }

    public virtual DbSet<Music> Musics { get; set; }

    public virtual DbSet<Singer> Singers { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Style> Styles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=music_mana;User Id=root;Password=239889");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.SingerId }).HasName("PRIMARY");

            entity.ToTable("album");

            entity.HasIndex(e => e.Id, "id");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.SingerId).HasColumnName("singerId");
            entity.Property(e => e.AlbumName)
                .HasMaxLength(255)
                .HasColumnName("albumName");
        });

        modelBuilder.Entity<Collect>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.FavoritesId, e.MusicId, e.CoState }).HasName("PRIMARY");

            entity.ToTable("collect");

            entity.HasIndex(e => e.CoState, "coState");

            entity.HasIndex(e => e.FavoritesId, "favoritesId");

            entity.HasIndex(e => e.MusicId, "musicId");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.FavoritesId).HasColumnName("favoritesId");
            entity.Property(e => e.MusicId).HasColumnName("musicId");
            entity.Property(e => e.CoState).HasColumnName("coState");
            entity.Property(e => e.FavoritesDate)
                .HasColumnType("datetime")
                .HasColumnName("favoritesDate");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.UserId, e.FaState }).HasName("PRIMARY");

            entity.ToTable("favorites");

            entity.HasIndex(e => e.FaState, "faState");

            entity.HasIndex(e => e.Id, "id");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.FaState).HasColumnName("faState");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.FaName)
                .HasMaxLength(255)
                .HasColumnName("faName");
        });

        modelBuilder.Entity<MusicMana.Models.File>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("file");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("fileName");
            entity.Property(e => e.FileUrl)
                .HasMaxLength(255)
                .HasColumnName("fileUrl");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("level");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Level1)
                .HasMaxLength(255)
                .HasColumnName("level");
        });

        modelBuilder.Entity<Lyric>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lyric");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LyricUrl)
                .HasMaxLength(255)
                .HasColumnName("lyricUrl");
        });

        modelBuilder.Entity<Music>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.MusicSingerId, e.MusicUrlId, e.MusicStyleId, e.LyricId, e.AlbumId, e.StateId }).HasName("PRIMARY");

            entity.ToTable("music");

            entity.HasIndex(e => e.AlbumId, "albumId");

            entity.HasIndex(e => e.Id, "id");

            entity.HasIndex(e => e.LyricId, "lyricId");

            entity.HasIndex(e => e.MusicSingerId, "mon");

            entity.HasIndex(e => e.MusicStyleId, "musicStyleId");

            entity.HasIndex(e => e.MusicUrlId, "musicUrlId");

            entity.HasIndex(e => e.StateId, "stateId");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.MusicSingerId).HasColumnName("musicSingerId");
            entity.Property(e => e.MusicUrlId).HasColumnName("musicUrlId");
            entity.Property(e => e.MusicStyleId).HasColumnName("musicStyleId");
            entity.Property(e => e.LyricId).HasColumnName("lyricId");
            entity.Property(e => e.AlbumId).HasColumnName("albumId");
            entity.Property(e => e.StateId).HasColumnName("stateId");
            entity.Property(e => e.MusicName)
                .HasMaxLength(255)
                .HasColumnName("musicName");
        });

        modelBuilder.Entity<Singer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("singer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area).HasMaxLength(255);
            entity.Property(e => e.Sname)
                .HasMaxLength(255)
                .HasColumnName("SName");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("state");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StateName)
                .HasMaxLength(255)
                .HasColumnName("stateName");
        });

        modelBuilder.Entity<Style>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("style");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MusicStyle)
                .HasMaxLength(255)
                .HasColumnName("musicStyle");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.UserLevel, e.UserStateId }).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.UserId, "userId");

            entity.HasIndex(e => e.UserLevel, "userLevel");

            entity.HasIndex(e => e.UserStateId, "userStateId");

            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("userId");
            entity.Property(e => e.UserLevel).HasColumnName("userLevel");
            entity.Property(e => e.UserStateId).HasColumnName("userStateId");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .HasColumnName("userEmail");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("userName");
            entity.Property(e => e.UserPass)
                .HasMaxLength(255)
                .HasColumnName("userPass");
            entity.Property(e => e.UserSex)
                .HasMaxLength(2)
                .HasColumnName("userSex");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
