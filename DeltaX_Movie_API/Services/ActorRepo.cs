using DeltaX_Movie_API.DataContext;
using DeltaX_Movie_API.Model;
using DeltaX_Movie_API.Repository;
using DeltaX_Movie_API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX_Movie_API.Services
{
    public class ActorRepo : IActorRepo
    {
        private readonly AppDbContext context;

        public ActorRepo(AppDbContext context)
        {
            this.context = context;

        }

        /// <summary>
        /// Add Actor to db.
        /// </summary>
        /// <param name="actor"></param>
        public void AddActor(Actor actor)
        {
            this.context.actor.Add(actor);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Fetch actor by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Actor GetActorById(int id)
        {
            var actor = this.context.actor.Where(a => a.actorId == id).SingleOrDefault();
            return actor;
        }

        /// <summary>
        /// Get All Actors
        /// </summary>
        /// <returns></returns>
        public List<ActorViewModel> GetActors()
        {
            var actors= this.context.actor.ToList();
            var actormodel = actors.Select(a => new ActorViewModel()
            {
                actorId = a.actorId,
                name = a.name,
                Bio = a.Bio,
                gender = Enum.GetName(typeof(Gender), a.gender),
                DateOfBirth = a.DateOfBirth.ToString("dd/MM/yyyy")
            }).ToList();
            return actormodel;
        }

      
        public List<int> GetActorIdList(List<string> actors)
        {
            var res = new List<int>();
            var actorsList = this.GetActors().ToList();
            foreach (var actorname in actors)
            {
                var actorId = actorsList.Where(a => a.name == actorname).FirstOrDefault().actorId;
                res.Add(actorId);
            }
            return res;
        }
        public List<string> GetActorNameList(List<int> actors)
        {
            var res = new List<string>();
            var actorsList = this.GetActors().ToList();
            foreach (var id in actors)
            {
                var actorId = actorsList.Where(a => a.actorId == id).FirstOrDefault().name;
                res.Add(actorId);
            }
            return res;
        }


    }
}
