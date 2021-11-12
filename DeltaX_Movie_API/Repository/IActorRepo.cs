using DeltaX_Movie_API.Model;
using DeltaX_Movie_API.ViewModel;
using System.Collections.Generic;

namespace DeltaX_Movie_API.Repository
{
    /// <summary>
    /// Actor Repository
    /// </summary>
    public interface IActorRepo
    {
        void AddActor(Actor actor);
        List<ActorViewModel> GetActors();
        Actor GetActorById(int id);
        List<int> GetActorIdList(List<string> actors);

        List<string> GetActorNameList(List<int> actors);


    }
}
