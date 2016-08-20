using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart
{
    class Series
    {
        public DataPointCollectoin Points;
        int ChartType;//型について要考察

        public Series()
        {
            Points = new DataPointCollectoin();
        }

        public Point AddXY(double x,double y)
        {
            return Points.AddXY(x, y);
        }

        public Point AddXY(string key,double x, double y)
        {
            return Points.AddXY(key, x, y);
        }

    }
}
