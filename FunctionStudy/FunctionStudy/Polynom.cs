using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FunctionStudy
{
    class Polynom
    {
        private int bigPower;
        private double[] prefix;

        // Constructor
        public Polynom(double[] prefix)
        {
            this.bigPower = prefix.Length - 1;
            this.prefix = prefix;
        }

        public Polynom CalcDerivative()
        {
            List<double> newPrefixList = new List<double>();

            for (int i = 0; i < prefix.Length - 1; i++)
            {
                newPrefixList.Add(prefix[i] * (bigPower - i));
            }

            return new Polynom(newPrefixList.ToArray());
        }

        public double FindY(double x)
        {
            double y = 0;

            for (int i = 0; i < prefix.Length-1; i++)
            {
                y += Math.Pow(x, (prefix.Length-1) - i) * prefix[i];
                    
            }

            y = y + prefix[prefix.Length - 1];

            return y;
        }

        public List<Point> FindCutPoints(Section s)
        {
            List<Point> cutPoints = new List<Point>();

            if (bigPower == 1)
            {
                double x = prefix[1] * (-1) / prefix[0];
                double y = FindY(x);

                cutPoints.Add(new Point(x, y));
            }
            else
            {
                List<Point> extremePoints = FindExtPoints(s);

                extremePoints.Insert(0, new Point(s.Left, FindY(s.Left)));
                extremePoints.Add(new Point(s.Right, FindY(s.Right)));

                for (int i = 0; i < extremePoints.Count - 1; i++)
                {
                    double left = extremePoints[i].X;
                    double right = extremePoints[i + 1].X;

                    double result = FindY(left) * FindY(right);

                    if (result < 0)
                    {
                        Random random = new Random();
                        double x = random.NextDouble() * (right - left) + left;

                        cutPoints.Add(NewtonRaphson(x));
                    }
                }
            }

            return cutPoints;
        }

        private Point NewtonRaphson(double x)
        {
            double y = FindY(x);
            Point point = new Point(x, y);

            if (y <= 0.0001)
            {
                return point;
            }

            Polynom derivative = CalcDerivative();

            return NewtonRaphson(FindY(x) / derivative.FindY(x));
        }

        public List<Point> FindExtPoints(Section s)
        {
            Polynom derivative = CalcDerivative();
            List<Point> extremePoints = derivative.FindCutPoints(s);

            foreach (Point point in extremePoints)
            {
                point.Y = FindY(point.X);
            }

            return extremePoints;
        }
    }
}
