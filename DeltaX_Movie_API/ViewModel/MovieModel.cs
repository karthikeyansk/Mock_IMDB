using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX_Movie_API.ViewModel
{
    /// <summary>
    /// Movie Model , Handles incoming data
    /// </summary>
    public class MovieModel
    {
        public int movieid { get; set; }
        public string name { get; set; }
        public string plot { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int producerId { get; set; }
        public List<string> actors { get; set; }
    }
}
