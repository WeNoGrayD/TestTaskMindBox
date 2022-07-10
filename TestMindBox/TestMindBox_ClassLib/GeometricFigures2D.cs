using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskMindBox_ClassLib
{
    /// <summary>
    /// Класс многоугольника, который содержит конструктор,
    /// проверяющий входные данные на недостоверность.
    /// </summary>
    public abstract class Polygon : IGeometric2D
    {
        /// <summary>
        /// Стороны многоугольника.
        /// </summary>
        public float[] Sides { get; private set; }

        /// <summary>
        /// Конструктор экземпляра с предоставлением количества сторон и массива их длин.
        /// </summary>
        /// <param name="N"></param>
        /// <param name="sides"></param>
        internal Polygon(byte N, float[] sides)
        {
            if (sides == null)
                throw new ArgumentNullException(nameof(sides));
            if (sides.Length != N)
                throw new ArgumentException("У этого типа многоугольника" +
                    $" должно быть {N} сторон.");
            if (sides.Any(side => side <= 0))
                throw new ArgumentOutOfRangeException(
                    "Стороны многоугольника обязаны быть больше 0.");
            float sidesSum;
            for (int i = 0; i < N; i++)
            {
                sidesSum = 0;
                for (int j = 0; j < N; j++)
                    if (j != i) sidesSum += sides[j];
                if (!sides[i].RoughlyLessThan(sidesSum))
                    throw new ArgumentException("Для существования многоугольника" +
                        " ни одна из его сторон не должна превышать сумму других сторон." +
                        $" Сторона многоугольника с длиной {sides[i]} не удовлетворяет данному" +
                        " правилу.");
            }

            Sides = new float[N];
            sides.CopyTo(Sides, 0);
        }

        public string GetSideEnumerationAsString()
        {
            return string.Join("", Sides.Take(Sides.Length - 1)
                .Select(side => $"{side:f4}, ")) + $"{Sides.Last():f4}";
        }

        public abstract float GetSquare();
    }

    /// <summary>
    /// Класс треугольника.
    /// </summary>
    public class Triangle : Polygon
    {
        /// <summary>
        /// Перегрузка конструктора экземпляра с предоставлением трёх переменных-длин сторон.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public Triangle(float a, float b, float c) : base(3, new float[3] { a, b, c })
        { }

        /// <summary>
        /// Перегрузка конструктора экземпляра с предоставлением массива-длин сторон.
        /// </summary>
        /// <param name="sides"></param>
        public Triangle(float[] sides) : base(3, sides)
        { }

        /// <summary>
        /// Получение сведений о том, является ли треугольник прямоугольным.
        /// </summary>
        /// <returns></returns>
        public bool IsRectangular()
        {
            float hypotenuse = Sides.Max();
            float[] legs = Sides.Where(side => !side.RoughlyEquals(hypotenuse)).ToArray();
            // Треугольник может быть равнобедренным и вытянутым, 
            // тогда две стороны его будут равны (и получится один катет и две 
            // гипотенузы, т.е. максимальных стороны).
            if (legs.Length != 2) return false;
            // Если треугольник не является вытянутым, то проверяется формула Пифагора.
            return (hypotenuse * hypotenuse)
                .RoughlyEquals(legs[0] * legs[0] + legs[1] * legs[1]);
        }

        /// <summary>
        /// Реализация метода получения площади фигуры интерфейса IGeometric2D.
        /// </summary>
        /// <returns></returns>
        public override float GetSquare()
        {
            float p = Sides.Sum() / 2;
            return (float)Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
        }
    }

    /// <summary>
    /// Класс окружности.
    /// </summary>
    public class Circle : IGeometric2D
    {
        /// <summary>
        /// Радиус окружности.
        /// </summary>
        public float Radius { get; private set; }

        /// <summary>
        /// Конструктор экземпляра.
        /// </summary>
        /// <param name="radius"></param>
        public Circle(float radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException("Радиус окружности обязан быть больше 0.");

            Radius = radius;
        }

        /// <summary>
        /// Реализация метода получения площади фигуры интерфейса IGeometric2D.
        /// </summary>
        /// <returns></returns>
        public float GetSquare()
        {
            return (float)(Math.PI * Radius * Radius);
        }
    }
}
