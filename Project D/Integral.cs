using System;
using System.Diagnostics;
namespace ProjectD
{
    public interface IIntegralSolver
    {
        (double result, int iterations, TimeSpan duration) Calculate(Func<double,double> f,double a,double b,double eps);
    }

    public static class Utils
    {
        public static double Sum(int start,int end,Func<int,double> term)
        {
            double sum = 0;
            for(int i=start;i<=end;i++)
                sum += term(i);
            return sum;
        }
    }

    public class LeftRectangleMethod : IIntegralSolver
    {
        public (double result, int iterations, TimeSpan duration) Calculate(Func<double,double> f,double a,double b,double eps)
        {
            var stopwatch = Stopwatch.StartNew();
            int n = 1;
            double h = (b - a) / n;
            double I1 = h * Utils.Sum(0,n-1,i => f(a + i * h));
            n *= 2;
            h = (b - a) / n;
            double I2 = h * Utils.Sum(0,n-1,i => f(a + i * h));
            int iterations = 1;
            while(Math.Abs(I1 - I2) > eps)
            {
                n *= 2;
                h = (b - a) / n;
                I1 = I2;
                I2 = h * Utils.Sum(0,n-1,i => f(a + i * h));
                iterations++;
            }
            stopwatch.Stop();
            return (I2, iterations, stopwatch.Elapsed);
        }
    }

    public class RightRectangleMethod : IIntegralSolver
    {
        public (double result, int iterations, TimeSpan duration) Calculate(Func<double,double> f,double a,double b,double eps)
        {
            var stopwatch = Stopwatch.StartNew();
            int n = 1;
            double h = (b - a) / n;
            double I1 = h * Utils.Sum(1,n,i => f(a + i * h));
            n *= 2;
            h = (b - a) / n;
            double I2 = h * Utils.Sum(1,n,i => f(a + i * h));
            int iterations = 1;
            while(Math.Abs(I1 - I2) > eps)
            {
                n *= 2;
                h = (b - a) / n;
                I1 = I2;
                I2 = h * Utils.Sum(1,n,i => f(a + i * h));
                iterations++;
            }
            stopwatch.Stop();
            return (I2, iterations, stopwatch.Elapsed);
        }
    }

    public class MiddleRectangleMethod : IIntegralSolver
    {
        public (double result, int iterations, TimeSpan duration) Calculate(Func<double,double> f,double a,double b,double eps)
        {
            var stopwatch = Stopwatch.StartNew();
            int n = 1;
            double h = (b - a) / n;
            double I1 = h * Utils.Sum(0,n-1,i => f(a + (i+0.5) * h));
            n *= 2;
            h = (b - a) / n;
            double I2 = h * Utils.Sum(0,n-1,i => f(a + (i+0.5) * h));
            int iterations = 1;
            while(Math.Abs(I1 - I2) > eps)
            {
                n *= 2;
                h = (b - a) / n;
                I1 = I2;
                I2 = h * Utils.Sum(0,n-1,i => f(a + (i+0.5) * h));
                iterations++;
            }
            stopwatch.Stop();
            return (I2, iterations, stopwatch.Elapsed);
        }
    }
    public class TrapezoidMethod : IIntegralSolver
    {
        public (double result, int iterations, TimeSpan duration) Calculate(Func<double,double> f,double a,double b,double eps)
        {
            var stopwatch = Stopwatch.StartNew();
            int n = 1;
            double h = (b - a) / n;
            double I1 = h * (f(a)/2 + Utils.Sum(1,n-1,i => f(a + i * h)) + f(b)/2);
            n *= 2;
            h = (b - a) / n;
            double I2 = h * (f(a)/2 + Utils.Sum(1,n-1,i => f(a + i * h)) + f(b)/2);
            int iterations = 1;
            while(Math.Abs(I1 - I2) > eps)
            {
                n *= 2;
                h = (b - a) / n;
                I1 = I2;
                I2 = h * (f(a)/2 + Utils.Sum(1,n-1,i => f(a + i * h)) + f(b)/2);
                iterations++;
            }
            stopwatch.Stop();
            return (I2, iterations, stopwatch.Elapsed);
        }
    }

    public class SimpsonsMethod : IIntegralSolver
    {
        public (double result, int iterations, TimeSpan duration) Calculate(Func<double,double> f,double a,double b,double eps)
        {
            var stopwatch = Stopwatch.StartNew();
            int n = 2;
            double h = (b - a) / n;
            double I1 = h/3 * (f(a) + 4*Utils.Sum(1,n/2,i => f(a + (2*i-1)*h)) + 2*Utils.Sum(1,n/2-1,i => f(a + 2*i*h)) + f(b));
            n *= 2;
            h = (b - a) / n;
            double I2 = h/3 * (f(a) + 4*Utils.Sum(1,n/2,i => f(a + (2*i-1)*h)) + 2*Utils.Sum(1,n/2-1,i => f(a + 2*i*h)) + f(b));
            int iterations = 1;
            while(Math.Abs(I1 - I2) > eps)
            {
                n *= 2;
                h = (b - a) / n;
                I1 = I2;
                I2 = h/3 * (f(a) + 4*Utils.Sum(1,n/2,i => f(a + (2*i-1)*h)) + 2*Utils.Sum(1,n/2-1,i => f(a + 2*i*h)) + f(b));
                iterations++;
            }
            stopwatch.Stop();
            return (I2, iterations, stopwatch.Elapsed);
        }
    }
}