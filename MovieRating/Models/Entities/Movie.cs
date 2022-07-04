using System.ComponentModel.DataAnnotations;

namespace MovieRating.Models.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string? Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Range(1,5)]
        public float Rating { get; set; }

    }
}
