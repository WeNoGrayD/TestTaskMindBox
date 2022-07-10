using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskMindBox_ClassLib
{
    /// <summary>
    /// Компаратор дробных чисел с установленной точностью.
    /// В принципе, он не особо нужен, но было решено его всё-таки разработать,
    /// поскольку сравнения дробных чисел используются и внутри тестов,
    /// и внутри классов фигур.
    /// </summary>
    public class FloatComparer : IComparer<float>
    {
        public static Dictionary<string, FloatComparer>
            ComparersByAccuracy  { get; private set; } 
            = new Dictionary<string, FloatComparer>
            {
                { "0.01", new FloatComparer() },
                { "0.5", new FloatComparer(0.5f) },
            };

        public const string DefaultAccuracy = "0.01";

        public static readonly FloatComparer Default = ComparersByAccuracy[DefaultAccuracy];

        private float _epsilon = 0.01f;

        public FloatComparer()
        { }

        public FloatComparer(float epsilon)
        {
            _epsilon = epsilon;
        }

        public int Compare(float f1, float f2)
        {
            int f1Sign = f1 >= 0 ? 1 : -1;
            if (f1Sign * Math.Abs(f1 - _epsilon) > f2)
                return 1;
            else
            {
                int f2Sign = f2 >= 0 ? 1 : -1;
                if (f2Sign * Math.Abs(f2 - _epsilon) > f1)
                    return -1;
                else return 0;
            }
        }
    }

    /// <summary>
    /// Класс-помощник для упрощения работы с примерным сравнением дробных чисел.
    /// </summary>
    public static class FloatComparerHelper
    {
        public static bool RoughlyGreaterThan(this float f1, float f2,
            FloatComparer comparer = null)
        {
            comparer = comparer ?? FloatComparer.Default;
            return comparer.Compare(f1, f2) == 1;
        }

        public static bool RoughlyEquals(this float f1, float f2,
            FloatComparer comparer = null)
        {
            comparer = comparer ?? FloatComparer.Default;
            return comparer.Compare(f1, f2) == 0;
        }

        public static bool RoughlyLessThan(this float f1, float f2,
            FloatComparer comparer = null)
        {
            comparer = comparer ?? FloatComparer.Default;
            return comparer.Compare(f1, f2) == -1;
        }
    }
}
