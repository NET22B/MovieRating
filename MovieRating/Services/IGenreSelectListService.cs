using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieRating.Services
{
    public interface IGenreSelectListService
    {
        Task<IEnumerable<SelectListItem>> GetGenresAsync();
    }
}