﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext (DbContextOptions<MoviesDbContext> options) : base (options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
