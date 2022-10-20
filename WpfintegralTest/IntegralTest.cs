using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Wpfintegral;
using Wpfintegral.Clasess;

namespace WpfintegralTest
{
    [TestClass]
    public class IntegralTestTrap
    {
        [TestMethod]
        public void IntagralXXCorrect()
        {
            //Arrange
            double actual = 333333333.333333333;
            double answer;

            //Act
            IntegralCalculateRectangle probe = new IntegralCalculateRectangle();
            answer = probe.Calculate(0, 1000, 100000, (x) => x * x);

            //Assert
            Assert.AreEqual(answer, actual, 0.01);
        }

        [TestMethod]
        public void IntagralXXCorrectSimpson()
        {
            //Arrange
            IntegralCalculateSimpson integral = new IntegralCalculateSimpson();//элемент класса
            double expected = 333333333.333333;//правильный ответ

            //Act
            double actual = integral.Calculate(0, 1000, 1000, (x) => x * x);//считаем интеграл

            //Assert
            Assert.AreEqual(expected, actual, 0.001);//проверяем равны ли числа
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))] // поменяны пределы
        public void TestMethod3()
        {
            IntegralCalculateSimpson integral = new IntegralCalculateSimpson();
            double actual = integral.Calculate(1000, 1, 1, (x) => x * x);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))] // поменяны пределы
        public void TestMethod4()
        {
            IntegralCalculateRectangle integral = new IntegralCalculateRectangle();
            double actual = integral.Calculate(1000, 1, 1, (x) => x * x);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))] // кол-во разбиений= 0
        public void TestMethod5()
        {
            IntegralCalculateRectangle integral = new IntegralCalculateRectangle();
            double actual = integral.Calculate(1000, 1, 0, (x) => x * x);
        }
    }
}
