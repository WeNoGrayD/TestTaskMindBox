using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskMindBox_ClassLib
{
    public class Functions
    {
        /// <summary>
        /// Метод получения площади фигуры без знания её конкретного типа.
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public static float GetFigureSquare(IGeometric2D figure)
        {
            return figure.GetSquare();
        }
    }
}
