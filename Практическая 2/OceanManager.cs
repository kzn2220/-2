using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_2
{
    internal class OceanManager
    {
        public List<Sea> Seas {  get; set; }
        public List<SeaAnimal> Animals { get; set; }
        public List<Island> Islands { get; set; }
        public List<Ship> Ships { get; set; }

        public OceanManager(List<Sea> seas, List<SeaAnimal> animals, List<Island> islands, List<Ship> ships)
        {
            Seas = seas ?? new List<Sea>();
            Animals = animals ?? new List<SeaAnimal>();
            Islands = islands ?? new List<Island>();
            Ships = ships ?? new List<Ship>();
        }

        public Sea FindDeepestSea()
        {
            if (Seas == null || Seas.Count == 0)
                return null;

            return Seas.OrderByDescending(s => s.Depth).FirstOrDefault();
        }

        public Sea FindSaltiestSea()
        {
            if (Seas == null || Seas.Count == 0)
                return null;

            return Seas.OrderByDescending(s => s.Salinity).FirstOrDefault();
        }

        public SeaAnimal FindMostPopulousAnimal()
        {
            if (Animals == null || Animals.Count == 0)
                return null;

            return Animals.OrderByDescending(a => a.Population).FirstOrDefault();
        }

        public Island FindLargestIsland()
        {
            if (Islands == null || Islands.Count == 0)
                return null;

            return Islands.OrderByDescending(i => i.Square).FirstOrDefault();
        }
        public Ship FindOldestShip()
        {
            if (Ships == null || Ships.Count == 0)
                return null;

            return Ships.OrderBy(s => s.YearBuilt).FirstOrDefault();
        }
    }
}
