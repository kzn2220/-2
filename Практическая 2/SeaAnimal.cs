using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_2
{
    internal class SeaAnimal
    {
        public string Name { get; set; }
        public string SeaName { get; set; }
        public string Type { get; set; }
        public int Population { get; set; }
        public string Description { get; set; }

        public SeaAnimal(string name, string seaName, string type, int population, string description)
        {
            Name = name;
            SeaName = seaName;
            Type = type;
            Population = population;
            Description = description;
        }

        public string GetInfo()
        {
            return $"{Name} ({Type}) в {SeaName}: {Population} особей. \nОписание: {Description}";
        }
    }
}
