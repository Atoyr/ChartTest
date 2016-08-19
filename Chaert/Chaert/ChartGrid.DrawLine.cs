using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace Chaert
{
    partial class ChartGrid : Control
    {
        private int drawLine()
        {
            this.lineCanvas.Children.Clear();
            if (this.isBoldLine)
            {
                // 太線描画時

            }else
            {

            }
            return 0;
        }

        private int updateHorizontalLine()
        {
            if (isBoldLine)
            {
                // 縦罫線の描画
                for (int i = 0; i < backgroundCanvas.ActualWidth; i += interval_x)
                {
                    Line line = new Line()
                    {
                        X1 = i,
                        Y1 = 0,
                        X2 = i,
                        Y2 = backgroundCanvas.ActualHeight,
                    };
                    if (i % (this.boldLineCount_y * interval_x) == 0)
                    {
                        line.StrokeThickness = this.boldLineThickness_y;
                    }
                    else
                    {
                        line.StrokeThickness = this.lineThickness_y;
                    }
                    line.Stroke = Brushes.Red;
                    line.SnapsToDevicePixels = true;

                    lineCanvas.Children.Add(line);
                }
            }

            return 0;
        }

        private int updateverticalLine()
        {
            return 0;
        }

    }
}
