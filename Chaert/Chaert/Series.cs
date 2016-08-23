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

        public Series()
        {
            Points = new DataPointCollectoin();
        }

        double Max_X;
        double Max_Y;

    }
}
