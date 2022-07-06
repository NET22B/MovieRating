using Microsoft.AspNetCore.Mvc;
using MovieRating.Data;
using MovieRating.Models.ViewModels;

namespace MovieRating.ViewComponents
{
    public class StarViewComponent : ViewComponent
    {
        //private readonly MovieRatingContext context;

        //public StarViewComponent(MovieRatingContext context)
        //{
        //    this.context = context;
        //}

        public IViewComponentResult Invoke(float rating)
        {
            var doubleRating = (int)Math.Round(rating * 2);

            var model = new StarViewModel
            {
                Stars = doubleRating / 2,
                IsHalfStar = doubleRating % 2 == 1,
            };

            return View(model);
        }
    }
}
