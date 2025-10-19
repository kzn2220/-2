using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_2
{
    internal class InputProcessor
    {
        public static Sea ConvertSea(string input)
        {
            try
            {
                var parts = ParseInputWithQuotes(input);
                if (parts.Count < 4)
                    throw new ArgumentException("Недостаточно данных для моря");

                string name = parts[0];
                double depth = SafeParseDouble(parts[1], "глубина");
                double salinity = SafeParseDouble(parts[2], "солёность");
                string description = parts[3];

                return new Sea(name, depth, salinity, description);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ошибка создания моря из строки '{input}': {ex.Message}");
            }
        }

        public static SeaAnimal ConvertAnimal(string input)
        {
            try
            {
                var parts = ParseInputWithQuotes(input);
                if (parts.Count < 5)
                    throw new ArgumentException("Недостаточно данных для животного");

                string name = parts[0];
                string seaName = parts[1];
                string type = parts[2];
                int population = SafeParseInt(parts[3], "популяция");
                string description = parts[4];

                return new SeaAnimal(name, seaName, type, population, description);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ошибка создания животного из строки '{input}': {ex.Message}");
            }
        }

        public static Island ConvertIsland(string input)
        {
            try
            {
                var parts = ParseInputWithQuotes(input);
                if (parts.Count < 5)
                    throw new ArgumentException("Недостаточно данных для острова");

                string name = parts[0];
                string seaName = parts[1];
                double area = SafeParseDouble(parts[2], "площадь");
                int population = SafeParseInt(parts[3], "население");
                string description = parts[4];

                return new Island(name, seaName, area, population, description);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ошибка создания острова из строки '{input}': {ex.Message}");
            }
        }

        public static Ship ConvertShip(string input)
        {
            try
            {
                var parts = ParseInputWithQuotes(input);
                if (parts.Count < 4)
                    throw new ArgumentException("Недостаточно данных для корабля");

                string name = parts[0];
                string seaName = parts[1];
                string type = parts[2];
                int yearBuilt = SafeParseInt(parts[3], "год постройки");

                return new Ship(name, seaName, type, yearBuilt);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ошибка создания корабля из строки '{input}': {ex.Message}");
            }
        }

        private static double SafeParseDouble(string value, string fieldName)
        {
            if (double.TryParse(value.Replace('.', ','), out double result))
                return result;

            throw new ArgumentException($"Некорректное значение для {fieldName}: '{value}'");
        }

        private static int SafeParseInt(string value, string fieldName)
        {
            if (int.TryParse(value, out int result))
                return result;

            throw new ArgumentException($"Некорректное значение для {fieldName}: '{value}'");
        }

        public static List<string> ParseInputWithQuotes(string input)
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
