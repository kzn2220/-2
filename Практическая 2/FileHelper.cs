using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_2
{
    internal class FileHelper
    {
        /*public static List<string> ReadFile(string fileName)
        {
            return File.Exists(fileName)
                ? File.ReadAllLines(fileName).ToList()
                : new List<string>();
        }

        public static OceanManager LoadFromFiles()
        {
            var seas = new List<Sea>();
            var animals = new List<SeaAnimal>();
            var islands = new List<Island>();

            LoadSeasFromFile(seas, "seas.txt");
            LoadAnimalsFromFile(animals, "animals.txt");
            LoadIslandsFromFile(islands, "islands.txt");

            return new OceanManager(seas, animals, islands);
        }

        private static void LoadSeasFromFile(List<Sea> seas, string fileName)
        {
            var lines = ReadFile(fileName);
            foreach (var line in lines.Where(l => !string.IsNullOrWhiteSpace(l)))
            {
                var sea = ParseSea(line);
                if (sea != null) seas.Add(sea);
            }
        }

        private static void LoadAnimalsFromFile(List<SeaAnimal> animals, string fileName)
        {
            var lines = ReadFile(fileName);
            foreach (var line in lines.Where(l => !string.IsNullOrWhiteSpace(l)))
            {
                var animal = ParseAnimal(line);
                if (animal != null) animals.Add(animal);
            }
        }

        private static void LoadIslandsFromFile(List<Island> islands, string fileName)
        {
            var lines = ReadFile(fileName);
            foreach (var line in lines.Where(l => !string.IsNullOrWhiteSpace(l)))
            {
                var island = ParseIsland(line);
                if (island != null) islands.Add(island);
            }
        }

        private static Sea ParseSea(string line)
        {
            try
            {
                var parts = ParseInputWithQuotes(line);
                return new Sea(parts[0], double.Parse(parts[1]), double.Parse(parts[2]));
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
                var parts = ParseInputWithQuotes(line);
                return new SeaAnimal(parts[0], parts[1], parts[2], int.Parse(parts[3]));
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
                var parts = ParseInputWithQuotes(line);
                return new Island(parts[0], parts[1], double.Parse(parts[2]), int.Parse(parts[3]));
            }
            catch
            {
                return null;
            }
        }

        private static List<string> ParseInputWithQuotes(string input)
        {
            var parts = new List<string>();
            bool inQuotes = false;
            string currentPart = "";

            foreach (char c in input.Trim())
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                    continue;
                }

                if (c == ' ' && !inQuotes)
                {
                    if (!string.IsNullOrEmpty(currentPart))
                    {
                        parts.Add(currentPart);
                        currentPart = "";
                    }
                }
                else
                {
                    currentPart += c;
                }
            }

            if (!string.IsNullOrEmpty(currentPart))
            {
                parts.Add(currentPart);
            }

            return parts;
        }*/


        public static OceanManager LoadFromFile(string filePath = "data.txt")
        {
            var seas = new List<Sea>();
            var animals = new List<SeaAnimal>();
            var islands = new List<Island>();

            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                        continue;

                    try
                    {
                        if (line.StartsWith("SEA:"))
                        {
                            Sea sea = CreateSeaFromString(line);
                            if (sea != null) seas.Add(sea);
                        }
                        else if (line.StartsWith("ANIMAL:"))
                        {
                            SeaAnimal animal = CreateAnimalFromString(line);
                            if (animal != null) animals.Add(animal);
                        }
                        else if (line.StartsWith("ISLAND:"))
                        {
                            Island island = CreateIslandFromString(line);
                            if (island != null) islands.Add(island);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при обработке строки: {line}");
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
            }

            return new OceanManager(seas, animals, islands);
        }

        private static Sea CreateSeaFromString(string line)
        {
            try
            {
                string data = line.Substring(4).Trim();
                var parts = ParseInputWithQuotes(data);

                string name = parts[0];
                double depth = double.Parse(parts[1]);
                double salinity = double.Parse(parts[2]);

                return new Sea(name, depth, salinity);
            }
            catch
            {
                Console.WriteLine($"Ошибка парсинга моря: {line}");
                return null;
            }
        }

        private static SeaAnimal CreateAnimalFromString(string line)
        {
            try
            {
                string data = line.Substring(7).Trim();
                var parts = ParseInputWithQuotes(data);

                string name = parts[0];
                string seaName = parts[1];
                string type = parts[2];
                int population = int.Parse(parts[3]);

                return new SeaAnimal(name, seaName, type, population);
            }
            catch
            {
                Console.WriteLine($"Ошибка парсинга животного: {line}");
                return null;
            }
        }

        private static Island CreateIslandFromString(string line)
        {
            try
            {
                string data = line.Substring(7).Trim();
                var parts = ParseInputWithQuotes(data);

                string name = parts[0];
                string seaName = parts[1];
                double area = double.Parse(parts[2]);
                int population = int.Parse(parts[3]);

                return new Island(name, seaName, area, population);
            }
            catch
            {
                Console.WriteLine($"Ошибка парсинга острова: {line}");
                return null;
            }
        }

        private static List<string> ParseInputWithQuotes(string input)
        {
            var parts = new List<string>();
            bool inQuotes = false;
            string currentPart = "";

            foreach (char c in input.Trim())
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                    continue;
                }

                if (c == ' ' && !inQuotes)
                {
                    if (!string.IsNullOrEmpty(currentPart))
                    {
                        parts.Add(currentPart);
                        currentPart = "";
                    }
                }
                else
                {
                    currentPart += c;
                }
            }

            if (!string.IsNullOrEmpty(currentPart))
            {
                parts.Add(currentPart);
            }

            return parts;
        }
    }
}
