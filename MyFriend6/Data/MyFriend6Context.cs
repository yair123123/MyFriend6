using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFriend6.Models;

namespace MyFriend6.Data
{
    public class MyFriend6Context : DbContext
    {
        public MyFriend6Context (DbContextOptions<MyFriend6Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the one-to-many relationship between User and Picture
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserPictures)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            // Configure the one-to-one relationship between User and ProfilePicture
            modelBuilder.Entity<User>()
                .HasOne(u => u.ProfilePicture)
                .WithOne()
                .HasForeignKey<User>(u => u.ProfilePictureId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }
        public DbSet<MyFriend6.Models.User> User { get; set; } = default!;
        public DbSet<MyFriend6.Models.Picture> Picture { get; set; } = default!;
    }
}
