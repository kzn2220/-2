using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_2
{
    internal class Sea
    {
        public string Name { get; set; }
        public double Depth { get; set; }
        public double Salinity { get; set; }

        public Sea(string name, double depth, double salinity)
        {
            Name = name;
            Depth = depth;
            Salinity = salinity;
        }

        public string GetInfo()
        {
            return $"{Name}: глубина {Depth} м, солёность {Salinity}%";
        }
    }
}
