using System.ComponentModel.DataAnnotations;

namespace DeltaX_Movie_API.Model
{
    /// <summary>
    /// Movie Cast
    /// This model handles many-many relationship in mov-actor
    /// </summary>
    public class MovieCast
    {
        [Key]
        public int castId { get; set; }

        public int movieId { get; set; }
        public int actorid { get; set; }
        public Actor actor { get; set; }
        public Movie movie { get; set; }
    }
}
