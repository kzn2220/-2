using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_2
{
    internal class FileHelper
    {
        public static OceanManager LoadFromFile(string filePath = "data.txt")
        {
            var seas = new List<Sea>();
            var animals = new List<SeaAnimal>();
            var islands = new List<Island>();
            var ships = new List<Ship>();

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
                        else if (line.StartsWith("SHIP:"))
                        {
                            Ship ship = CreateShipFromString(line);
                            if (ship != null) ships.Add(ship);
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

            return new OceanManager(seas, animals, islands, ships);
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
                string description = parts[3];

                return new Sea(name, depth, salinity, description);
            }
            catch
            {
                Console.WriteLine($"Ошибка парсинга моря, возможно в дроби введена точка вместо запятой: {line}");
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
                string description = parts[4];

                return new SeaAnimal(name, seaName, type, population, description);
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
                string description = parts[4];

                return new Island(name, seaName, area, population, description);
            }
            catch
            {
                Console.WriteLine($"Ошибка парсинга острова: {line}");
                return null;
            }
        }

        private static Ship CreateShipFromString(string line)
        {
            try
            {
                string data = line.Substring(5).Trim();
                var parts = ParseInputWithQuotes(data);

                string name = parts[0];
                string seaName = parts[1];
                string type = parts[2];
                int yearBuilt = int.Parse(parts[3]);

                return new Ship(name, seaName, type, yearBuilt);
            }
            catch
            {
                Console.WriteLine($"Ошибка парсинга корабля: {line}");
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
