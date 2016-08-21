using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart
{
    public class DataPointCollectoin : System.Collections.IEnumerable
    {
        List<Point> dataPoint;
        int keyNum = 0;

        public DataPointCollectoin()
        {
            dataPoint = new List<Point>();
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

        public Point Find(string key)
        {
            return dataPoint.Find(x => x.Key.Contains(key));
        }
        
        public Point AddXY(double x,double y)
        {
            return this.AddXY(keyNum++.ToString(), x, y);
        }
        
        public Point AddXY(string key,double x,double y)
        {
            if (Find(key) != null)
            {
                // 返すのはExceptionでもいいかも？？？
                return null;
            }else { 
                Point p = new Point(key, x, y);
                p.LabelX = x.ToString();//TODO:書式設定
                p.LabelY = y.ToString();
                dataPoint.Add(p);
                return p;
            }
        }

        public void Sort(IComparer<Point> comparer)
        {
            dataPoint.Sort(comparer);
        }

        public void SortX()
        {
            dataPoint.Sort(Point.CompareByX);
        }

        public void SortY()
        {
            dataPoint.Sort(Point.CompareByY);
        }

        public IEnumerator GetEnumerator()
        {
            return dataPoint.GetEnumerator();
        }
    }


}
