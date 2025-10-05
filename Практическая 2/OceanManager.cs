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

        public Sea FindDeepestSea()
        {
            if (Seas.Count == 0) return null;
            return Seas.OrderByDescending(s => s.Depth).First();
        }

        public Sea FindSaltiestSea()
        {
            if (Seas.Count == 0) return null;
            return Seas.OrderByDescending(s => s.Salinity).First();
        }

        public SeaAnimal FindMostPopulousAnimal()
        {
            if (Animals.Count == 0) return null;
            return Animals.OrderByDescending(a => a.Population).First();
        }

        public List<SeaAnimal> FindAnimalsInSea(string seaName)
        {
            return Animals.Where(a => a.SeaName == seaName).ToList();
        }

        public Island FindLargestIsland()
        {
            if (Islands.Count == 0) return null;
            return Islands.OrderByDescending(i => i.Square).First();
        }

        public List<Island> FindIslandsInSea(string seaName)
        {
            return Islands.Where(i => i.SeaName == seaName).ToList();
        }
    }
}
