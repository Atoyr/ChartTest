using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart
{
    public class Point
    {
        private string pointName;
        private double pointX = 0;
        private double pointY = 0;
        private string labelX = string.Empty;
        private string labelY = string.Empty;

        public string Key
        {
            get { return pointName; }
        }

        public double X
        {
            get { return pointX; }
        }

        public double Y
        {
            get { return pointY; }
        }

        public string LabelX
        {
            set { labelX = value; }
            get { return labelX; }
        }

        public string LabelY
        {
            set { labelY = value; }
            get { return labelY; }
        }

        private Point() { }

        public Point(string key, double x ,double y)
        {
            pointName = key;
            pointX = x;
            pointY = y;
        }

        public static int CompareByX(Point a,Point b)
        {
            double d = a.pointX - b.pointX;
            if (d > 0) return 1;
            if (d < 0) return -1;
            return 0;
        }
        public static int CompareByY(Point a, Point b)
        {
            double d = a.pointY - b.pointY;
            if (d > 0) return 1;
            if (d < 0) return -1;
            return 0;
        }
    }
}
