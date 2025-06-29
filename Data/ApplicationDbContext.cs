﻿using Microsoft.EntityFrameworkCore;
using StudentPortal.Models.Entites;

namespace StudentPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
