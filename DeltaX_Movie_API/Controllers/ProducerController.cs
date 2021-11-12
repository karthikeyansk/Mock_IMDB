using DeltaX_Movie_API.Model;
using DeltaX_Movie_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DeltaX_Movie_API.Controllers
{
    [Route("api/[controller]")]
    public class ProducerController : Controller
    {
        private readonly IProducerRepo repo;

        public ProducerController(IProducerRepo repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Adds a new producer
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddProducer([FromBody] Producer prod)
        {
            if (!ModelState.IsValid)
                return BadRequest("Error: Bad Request!");
            this.repo.AddProducer(prod);
            return Ok("Success!");
        }


        /// <summary>
        /// List All Producer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListAllProducer()
        {
            var producers = this.repo.GetProducer();
            if (producers.Count == 0)
                return Ok("Producers table is empty");
            return Ok(producers);
        }
    }
}

