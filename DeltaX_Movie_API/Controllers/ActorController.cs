using DeltaX_Movie_API.Model;
using DeltaX_Movie_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DeltaX_Movie_API.Controllers
{
    [Route("api/[controller]")]
    public class ActorController : Controller
    {
        private readonly IActorRepo repo;

        public ActorController(IActorRepo repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Adds a new actor
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddActor([FromBody]Actor actor)
        {
            if (!ModelState.IsValid)
                return BadRequest("Error: Bad Request!");
            this.repo.AddActor(actor);
            return Ok("Success!");
        }


        /// <summary>
        /// List all Actors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllActors()
        {
            var actors=this.repo.GetActors();
            if (actors.Count == 0)
                return Ok("Actors table is empty");
            return Ok(actors);
        }
    }
}
