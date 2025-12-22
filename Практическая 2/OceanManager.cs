using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_2
{
    public class OceanManager
    {
        private readonly List<IOceanEntity> _entities;

        public OceanManager()
        {
            _entities = new List<IOceanEntity>();
        }

        public OceanManager(IEnumerable<IOceanEntity> entities)
        {
            _entities = entities?.ToList() ?? throw new ArgumentNullException(nameof(entities));
        }

        public void AddEntity(IOceanEntity entity)
        {
            _entities.Add(entity ?? throw new ArgumentNullException(nameof(entity)));
        }

        public IEnumerable<Sea> Seas => _entities.OfType<Sea>();
        public IEnumerable<SeaAnimal> Animals => _entities.OfType<SeaAnimal>();
        public IEnumerable<Island> Islands => _entities.OfType<Island>();
        public IEnumerable<Ship> Ships => _entities.OfType<Ship>();

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
