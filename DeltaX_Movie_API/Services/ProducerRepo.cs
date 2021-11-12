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
    public class ProducerRepo : IProducerRepo
    {
        private readonly AppDbContext context;

        public ProducerRepo(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds a Producer in DB
        /// </summary>
        /// <param name="prod"></param>
        public void AddProducer(Producer prod)
        {
            this.context.producers.Add(prod);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Get All Producer
        /// </summary>
        /// <returns></returns>
        public List<ProducerViewModel> GetProducer()
        {
            var prods = this.context.producers.ToList();
            var producersmodel = prods.Select(p => new ProducerViewModel()
            {
                gender = Enum.GetName(typeof(Gender), p.gender),
                DateOfBirth = p.DateOfBirth.ToString("dd/MM/yyyy"),
                producerId = p.producerId,
                Bio = p.Bio,
                company = p.company,
                name = p.name
            }).ToList();
            return producersmodel;
        }

        /// <summary>
        /// Get Producer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Producer GetProducerById(int id)
        {
            var prod = this.context.producers.Where(p => p.producerId == id).FirstOrDefault();
            return prod;
        }
    }
}
