using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class BookShopContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<AgeCategory> AgeCategories { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public BookShopContext(DbContextOptions<BookShopContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetAuthors(modelBuilder);
            SetCoverTypes(modelBuilder);
            SetGenres(modelBuilder);
            SetAgeCategories(modelBuilder);
        }

        public void SetAuthors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                    new Author()
                    {
                        Id = 1,
                        Name = "Пушкин"
                    });
            modelBuilder.Entity<Author>().HasData(
                    new Author()
                    {
                        Id = 2,
                        Name = "SomeAuthor"
                    });
            modelBuilder.Entity<Author>().HasData(
                    new Author()
                    {
                        Id = 3,
                        Name = "SomeAuthor1"
                    });
        }
        public void SetCoverTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoverType>().HasData(
                    new CoverType()
                    {
                        Id = 1,
                        Name = "Твердый"
                    });
            modelBuilder.Entity<CoverType>().HasData(
                new CoverType()
                {
                    Id = 2,
                    Name = "Мягкий"
                });
            modelBuilder.Entity<CoverType>().HasData(
                new CoverType()
                {
                    Id = 3,
                    Name = "Ручной"
                });

        }
        public void SetGenres(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre()
                {
                    Id = 1,
                    Name = "Детектив"
                });
            modelBuilder.Entity<Genre>().HasData(
                new Genre()
                {
                    Id = 2,
                    Name = "Научпоп"
                });
            modelBuilder.Entity<Genre>().HasData(
                new Genre()
                {
                    Id = 3,
                    Name = "Роман"
                });
            modelBuilder.Entity<Genre>().HasData(
                new Genre()
                {
                    Id = 4,
                    Name = "Поэзия"
                });
        }
        public void SetAgeCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeCategory>().HasData(
                    new AgeCategory()
                    {
                        Id = 1,
                        Min = 0,
                        Max = 3,
                    });
            modelBuilder.Entity<AgeCategory>().HasData(
                    new AgeCategory()
                    {
                        Id = 2,
                        Min = 3,
                        Max = 10,
                    });
            modelBuilder.Entity<AgeCategory>().HasData(
                    new AgeCategory()
                    {
                        Id = 3,
                        Min = 10,
                        Max = 15,
                    });
            modelBuilder.Entity<AgeCategory>().HasData(
                    new AgeCategory()
                    {
                        Id = 4,
                        Min = 15,
                        Max = 17,
                    });
            modelBuilder.Entity<AgeCategory>().HasData(
                    new AgeCategory()
                    {
                        Id = 5,
                        Min = 18,
                        Max = 199,
                    });

        }
    }
}
