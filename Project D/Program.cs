using System;
namespace ProjectD
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            double b = 1;
            double eps = 0.00000001;
            Func<double, double> f = x => Math.Pow(Math.Sin(Math.Pow(x, 2)), 2) * Math.Exp(-x);

            var leftRectangleMethod = new LeftRectangleMethod();
            var result = leftRectangleMethod.Calculate(f, a, b, eps);
            Console.WriteLine(nameof(LeftRectangleMethod) + ": " + result.result + ", Iterations: " + result.iterations + ", Time: " + result.duration);

            var rightRectangleMethod = new RightRectangleMethod();
            result = rightRectangleMethod.Calculate(f, a, b, eps);
            Console.WriteLine(nameof(RightRectangleMethod) + ": " + result.result + ", Iterations: " + result.iterations + ", Time: " + result.duration);

            var middleRectangleMethod = new MiddleRectangleMethod();
            result = middleRectangleMethod.Calculate(f, a, b, eps);
            Console.WriteLine(nameof(MiddleRectangleMethod) + ": " + result.result + ", Iterations: " + result.iterations + ", Time: " + result.duration);

            var trapezoidMethod = new TrapezoidMethod();
            result = trapezoidMethod.Calculate(f, a, b, eps);
            Console.WriteLine(nameof(TrapezoidMethod) + ": " + result.result + ", Iterations: " + result.iterations + ", Time: " + result.duration);

            var simpsonsMethod = new SimpsonsMethod();
            result = simpsonsMethod.Calculate(f, a, b, eps);
            Console.WriteLine(nameof(SimpsonsMethod) + ": " + result.result + ", Iterations: " + result.iterations + ", Time: " + result.duration);
        }
    }
}
/*
Тесты:
[double eps = 0.0000001;]
PS D:\Code\General\Summer C#\Project D> dotnet run
LeftRectangleMethod: 0.07399726790648023, Iterations: 21, Time: 00:00:00.2675410
RightRectangleMethod: 0.07399739211571896, Iterations: 21, Time: 00:00:00.2527891
MiddleRectangleMethod: 0.07399731377723932, Iterations: 10, Time: 00:00:00.0002251
TrapezoidMethod: 0.07399736247879062, Iterations: 10, Time: 00:00:00.0001695
SimpsonsMethod: 0.07399732637605322, Iterations: 5, Time: 00:00:00.0001112
[double eps = 0.00000001;]
PS D:\Code\General\Summer C#\Project D> dotnet run
LeftRectangleMethod: 0.07399732224801113, Iterations: 24, Time: 00:00:02.0324258
RightRectangleMethod: 0.07399733777416598, Iterations: 24, Time: 00:00:02.0351276
MiddleRectangleMethod: 0.0739973289964779, Iterations: 12, Time: 00:00:00.0006334
TrapezoidMethod: 0.07399733204032338, Iterations: 12, Time: 00:00:00.0006411
SimpsonsMethod: 0.07399732978409858, Iterations: 6, Time: 00:00:00.0001428
[double eps = 0.000000001;]
PS D:\Code\General\Summer C#\Project D> dotnet run
LeftRectangleMethod: 0.07399732904069523, Iterations: 27, Time: 00:00:16.4624368
RightRectangleMethod: 0.07399733098146458, Iterations: 27, Time: 00:00:16.1290645
MiddleRectangleMethod: 0.07399732975743935, Iterations: 13, Time: 00:00:00.0010979
TrapezoidMethod: 0.07399733013792012, Iterations: 14, Time: 00:00:00.0022268
SimpsonsMethod: 0.07399732999690906, Iterations: 7, Time: 00:00:00.0001516
*/