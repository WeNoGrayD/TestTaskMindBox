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
    /// ����� ������ �������������� �����.
    /// ������������� � ������ ��� ��������� ������� �, ��� �������������, ���������������.
    /// </summary>
    [TestClass]
    public class FiguresTests
    {
        /// <summary>
        /// �������� ������� ������� ����������.
        /// </summary>
        [TestMethod]
        public static void CircleTest()
        {
            Console.WriteLine("���������� � �������� 4 ��.");

            Circle c1 = new Circle(4);
            float c1Square = Functions.GetFigureSquare(c1);

            Assert.IsTrue(c1Square.RoughlyEquals(50, FloatComparer.ComparersByAccuracy["0.5"]));

            Console.WriteLine("������� ����� � �������� 4 ��.:" +
                $" {c1Square}  ��.^2");
        }

        /// <summary>
        /// �������� ��������, ������� ������� � ���������������
        /// ������������� �������������� ������������ (1).
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

            Console.WriteLine($"����������� �� ��������� {sides} ��.");
            Console.WriteLine($"������� ������������ �� ��������� {sides} ��.: " +
                $"{t1Square:f4} ��.^2");
            Console.WriteLine("�������� �� ������������� ����������� �� ��������� " +
                $"{sides} ��.: {t1IsRectangular}");
        }

        /// <summary>
        /// �������� ��������, ������� ������� � ���������������
        /// ������������� �������������� ������������ (2).
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

            Console.WriteLine($"����������� �� ��������� {sides} ��.");
            Console.WriteLine($"������� ������������ �� ��������� {sides} ��.: " +
                $"{t1Square:f4} ��.^2");
            Console.WriteLine("�������� �� ������������� ����������� �� ��������� " +
                $"{sides} ��.: {t1IsRectangular}");
        }

        /// <summary>
        /// �������� ��������������� ���������� ������������ �� �����������������.
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

            Console.WriteLine($"����������� �� ��������� 12, 5, 12 ��.");
            Console.WriteLine($"������� ������������ �� ��������� {sides} ��.: " +
                $"{t2Square:f4} ��.^2");
            Console.WriteLine("�������� �� ������������� ����������� �� ��������� " +
                $"{sides} ��.: {t2IsRectangular}");
        }

        /// <summary>
        /// �������� ��������������� ������������ �� �����������������.
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

            Console.WriteLine($"����������� �� ��������� {sides} ��.");
            Console.WriteLine($"������� ������������ �� ��������� {sides} ��.: " +
                $"{t3Square:f4} ��.^2");
            Console.WriteLine("�������� �� ������������� ����������� �� ��������� " +
                $"{sides} ��.: {t3.IsRectangular()}");
        }

        /// <summary>
        /// �������� �������� ��������������� ������������.
        /// </summary>
        [TestMethod]
        public static void TriangleTest4()
        {
            try
            {
                Console.WriteLine("����������� �� ��������� 12, 5, 3 ��.");
                Triangle t4 = new Triangle(12, 5, 3);
                throw new AssertFailedException(
                    "����������� � ��������� ��������� �� ������ ������������.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine($"����������� �� ����������:\n {ae.Message}");
            }
        }
    }
}
