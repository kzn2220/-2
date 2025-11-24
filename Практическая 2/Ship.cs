using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Практическая_2
{
    public class Ship
    {
        public string Name { get; set; }
        public string SeaName { get; set; }
        public string Type { get; set; }
        public int YearBuilt { get; set; }

        public Ship(string name, string seaName, string type, int yearBuilt)
        {
            Validators.ValidateShip(name, seaName, type, yearBuilt);

            Name = name;
            SeaName = seaName;
            Type = type;
            YearBuilt = yearBuilt;
        }

        public string GetInfo()
        {
            return $"{Name} ({Type}) в {SeaName}, год постройки: {YearBuilt}";
        }
    }
}
