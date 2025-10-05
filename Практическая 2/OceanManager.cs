using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_2
{
    internal class OceanManager
    {
        public List<Sea> Seas {  get; set; } = new List<Sea>();
        public List<SeaAnimal> Animals { get; set; } = new List<SeaAnimal>();
        public List<Island> Islands { get; set; } = new List<Island>();
    }
}
