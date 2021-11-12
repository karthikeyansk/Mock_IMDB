using DeltaX_Movie_API.DataContext;
using DeltaX_Movie_API.Model;
using DeltaX_Movie_API.Repository;
using DeltaX_Movie_API.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeltaX_Movie_API.Services
{
    public class MovieRepo : IMovieRepo
    {
        private readonly AppDbContext context;
        private readonly IActorRepo actorRepo;

        public MovieRepo(AppDbContext context,IActorRepo actorRepo)
        {
            this.context = context;
            this.actorRepo = actorRepo;
        }

        /// <summary>
        /// Adds a movie and cast.
        /// </summary>
        /// <param name="movieModel"></param>
        /// <param name="actorId"></param>
        /// <returns></returns>
        public bool AddMovie(MovieModel movieModel, List<int> actorId)
        {
            List<MovieCast> movieCasts = new List<MovieCast>();
            bool IsMovieAdded = true;
            var movie = new Movie()
            {
                name = movieModel.name,
                plot = movieModel.plot,
                producerId = movieModel.producerId,
                ReleaseDate = movieModel.ReleaseDate,
            };

            try
            {
                //Add movie
                this.context.movies.Add(movie);
                this.context.SaveChanges();

                //get movieId then add movie actor mapping
                int movieId = movie.movieid;
                foreach (var id in actorId)
                {
                    movieCasts.Add(new MovieCast()
                    {
                        movieId = movieId,
                        actorid = id
                    });
                }
                this.context.movieCasts.AddRange(movieCasts);
                this.context.SaveChanges();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return IsMovieAdded;
        }

        /// <summary>
        /// Get All Movies
        /// </summary>
        /// <returns></returns>

        public List<MovieViewModel> GetAllMovies()
        {
            var movies = this.context.movies.Include(mov => mov.moviecast).
                Include(m=>m.producer).ToList();
            var movieViewModel = new List<MovieViewModel>();
            foreach (var mov in movies)
            {
                var actorIds = mov.moviecast.Select(a => a.actorid).ToList();
                var actors = this.actorRepo.GetActorNameList(actorIds);
                movieViewModel.Add(new MovieViewModel()
                {
                    movieid=mov.movieid,
                    name=mov.name,
                    ReleaseDate=mov.ReleaseDate,
                    plot=mov.plot,
                    actors= actors,
                    producer=mov.producer.name
                });
            }
            
            return movieViewModel;
        }

        /// <summary>
        /// Update Movie/
        /// </summary>
        /// <param name="movieModel"></param>
        /// <param name="actorId"></param>
        /// <param name="id"></param>
        public void UpdateMovie(MovieModel movieModel, List<int> actorId,int id)
        {
            List<MovieCast> movieCasts = new List<MovieCast>();
            var movie = this.context.movies.Include(m=>m.moviecast).
                Where(m => m.movieid == id).FirstOrDefault();
            var moviecast = this.context.movieCasts.Where(c=>c.movieId==id).ToList();
            var newcast = new List<MovieCast>();
            //update fields in movie
            try
            {
                if(movie!=null)
                {
                    movie.name = movieModel.name;
                    movie.plot = movieModel.plot;
                    movie.producerId = movieModel.producerId;
                    movie.ReleaseDate = movieModel.ReleaseDate;
                    this.context.movies.Update(movie);
                    this.context.SaveChanges();
                }

                //update cast 
                //case 1 : Both actor list are equal, Update 
                if(moviecast.Count==actorId.Count)
                {
                    for(int i=0;i<moviecast.Count;i++)
                    {
                        moviecast[i].actorid = actorId[i];
                    }
                    this.context.movieCasts.UpdateRange(movieCasts);
                    this.context.SaveChanges();
                }

                //case 2:Added a new actor ,in movie cast
                else if(actorId.Count>moviecast.Count)
                {
                    var idInTable = moviecast.Select(m => m.actorid).ToArray();
                    foreach(var aid in actorId)
                    {
                        //if actoris not present in table, new entry is added in movie case
                        if (Array.IndexOf(idInTable,aid)==-1)
                        {
                            newcast.Add(new MovieCast() { movieId = id, actorid = aid });
                        }
                    }
                    this.context.movieCasts.AddRange(newcast);
                    this.context.SaveChanges();
                }
                //case 3: Delete exsisting actor
                else
                {
                    var newid = actorId.ToArray();
                    var idInTable = moviecast.Select(m => m.actorid).ToArray();
                    foreach (var aid in idInTable)
                    {
                        //if  exsisting actoris not present in new list, the records are deleted
                        if (Array.IndexOf(newid, aid) == -1)
                        {
                            var cast = this.context.movieCasts.Where(c => c.actorid == aid && c.movieId == id).SingleOrDefault();
                            newcast.Add(cast);
                        }
                    }
                    this.context.movieCasts.RemoveRange(newcast);
                    this.context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
