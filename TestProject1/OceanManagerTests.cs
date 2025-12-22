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
            var manager = new OceanManager();
            manager.AddEntity(new Sea("Море1", 1000, 35, "Описание1"));
            manager.AddEntity(new Sea("Море2", 2000, 40, "Описание2"));
            manager.AddEntity(new Sea("Море3", 1500, 38, "Описание3"));

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
            var manager = new OceanManager();

            //Act
            var result = manager.FindDeepestSea();

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void FindOldestShip_WithShips_ReturnsOldest()
        {
            //Arrange
            var manager = new OceanManager();
            manager.AddEntity(new Ship("Корабль1", "Море1", "Грузовой", 1990));
            manager.AddEntity(new Ship("Корабль2", "Море2", "Пассажирский", 1980));
            manager.AddEntity(new Ship("Корабль3", "Море3", "Военный", 2000));

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
            var manager = new OceanManager();
            manager.AddEntity(new Sea("Море1", 1000, 35, ""));
            manager.AddEntity(new Sea("Море2", 1000, 40, ""));

            var result = manager.FindDeepestSea();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FindOldestShip_SameYear_ReturnsFirst()
        {
            var manager = new OceanManager();
            manager.AddEntity(new Ship("Корабль1", "Море", "Тип", 2000));
            manager.AddEntity(new Ship("Корабль2", "Море", "Тип", 2000));

            var result = manager.FindOldestShip();
            Assert.IsNotNull(result);
        }
    }
}