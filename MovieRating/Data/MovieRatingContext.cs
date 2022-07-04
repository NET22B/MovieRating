using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieRating.Models.Entities;

namespace MovieRating.Data
{
    public class MovieRatingContext : DbContext
    {
        public MovieRatingContext (DbContextOptions<MovieRatingContext> options)
            : base(options)
        {
        }

        public DbSet<MovieRating.Models.Entities.Movie>? Movie { get; set; }
    }
}
