using DeltaX_Movie_API.Model;
using DeltaX_Movie_API.ViewModel;
using System.Collections.Generic;

namespace DeltaX_Movie_API.Repository
{
    /// <summary>
    /// Producer Repository
    /// </summary>
    public interface IProducerRepo
    {
        void AddProducer(Producer prod);
        List<ProducerViewModel> GetProducer();
        Producer GetProducerById(int id);
    }
}
