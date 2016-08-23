using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Chart
{
    partial class ChartGrid
    {
        public int Chart_Draw()
        {
            chartCanvas.Children.Clear();
            Point beforePoint = null;
            Polyline pline = new Polyline();

            foreach(Point P in this.chart.Series)
            {
                if(beforePoint != null) {
                    //Line line = new Line()
                    //{
                    //    X1 = beforePoint.X,
                    //    Y1 = (beforePoint.Y * 100),
                    //    X2 = P.X,
                    //    Y2 = P.Y * 100
                    //};
                    //line.StrokeThickness = 1;
                    //line.Stroke = Brushes.Red;
                    //line.SnapsToDevicePixels = true;
                    //chartCanvas.Children.Add(line);
                    pline.Points.Add(new System.Windows.Point(P.X, (P.Y * 100 + 200)));
                }
                beforePoint = P;
            }
            pline.Stroke = Brushes.Red;
            pline.StrokeThickness = 2;
            pline.SnapsToDevicePixels = true;
            chartCanvas.Children.Add(pline);
            return 0;
        }

        public int demo()
        {
            for (int i = 0; i < 2048; i++)
            {
                chart.Series.AddXY(i, Math.Sin(i * Math.PI / 180.0) );
            }

            return 0;
        }
    }
}
