using DeltaX_Movie_API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX_Movie_API.Repository
{
    /// <summary>
    /// Movie Repository
    /// </summary>
   public interface IMovieRepo
    {
        bool AddMovie(MovieModel movieModel, List<int> actorId);
        List<MovieViewModel> GetAllMovies();

        void UpdateMovie(MovieModel movieModel, List<int> actorId,int id);
    }
}
