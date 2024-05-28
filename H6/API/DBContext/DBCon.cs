using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using Models;
using MySqlX.XDevAPI.Common;


namespace API.DBContext
{
    public class DBCon : DbContext
    {

        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Country> Countrys { get; set; }       
        public DbSet<QuestionGroup> QuestionGroups { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerGroup> AnswerGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SaltedUser> SaltedUsers { get; set; }


        public DBCon()
        {
        }
        public DBCon(DbContextOptions<DBCon> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionGroup>()
         .HasMany(qg => qg.Questions)
         .WithMany(q => q.QuestionGroups)
         .UsingEntity(j =>
             j.ToTable("QuestionGroupQuestion"));
        }
    }
}
