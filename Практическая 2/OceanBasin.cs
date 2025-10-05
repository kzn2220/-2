using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_2
{
    internal class OceanBasin
    {
        public List<Sea> Seas { get; set; }

        public OceanBasin(List<Sea> seas)
        {
            Seas = seas;
        }
        public Sea GetDeepestSea()
        {
            return Seas.OrderByDescending(s => s.Depth).FirstOrDefault();
        }

        public Sea GetMostSaltySea()
        {
            return Seas.OrderByDescending(s => s.Salinity).FirstOrDefault();
        }
    }
}
