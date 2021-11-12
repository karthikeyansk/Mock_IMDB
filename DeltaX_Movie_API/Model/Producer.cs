using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX_Movie_API.Model
{
    /// <summary>
    /// Producer
    /// </summary>
    public class Producer
    {
        [Key]
        public int producerId { get; set; }
        public string name { get; set; }
        public string Bio { get; set; }

        public DateTime DateOfBirth { get; set; }
        [Range(0, 2, ErrorMessage = "Invalid Gender")]
        public Gender gender { get; set; }

        public string company { get; set; }

        public List<Movie> movies { get; set; }
    }
}
