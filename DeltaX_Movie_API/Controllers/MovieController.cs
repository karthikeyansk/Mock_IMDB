using DeltaX_Movie_API.Repository;
using DeltaX_Movie_API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX_Movie_API.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IActorRepo actorRepo;
        private readonly IMovieRepo movieRepo;

        public MovieController(IActorRepo actorRepo,IMovieRepo movieRepo)
        {
            this.actorRepo = actorRepo;
            this.movieRepo = movieRepo;
        }

        /// <summary>
        /// Add a new Movie.
        /// </summary>
        /// <param name="movieModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddMovie([FromBody]MovieModel movieModel)
        {
            var actorIdList = this.actorRepo.GetActorIdList(movieModel.actors);
            try
            {
                this.movieRepo.AddMovie(movieModel, actorIdList);
            }
            catch(Exception ex)
            {
                return BadRequest("Error Occurred: "+ex.Message);
            }
            return Ok("Movie Added !!");
        }

        /// <summary>
        /// List All Movie
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMovies()
        {
           var movies= this.movieRepo.GetAllMovies();
            return Ok(movies);
        }

        /// <summary>
        /// Get Movie by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetMovieById(int id)
        {
            var movies = this.movieRepo.GetAllMovies().Where(m => m.movieid == id).SingleOrDefault();
            if (movies != null)
                return Ok(movies);
            return NotFound($"Oops!! Movie with  id:{id} not found");
        }

        /// <summary>
        /// Update Movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movieModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id:int}")]
        public IActionResult UpdateMovie(int id, [FromBody] MovieModel movieModel)
        {
            var actorIdList = this.actorRepo.GetActorIdList(movieModel.actors);
            try
            {
                this.movieRepo.UpdateMovie(movieModel, actorIdList,id);
            }
            catch (Exception ex)
            {
                return BadRequest("Error Occurred: " + ex.Message);
            }
            return Ok("Movie Updated SuccessFully !!");

        }
    }
}
