using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskMindBox__Tests;
using TestTaskMindBox_ClassLib;

namespace TestTaskMindBox__Main
{
    class Program
    {
        static void Main(string[] args)
        {
            FiguresTests.CircleTest();
            FiguresTests.TriangleTest1_1();
            FiguresTests.TriangleTest1_2();
            FiguresTests.TriangleTest2();
            FiguresTests.TriangleTest3();
            FiguresTests.TriangleTest4();
            Console.ReadKey();
        }
    }
}
