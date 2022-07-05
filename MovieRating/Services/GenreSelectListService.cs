using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRating.Data;

namespace MovieRating.Services
{
    public class GenreSelectListService : IGenreSelectListService
    {
        private readonly MovieRatingContext _context;

        public GenreSelectListService(MovieRatingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetGenresAsync()
        {
            return await _context.Movie
                                .Select(m => m.Genre)
                                .Distinct()
                                .Select(g => new SelectListItem
                                {
                                    Text = g.ToString(),
                                    Value = g.ToString()
                                })
                                .ToListAsync();
        }
    }
}
