using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX_Movie_API.ViewModel
{
    /// <summary>
    /// Producer View Model
    /// </summary>
    public class ProducerViewModel
    {
        public int producerId { get; set; }
        public string name { get; set; }
        public string Bio { get; set; }
        public string company { get; set; }

        public string DateOfBirth { get; set; }
        public string gender { get; set; }
    }
}
