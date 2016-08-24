using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class DataPointCollectoin : System.Collections.IEnumerable
    {
        List<DataPoint> dataPoint;
        int keyNum = 0;

        public DataPointCollectoin()
        {
            dataPoint = new List<DataPoint>();
        }

        public Object this[string key]
        {
            get {
                //return dataPoint.Find(x => x.Key.Contains(key));
                return this.Find(key);
            }
        }

        public Object this[double x,double y]
        {
            get
            {
                //return dataPoint.Find(x => x.Key.Contains(key));
                return AddXY(x, y);
            }
        }

        public DataPoint Find(string key)
        {
            return dataPoint.Find(x => x.Key.Contains(key));
        }
        
        public DataPoint AddXY(double x,double y)
        {
            return this.AddXY(keyNum++.ToString(), x, y);
        }
        
        public DataPoint AddXY(string key,double x,double y)
        {
            if (Find(key) != null)
            {
                // 返すのはExceptionでもいいかも？？？
                return null;
            }else { 
                DataPoint p = new DataPoint(key, x, y);
                p.LabelX = x.ToString("#.##");
                p.LabelY = y.ToString("#.##");
                dataPoint.Add(p);
                return p;
            }
        }

        public void Sort(IComparer<DataPoint> comparer)
        {
            dataPoint.Sort(comparer);
        }

        public void Sort_X()
        {
            dataPoint.Sort(DataPoint.CompareByX);
        }

        public void Sort_Y()
        {
            dataPoint.Sort(DataPoint.CompareByY);
        }

        public IEnumerator GetEnumerator()
        {
            return dataPoint.GetEnumerator();
        }

        public DataPoint GetMaxPoint(Comparison<DataPoint> comparer)
        {
            DataPoint maxPoint = null;

            foreach(DataPoint p in dataPoint)
            {
                if (maxPoint != null )
                {
                    maxPoint = comparer(maxPoint,p) < 1 ? p : maxPoint;
                }
                else
                {
                    maxPoint = p;
                }
            }
            return maxPoint;
        }

        public DataPoint GetMinPoint(Comparison<DataPoint> comparer)
        {
            DataPoint maxPoint = null;

            foreach (DataPoint p in dataPoint)
            {
                if (maxPoint != null)
                {
                    maxPoint = comparer(p, maxPoint) < 1 ? p : maxPoint;
                }
                else
                {
                    maxPoint = p;
                }
            }
            return maxPoint;
        }


        public DataPoint GetMaxPoint_X()
        {
            return GetMaxPoint(DataPoint.CompareByX);
        }

        public DataPoint GetMaxPoint_Y()
        {
            return GetMaxPoint(DataPoint.CompareByY);
        }

    }


}
