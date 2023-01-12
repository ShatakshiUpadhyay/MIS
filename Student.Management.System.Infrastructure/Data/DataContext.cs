using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student.Management.System.Domain.Entities;

namespace Student.Management.System.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // modelBuilder.Entity<StudentDetails>()
        //     //     .HasOne<Subject>(s => s.Subject)
        //     //     .WithMany(Subject => Subject.Students)
        //     //     .HasForeignKey(s => s.SubjectId);

        //     modelBuilder.Entity<Subject>().Ignore(s => s.Students);
        // }

        public DbSet<StudentDetails> Students => Set<StudentDetails>();  
        public DbSet<Subject> Subjects => Set<Subject>();  

    }
}