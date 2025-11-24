using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_2
{
    public static class Validators
    {
        public static void ValidateSea(string name, double depth, double salinity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название моря не может быть пустым");

            if (depth <= 0)
                throw new ArgumentException("Глубина моря должна быть положительной");

            if (salinity < 0 || salinity > 100)
                throw new ArgumentException("Солёность должна быть в диапазоне 0-100%");
        }

        public static void ValidateAnimal(string name, string seaName, string type, int population)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название животного не может быть пустым");

            if (string.IsNullOrWhiteSpace(seaName))
                throw new ArgumentException("Название моря для животного не может быть пустым");

            if (population < 0)
                throw new ArgumentException("Популяция не может быть отрицательной");
        }

        public static void ValidateIsland(string name, string seaName, double area, int population)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название острова не может быть пустым");

            if (area <= 0)
                throw new ArgumentException("Площадь острова должна быть положительной");

            if (population < 0)
                throw new ArgumentException("Население не может быть отрицательным");
        }

        public static void ValidateShip(string name, string seaName, string type, int yearBuilt)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название корабля не может быть пустым");

            if (yearBuilt <= 1000 || yearBuilt >= 2025)
                throw new ArgumentException($"Год постройки должен быть в диапазоне 1000-2025");
        }
    }
}
