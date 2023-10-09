using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using Xunit.Sdk;
using Треугольники;

class TriangleCalculator
{
    private ILogger logger;

    public TriangleCalculator()
    {
        // Инициализация логгера Serilog для записи в файл и консоль
        logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }

    public (string, (int, int)[]) CalculateTriangle(string sideA, string sideB, string sideC)
    {
        logger.Information("Запрос: сторона A = {SideA}, сторона B = {SideB}, сторона C = {SideC}", sideA, sideB, sideC);
        string triangleType = "";
        (int, int)[] vertices = new (int, int)[3];
        double a, b, c;

        if (double.TryParse(sideA, out a) && double.TryParse(sideB, out b) && double.TryParse(sideC, out c))
        {
            try
            {
                // Проверка на неотрицательность сторон
                if (a <= 0 || b <= 0 || c <= 0)
                {
                    logger.Error("Ошибка: одна или несколько сторон имеют недопустимое значение");
                }

                // Проверка на существование треугольника
                if (a + b > c && b + c > a && c + a > b)
                {

                    if (a == b && b == c)
                    {
                        triangleType = "равносторонний";
                    }
                    else if (a == b || b == c || c == a)
                    {
                        triangleType = "равнобедренный";
                    }
                    else
                    {
                        triangleType = "разносторонний";
                    }

                    // Вычисление углов треугольника
                    double alpha = Math.Acos((b * b + c * c - a * a) / (2 * b * c));
                    double beta = Math.Acos((c * c + a * a - b * b) / (2 * c * a));
                    double gamma = Math.PI - alpha - beta;
                    // Вычисление координат вершин треугольника
                    int scalingFactor = 100;
                    vertices[0] = (0, 0);
                    vertices[1] = (scalingFactor, 0);
                    vertices[2] = ((int)(scalingFactor * Math.Cos(alpha)), (int)(scalingFactor * Math.Sin(alpha)));
                    logger.Information(@"Результат: Тип треугольника - {triangleType}, Координаты вершин: A({0},{1}), B({2},{3}), C({4},{5})", triangleType, vertices[0].Item1, vertices[0].Item2, vertices[1].Item1, vertices[1].Item2, vertices[2].Item1, vertices[2].Item2);
                }
                else
                {
                    logger.Error("Ошибка: треугольник с заданными сторонами не существует");
                    return ("Ошибка", new (int, int)[3] { (-2, -2), (-2, -2), (-2, -2) });
                }
            
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка при вычислении треугольника: {ErrorMessage}", ex.Message);
                return ("Ошибка", new (int, int)[3] { (-2, -2), (-2, -2), (-2, -2) });
            }
        }
        else
        {
            logger.Error("Ошибка: невозможно распознать входные данные сторон треугольника");
            return ("Ошибка", new (int, int)[3] { (-2, -2), (-2, -2), (-2, -2) });
        }

        return (triangleType, vertices);
    }
}

class Program
{
    static void Main()
    {
        ILogger logger;
        // Инициализация логгера Serilog для записи в файл и консоль
        logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        string a="";
        string b="";
        string c="";
        var testClass = new TriangleCalculatorTests();
        testClass.Initialize();
        // Вызываем методы тестов
        testClass.CalculateTriangle_EquilateralTriangle_ReturnsCorrectTriangleTypeAndVertices(null);
        testClass.CalculateTriangle_IsoscelesTriangle_ReturnsCorrectTriangleTypeAndVertices();
        testClass.CalculateTriangle_ScaleneTriangle_ReturnsCorrectTriangleTypeAndVertices();
        testClass.CalculateTriangle_InvalidSideValues_ReturnsErrorMessageAndEmptyVertices();
        testClass.CalculateTriangle_NegativeSideValues_ReturnsErrorMessageAndEmptyVertices();
        testClass.CalculateTriangle_InvalidSideFormat_ReturnsErrorMessageAndEmptyVertices();
        testClass.CalculateTriangle_InvalidTriangle_ReturnsNotTriangleMessageAndEmptyVertices();
        testClass.CalculateTriangle_ExceptionThrown_ReturnsErrorMessageAndEmptyVertices();
        testClass.CalculateTriangle_MinimumSideValues_ReturnsNotTriangleMessageAndEmptyVertices();
        testClass.CalculateTriangle_MaximumSideValues_ReturnsErrorMessageAndEmptyVertices();
        testClass.CalculateTriangle_NegativeSideValues_ReturnsNotTriangleMessageAndEmptyVertices();
        testClass.CalculateTriangle_ZeroSideValues_ReturnsNotTriangleMessageAndEmptyVertices();
        testClass.CalculateTriangle_TriangleWithNegativeArea_ReturnsNegativeAreaMessageAndCorrectVertices();
        testClass.CalculateTriangle_TriangleWithZeroArea_ReturnsZeroAreaMessageAndCorrectVertices();
        testClass.CalculateTriangle_TriangleWithMaximumArea_ReturnsMaximumAreaMessageAndCorrectVertices();
        testClass.CalculateTriangle_TriangleWithMinimumArea_ReturnsMinimumAreaMessageAndCorrectVertices();
        testClass.CalculateTriangle_TriangleWithEmptyValues_ReturnsAnErrorMessage();
        testClass.CalculateTriangle_NotTriangle_ReturnsNotTriangleMessageAndEmptyVertices();
        testClass.CalculateTriangle_RightTriangle_ReturnsCorrectTriangleTypeAndVertices();
        testClass.CalculateTriangle_RightTriangle_ReturnsCorrectTriangleTypeAndVertices2();
        testClass.CalculateTriangle_IsoscelesTriangle_ReturnsCorrectTriangleTypeAndVertices2();
    }
}
