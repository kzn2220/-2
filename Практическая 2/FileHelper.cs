using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_2
{
    internal class FileHelper
    {
        public static List<string> ReadFile(string fileName)
        {
            return File.Exists(fileName)
                ? File.ReadAllLines(fileName).ToList()
                : new List<string>();
        }

        public static OceanManager LoadFromFiles()
        {
            var manager = new OceanManager();

            LoadSeasFromFile(manager, "seas.txt");
            LoadAnimalsFromFile(manager, "animals.txt");
            LoadIslandsFromFile(manager, "islands.txt");

            return manager;
        }

        private static void LoadSeasFromFile(OceanManager manager, string fileName)
        {
            var lines = ReadFile(fileName);
            foreach (var line in lines.Where(l => !string.IsNullOrWhiteSpace(l)))
            {
                var sea = ParseSea(line);
                if (sea != null) manager.Seas.Add(sea);
            }
        }

        private static void LoadAnimalsFromFile(OceanManager manager, string fileName)
        {
            var lines = ReadFile(fileName);
            foreach (var line in lines.Where(l => !string.IsNullOrWhiteSpace(l)))
            {
                var animal = ParseAnimal(line);
                if (animal != null) manager.Animals.Add(animal);
            }
        }

        private static void LoadIslandsFromFile(OceanManager manager, string fileName)
        {
            var lines = ReadFile(fileName);
            foreach (var line in lines.Where(l => !string.IsNullOrWhiteSpace(l)))
            {
                var island = ParseIsland(line);
                if (island != null) manager.Islands.Add(island);
            }
        }

        private static Sea ParseSea(string line)
        {
            try
            {
                var parts = line.Split(',');
                return new Sea(parts[0].Trim(), double.Parse(parts[1]), double.Parse(parts[2]));
            }
            catch
            {
                return null;
            }
        }

        private static SeaAnimal ParseAnimal(string line)
        {
            try
            {
                var parts = line.Split(',');
                return new SeaAnimal(parts[0].Trim(), parts[1].Trim(), parts[2].Trim(), int.Parse(parts[3]));
            }
            catch
            {
                return null;
            }
        }

        private static Island ParseIsland(string line)
        {
            try
            {
                var parts = line.Split(',');
                return new Island(parts[0].Trim(), parts[1].Trim(), double.Parse(parts[2]), int.Parse(parts[3]));
            }
            catch
            {
                return null;
            }
        }
    }
}
