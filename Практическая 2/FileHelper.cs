using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_2
{
    public class FileHelper
    {
        public static OceanManager LoadFromFile(string filePath = "data.txt")
        {
            var manager = new OceanManager();

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
                            if (sea != null) manager.AddEntity(sea);
                        }
                        else if (line.StartsWith("ANIMAL:"))
                        {
                            SeaAnimal animal = CreateAnimalFromString(line);
                            if (animal != null) manager.AddEntity(animal);
                        }
                        else if (line.StartsWith("ISLAND:"))
                        {
                            Island island = CreateIslandFromString(line);
                            if (island != null) manager.AddEntity(island);
                        }
                        else if (line.StartsWith("SHIP:"))
                        {
                            Ship ship = CreateShipFromString(line);
                            if (ship != null) manager.AddEntity(ship);
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

            return manager;
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
    }
}
