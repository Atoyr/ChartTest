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
            Point beforePoint = null;
            foreach(Point P in this.chart.Series.Points)
            {
                if(beforePoint != null) { 
                    Line line = new Line()
                    {
                        X1 = beforePoint.X,
                        Y1 = (beforePoint.Y * 100) + 360,
                        X2 = P.X,
                        Y2 = P.Y * 100 + 360
                    };
                    line.StrokeThickness = 1;
                    line.Stroke = Brushes.Red;
                    line.SnapsToDevicePixels = true;
                    chartCanvas.Children.Add(line);
                }
                beforePoint = P;
            }
            return 0;
        }

        public int demo()
        {
            for (int i = 0; i < 360; i++)
            {
                chart.Series.AddXY(i, Math.Sin(i * Math.PI / 180.0));
            }

            return 0;
        }
    }
}
