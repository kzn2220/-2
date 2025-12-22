using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_2
{
    public interface IOceanEntity
    {
        string Name { get; }
        string SeaName { get; }
        string GetInfo();
    }
}
