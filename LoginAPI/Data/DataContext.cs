﻿using LoginAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<Account> Accounts { get; set; }

    }
}
