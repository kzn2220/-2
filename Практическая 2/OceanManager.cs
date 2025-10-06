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
            Seas = seas;
            Animals = animals;
            Islands = islands;
            Ships = ships;
        }

        public Sea FindDeepestSea()
        {
            return Seas.OrderByDescending(s => s.Depth).FirstOrDefault();
        }

        public Sea FindSaltiestSea()
        {
            return Seas.OrderByDescending(s => s.Salinity).FirstOrDefault();
        }

        public SeaAnimal FindMostPopulousAnimal()
        {
            return Animals.OrderByDescending(a => a.Population).FirstOrDefault();
        }

        public Island FindLargestIsland()
        {
            return Islands.OrderByDescending(i => i.Square).FirstOrDefault();
        }

        public Ship FindOldestShip()
        {
            return Ships.OrderBy(s => s.YearBuilt).FirstOrDefault();
        }
    }
}
