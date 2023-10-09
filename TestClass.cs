using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Треугольники
{
    [TestClass]
    public class TriangleCalculatorTests
    {
        private TriangleCalculator calculator;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new TriangleCalculator();
        }

        // Проверка на равносторонний треугольник
        [TestMethod]
        public void CalculateTriangle_EquilateralTriangle_ReturnsCorrectTriangleTypeAndVertices(TestContext testContext)
        {
            string sideA = "5";
            string sideB = "5";
            string sideC = "5";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("равносторонний", result.Item1);
            Assert.AreEqual((0, 0), result.Item2[0]);
            Assert.AreEqual((100, 0), result.Item2[1]);
            Assert.AreEqual((49, 86), result.Item2[2]);
        }//1

        // Проверка на равнобедренный треугольник
        [TestMethod]
        public void CalculateTriangle_IsoscelesTriangle_ReturnsCorrectTriangleTypeAndVertices()
        {
            string sideA = "5";
            string sideB = "5";
            string sideC = "6";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("равнобедренный", result.Item1);
            Assert.AreEqual((0, 0), result.Item2[0]);
            Assert.AreEqual((100, 0), result.Item2[1]);
            Assert.AreEqual((60, 80), result.Item2[2]);
        }//2

        // Проверка на разносторонний треугольник
        [TestMethod]
        public void CalculateTriangle_ScaleneTriangle_ReturnsCorrectTriangleTypeAndVertices()
        {
            string sideA = "3";
            string sideB = "4";
            string sideC = "5";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("разносторонний", result.Item1);
            Assert.AreEqual((0, 0), result.Item2[0]);
            Assert.AreEqual((100, 0), result.Item2[1]);
            Assert.AreEqual((80, 59), result.Item2[2]);
        }//3

        // Проверка на некорректные данные сторон треугольника
        [TestMethod]
        public void CalculateTriangle_InvalidSideValues_ReturnsErrorMessageAndEmptyVertices()
        {
            string sideA = "0";
            string sideB = "-5";
            string sideC = "7";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("Ошибка", result.Item1);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }//4

        // Проверка на отрицательные данные сторон треугольника
        [TestMethod]
        public void CalculateTriangle_NegativeSideValues_ReturnsErrorMessageAndEmptyVertices()
        {
            string sideA = "-3";
            string sideB = "-4";
            string sideC = "-5";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("Ошибка", result.Item1);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }//5

        // Проверка на некорректный формат данных сторон треугольника
        [TestMethod]
        public void CalculateTriangle_InvalidSideFormat_ReturnsErrorMessageAndEmptyVertices()
        {
            string sideA = "5.5";
            string sideB = "abc";
            string sideC = "10";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("Ошибка", result.Item1);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }//6

        // Проверка на невозможность построения треугольника
        [TestMethod]
        public void CalculateTriangle_InvalidTriangle_ReturnsNotTriangleMessageAndEmptyVertices()
        {
            string sideA = "1";
            string sideB = "2";
            string sideC = "3";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("Ошибка", result.Item1);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }//7

        // Проверка на обработку исключений при вычислении треугольника
        [TestMethod]
        public void CalculateTriangle_ExceptionThrown_ReturnsErrorMessageAndEmptyVertices()
        {
            string sideA = "30";
            string sideB = "40";
            string sideC = "50";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("разносторонний", result.Item1);
            Assert.AreEqual((0, 0), result.Item2[0]);
            Assert.AreEqual((100, 0), result.Item2[1]);
            Assert.AreEqual((80, 59), result.Item2[2]);
        }//8

        // Проверка на минимальное значение сторон треугольника
        [TestMethod]
        public void CalculateTriangle_MinimumSideValues_ReturnsNotTriangleMessageAndEmptyVertices()
        {
            string sideA = "0,1";
            string sideB = "0,1";
            string sideC = "0,1";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("равносторонний", result.Item1);
            Assert.AreEqual((0, 0), result.Item2[0]);
            Assert.AreEqual((100, 0), result.Item2[1]);
            Assert.AreEqual((49, 86), result.Item2[2]);
        }//9

        // Проверка на максимальное значение сторон треугольника
        [TestMethod]
        public void CalculateTriangle_MaximumSideValues_ReturnsErrorMessageAndEmptyVertices()
        {
            string sideA = "1e100";
            string sideB = "1e100";
            string sideC = "1e100";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("равносторонний", result.Item1);
            Assert.AreEqual((0, 0), result.Item2[0]);
            Assert.AreEqual((100, 0), result.Item2[1]);
            Assert.AreEqual((49, 86), result.Item2[2]);
        }//10
        // Проверка на некорректные значения сторон треугольника (отрицательные значения)
        [TestMethod]
        public void CalculateTriangle_NegativeSideValues_ReturnsNotTriangleMessageAndEmptyVertices()
        {
            string sideA = "-2";
            string sideB = "-3";
            string sideC = "-4";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("Ошибка", result.Item1);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }//11

        // Проверка на нулевые значения сторон треугольника
        [TestMethod]
        public void CalculateTriangle_ZeroSideValues_ReturnsNotTriangleMessageAndEmptyVertices()
        {
            string sideA = "0";
            string sideB = "0";
            string sideC = "0";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("Ошибка", result.Item1);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }//12
        // Проверка на треугольник с отрицательной площадью
        [TestMethod]
        public void CalculateTriangle_TriangleWithNegativeArea_ReturnsNegativeAreaMessageAndCorrectVertices()
        {
            string sideA = "3";
            string sideB = "4";
            string sideC = "10";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("Ошибка", result.Item1);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }//13

        // Проверка на треугольник с нулевой площадью
        [TestMethod]
        public void CalculateTriangle_TriangleWithZeroArea_ReturnsZeroAreaMessageAndCorrectVertices()
        {
            string sideA = "1";
            string sideB = "2";
            string sideC = "3";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("Ошибка", result.Item1);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }//14

        // Проверка на треугольник с максимальной площадью
        [TestMethod]
        public void CalculateTriangle_TriangleWithMaximumArea_ReturnsMaximumAreaMessageAndCorrectVertices()
        {
            string sideA = "100";
            string sideB = "100";
            string sideC = "141.421";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("Ошибка", result.Item1);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }//15

        // Проверка на треугольник с минимальной площадью
        [TestMethod]
        public void CalculateTriangle_TriangleWithMinimumArea_ReturnsMinimumAreaMessageAndCorrectVertices()
        {
            string sideA = "1";
            string sideB = "1";
            string sideC = "1.414";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("Ошибка", result.Item1);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }//16
        // Проверка на пустые значения сторон

        [TestMethod]
        public void CalculateTriangle_TriangleWithEmptyValues_ReturnsAnErrorMessage()
        {
            string sideA = "";
            string sideB = "";
            string sideC = "";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("Ошибка", result.Item1);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);

        }//17
         // Проверка на треугольник со сторонами (3, 4, 7)
        [TestMethod]
        public void CalculateTriangle_NotTriangle_ReturnsNotTriangleMessageAndEmptyVertices()
        {
            string sideA = "3";
            string sideB = "4";
            string sideC = "7";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("Ошибка", result.Item1);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -2), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }//18

        // Проверка на треугольник со сторонами (8, 15, 17)
        [TestMethod]
        public void CalculateTriangle_RightTriangle_ReturnsCorrectTriangleTypeAndVertices()
        {
            string sideA = "8";
            string sideB = "15";
            string sideC = "17";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("разносторонний", result.Item1);
            Assert.AreEqual((0, 0), result.Item2[0]);
            Assert.AreEqual((100, 0), result.Item2[1]);
            Assert.AreEqual((88, 47), result.Item2[2]);
        }//19

        // Проверка на треугольник со сторонами (5, 12, 13)
        [TestMethod]
        public void CalculateTriangle_RightTriangle_ReturnsCorrectTriangleTypeAndVertices2()
        {
            string sideA = "5";
            string sideB = "12";
            string sideC = "13";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("разносторонний", result.Item1);
            Assert.AreEqual((0, 0), result.Item2[0]);
            Assert.AreEqual((100, 0), result.Item2[1]);
            Assert.AreEqual((92, 38), result.Item2[2]);
        }//20
        // Проверка на треугольник со сторонами (10, 10, 14)
        [TestMethod]
        public void CalculateTriangle_IsoscelesTriangle_ReturnsCorrectTriangleTypeAndVertices2()
        {
            string sideA = "10";
            string sideB = "10";
            string sideC = "14";
            var result = calculator.CalculateTriangle(sideA, sideB, sideC);
            Assert.AreEqual("равнобедренный", result.Item1);
            Assert.AreEqual((0, 0), result.Item2[0]);
            Assert.AreEqual((100, 0), result.Item2[1]);
            Assert.AreEqual((70, 71), result.Item2[2]);
        }//21
    }
}
