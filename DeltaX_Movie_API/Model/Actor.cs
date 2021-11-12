using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeltaX_Movie_API.Model
{
    /// <summary>
    /// Actor Class
    /// </summary>
    public class Actor
    {
        [Key]
        public int actorId { get; set; }
        public string name { get; set; }
        public string Bio { get; set; }

        public DateTime DateOfBirth { get; set; }
        [Range(0,2,ErrorMessage ="Invalid Gender")]
        public Gender gender { get; set; }

        public List<MovieCast> movieCast { get; set; }

    }
}
