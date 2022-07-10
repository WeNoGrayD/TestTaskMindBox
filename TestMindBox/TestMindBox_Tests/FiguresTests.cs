using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskMindBox_ClassLib;

namespace TestTaskMindBox__Tests
{
    /// <summary>
    /// Класс тестов геометрических фигур.
    /// Дополнительно к тестам ещё выводятся площадь и, для треугольников, прямоугольность.
    /// </summary>
    [TestClass]
    public class FiguresTests
    {
        /// <summary>
        /// Проверка расчёта площади окружности.
        /// </summary>
        [TestMethod]
        public static void CircleTest()
        {
            Console.WriteLine("Окружность с радиусом 4 ед.");

            Circle c1 = new Circle(4);
            float c1Square = Functions.GetFigureSquare(c1);

            Assert.IsTrue(c1Square.RoughlyEquals(50, FloatComparer.ComparersByAccuracy["0.5"]));

            Console.WriteLine("Площадь круга с радиусом 4 ед.:" +
                $" {c1Square}  ед.^2");
        }

        /// <summary>
        /// Проверка создания, расчёта площади и прямоугольности
        /// существующего прямоугольного треугольника (1).
        /// </summary>
        [TestMethod]
        public static void TriangleTest1_1()
        {
            Triangle t1 = new Triangle(4, 5, 3);
            string sides = t1.GetSideEnumerationAsString();
            float t1Square = Functions.GetFigureSquare(t1);
            bool t1IsRectangular = t1.IsRectangular();

            Assert.IsTrue(t1Square.RoughlyEquals(6));
            Assert.IsTrue(t1IsRectangular);

            Console.WriteLine($"Треугольник со сторонами {sides} ед.");
            Console.WriteLine($"Площадь треугольника со сторонами {sides} ед.: " +
                $"{t1Square:f4} ед.^2");
            Console.WriteLine("Является ли прямоугольным треугольник со сторонами " +
                $"{sides} ед.: {t1IsRectangular}");
        }

        /// <summary>
        /// Проверка создания, расчёта площади и прямоугольности
        /// существующего прямоугольного треугольника (2).
        /// </summary>
        [TestMethod]
        public static void TriangleTest1_2()
        {
            Triangle t1 = new Triangle(1, 1, (float)Math.Sqrt(2));
            string sides = t1.GetSideEnumerationAsString();
            float t1Square = Functions.GetFigureSquare(t1);
            bool t1IsRectangular = t1.IsRectangular();

            Assert.IsTrue(t1Square.RoughlyEquals(0.5f));
            Assert.IsTrue(t1IsRectangular);

            Console.WriteLine($"Треугольник со сторонами {sides} ед.");
            Console.WriteLine($"Площадь треугольника со сторонами {sides} ед.: " +
                $"{t1Square:f4} ед.^2");
            Console.WriteLine("Является ли прямоугольным треугольник со сторонами " +
                $"{sides} ед.: {t1IsRectangular}");
        }

        /// <summary>
        /// Проверка равнобедренного вытянутого треугольника на непрямоугольность.
        /// </summary>
        [TestMethod]
        public static void TriangleTest2()
        {
            Triangle t2 = new Triangle(12, 5, 12);
            string sides = t2.GetSideEnumerationAsString();
            float t2Square = Functions.GetFigureSquare(t2);
            bool t2IsRectangular = t2.IsRectangular();

            Assert.IsTrue(t2Square.RoughlyEquals(29, FloatComparer.ComparersByAccuracy["0.5"]));
            Assert.IsFalse(t2IsRectangular);

            Console.WriteLine($"Треугольник со сторонами 12, 5, 12 ед.");
            Console.WriteLine($"Площадь треугольника со сторонами {sides} ед.: " +
                $"{t2Square:f4} ед.^2");
            Console.WriteLine("Является ли прямоугольным треугольник со сторонами " +
                $"{sides} ед.: {t2IsRectangular}");
        }

        /// <summary>
        /// Проверка равностороннего треугольника на непрямоугольность.
        /// </summary>
        [TestMethod]
        public static void TriangleTest3()
        {
            Triangle t3 = new Triangle(7, 7, 7);
            string sides = t3.GetSideEnumerationAsString();
            float t3Square = Functions.GetFigureSquare(t3);
            bool t3IsRectangular = t3.IsRectangular();

            Assert.IsTrue(t3Square.RoughlyEquals(21, FloatComparer.ComparersByAccuracy["0.5"]));
            Assert.IsFalse(t3IsRectangular);

            Console.WriteLine($"Треугольник со сторонами {sides} ед.");
            Console.WriteLine($"Площадь треугольника со сторонами {sides} ед.: " +
                $"{t3Square:f4} ед.^2");
            Console.WriteLine("Является ли прямоугольным треугольник со сторонами " +
                $"{sides} ед.: {t3.IsRectangular()}");
        }

        /// <summary>
        /// Проверка создания несуществующего треугольника.
        /// </summary>
        [TestMethod]
        public static void TriangleTest4()
        {
            try
            {
                Console.WriteLine("Треугольник со сторонами 12, 5, 3 ед.");
                Triangle t4 = new Triangle(12, 5, 3);
                throw new AssertFailedException(
                    "Треугольник с заданными сторонами не должен существовать.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine($"Треугольник не существует:\n {ae.Message}");
            }
        }
    }
}
