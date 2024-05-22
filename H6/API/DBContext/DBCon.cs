using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using Models;
using MySqlX.XDevAPI.Common;


namespace API.DBContext
{
    public class DBCon : DbContext
    {

        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerGroup> AnswerGroups { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionGroup> QuestionGroups { get; set; }
        public DbSet<User> Users { get; set; }


        public DBCon()
        {
        }
        public DBCon(DbContextOptions<DBCon> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
