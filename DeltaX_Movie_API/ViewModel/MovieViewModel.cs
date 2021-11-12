using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX_Movie_API.ViewModel
{
    /// <summary>
    /// Movie ViewModel, Data Presented to User
    /// </summary>
    public class MovieViewModel
    {
        public int movieid { get; set; }
        public string name { get; set; }
        public string plot { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string producer { get; set; }
        public List<string> actors { get; set; }
    }
}
