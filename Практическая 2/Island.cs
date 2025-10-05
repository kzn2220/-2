using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_2
{
    internal class Island
    {
        public string Name { get; set; }
        public string SeaName { get; set; }
        public double Square { get; set; }
        public int Population { get; set; }

        public Island(string name, string seaName, double square, int population)
        {
            Name = name;
            SeaName = seaName;
            Square = square;
            Population = population;
        }

        public string GetInfo()
        {
            return $"{Name} в {SeaName}: площадь {Square} кв. км, население {Population} чел.";
        }
    }
}
