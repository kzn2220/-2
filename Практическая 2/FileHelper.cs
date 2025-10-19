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
                return InputProcessor.ConvertSea(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания моря: {ex.Message}");
                return null;
            }
        }

        private static SeaAnimal CreateAnimalFromString(string line)
        {
            try
            {
                string data = line.Substring(7).Trim();
                return InputProcessor.ConvertAnimal(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания животного: {ex.Message}");
                return null;
            }
        }

        private static Island CreateIslandFromString(string line)
        {
            try
            {
                string data = line.Substring(7).Trim();
                return InputProcessor.ConvertIsland(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания острова: {ex.Message}");
                return null;
            }
        }

        private static Ship CreateShipFromString(string line)
        {
            try
            {
                string data = line.Substring(5).Trim();
                return InputProcessor.ConvertShip(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания корабля: {ex.Message}");
                return null;
            }
        }

        /*private static List<string> ParseInputWithQuotes(string input)
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
    }
}
