using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeltaX_Movie_API.Model
{
    /// <summary>
    /// Movie class
    /// </summary>
    public class Movie
    {
        [Key]
        public int movieid { get; set; }
        public string name { get; set; }
        public string plot { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int producerId { get; set; }
        public Producer producer { get; set; }
        public List<MovieCast> moviecast { get; set; }
    }
}
