using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Практическая_2;

namespace TestProject1
{
    [TestClass]
    public class InputProcessorTests
    {
        [TestMethod]
        public void ConvertSea_ValidInput_ReturnsSea()
        {
            //Arrange
            string input = "\"Черное море\" 1000 35 \"Какой-то текст\"";

            //Act
            var result = InputProcessor.ConvertSea(input);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Черное море", result.Name);
            Assert.AreEqual(1000, result.Depth);
            Assert.AreEqual(35, result.Salinity);
        }

        [TestMethod]
        public void ConvertSea_InvalidNumberFormat_ThrowsException()
        {
            //Arrange
            string input = "\"Море\" abc 35 \"Описание\"";

            //Act & Assert
            try
            {
                InputProcessor.ConvertSea(input);
                Assert.Fail("Ожидалось исключение ArgumentException");
            }
            catch (ArgumentException)
            {
                //Тест пройден
            }
        }

        [TestMethod]
        public void ConvertSea_ExtraSpaces_ReturnsSea()
        {
            string input = "  \"Море\"   1000   35   \"Описание\"  ";
            var result = InputProcessor.ConvertSea(input);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ConvertSea_WithoutQuotes_ReturnsSea()
        {
            string input = "Море 1000 35 Описание";

            //Act
            var result = InputProcessor.ConvertSea(input);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Море", result.Name);
            Assert.AreEqual(1000, result.Depth);
        }
    }
}
