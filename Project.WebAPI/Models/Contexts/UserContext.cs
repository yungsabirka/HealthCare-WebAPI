﻿using Microsoft.EntityFrameworkCore;

namespace Project.WebAPI.Models.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
