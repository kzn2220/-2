using Практическая_2;

namespace TestProject1
{
    [TestClass]
    public class OceanManagerTests
    {
        [TestMethod]
        public void FindDeepestSea_WithSeas_ReturnsDeepest()
        {
            //Arrange
            var seas = new List<Sea>
        {
            new Sea("Море1", 1000, 35, "Описание1"),
            new Sea("Море2", 2000, 40, "Описание2"),
            new Sea("Море3", 1500, 38, "Описание3")
        };
            var manager = new OceanManager(seas, new List<SeaAnimal>(), new List<Island>(), new List<Ship>());

            //Act
            var result = manager.FindDeepestSea();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Море2", result.Name);
            Assert.AreEqual(2000, result.Depth);
        }

        [TestMethod]
        public void FindDeepestSea_EmptyList_ReturnsNull()
        {
            //Arrange
            var manager = new OceanManager(new List<Sea>(), new List<SeaAnimal>(), new List<Island>(), new List<Ship>());

            //Act
            var result = manager.FindDeepestSea();

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void FindOldestShip_WithShips_ReturnsOldest()
        {
            //Arrange
            var ships = new List<Ship>
        {
            new Ship("Корабль1", "Море1", "Грузовой", 1990),
            new Ship("Корабль2", "Море2", "Пассажирский", 1980),
            new Ship("Корабль3", "Море3", "Военный", 2000)
        };
            var manager = new OceanManager(new List<Sea>(), new List<SeaAnimal>(), new List<Island>(), ships);

            //Act
            var result = manager.FindOldestShip();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Корабль2", result.Name);
            Assert.AreEqual(1980, result.YearBuilt);
        }

        [TestMethod]
        public void FindDeepestSea_SameDepth_ReturnsFirst()
        {
            var seas = new List<Sea>
        {
            new Sea("Море1", 1000, 35, ""),
            new Sea("Море2", 1000, 40, "")
        };
            var manager = new OceanManager(seas, null, null, null);

            var result = manager.FindDeepestSea();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FindOldestShip_SameYear_ReturnsFirst()
        {
            var ships = new List<Ship>
        {
            new Ship("Корабль1", "Море", "Тип", 2000),
            new Ship("Корабль2", "Море", "Тип", 2000)
        };
            var manager = new OceanManager(null, null, null, ships);

            var result = manager.FindOldestShip();
            Assert.IsNotNull(result);
        }
    }
}