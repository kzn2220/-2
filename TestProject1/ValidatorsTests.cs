using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Практическая_2;

namespace TestProject1
{
    [TestClass]
    public class ValidatorsTests
    {
        [TestMethod]
        public void ValidateSea_ValidData_NoException()
        {
            //Arrange & Act & Assert
            Validators.ValidateSea("Черное море", 1000, 35);
        }

        [TestMethod]
        public void ValidateSea_EmptyName_ThrowsException()
        {
            //Arrange & Act & Assert
            try
            {
                Validators.ValidateSea("", 1000, 35);
                Assert.Fail("Ожидалось исключение ArgumentException");
            }
            catch (ArgumentException)
            {
                //Тест пройден
            }
        }

        [TestMethod]
        public void ValidateSea_WhitespaceName_ThrowsException()
        {
            try
            {
                Validators.ValidateSea("   ", 1000, 35);
                Assert.Fail("Ожидалось исключение");
            }
            catch (ArgumentException) { }
        }

        [TestMethod]
        public void ValidateSea_ZeroSalinity_NoException()
        {
            Validators.ValidateSea("Море", 1000, 0);
        }

        [TestMethod]
        public void ValidateSea_MaxSalinity_NoException()
        {
            Validators.ValidateSea("Море", 1000, 100);
        }

    }
}
