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
