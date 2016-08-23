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
namespace Chart
{
    partial class ChartGrid : Control
    {
        private int drawLine()
        {
            drawLine(true, true);
            return 0;
        }

        private int drawLine(bool needHorizontalLineDrawing,bool needVerticalLineDrawing)
        {
            this.lineCanvas.Children.Clear();
            if (needHorizontalLineDrawing) { updateHorizontalLine(); }
            if (needVerticalLineDrawing) { updateVerticalLine(); }
            return 0;
        }


        private int updateHorizontalLine()
        {
            if (isBoldLine)
            {
                // 縦罫線の描画
                for (int i = 0; i < this.backgroundCanvas.ActualHeight; i += this.interval_Horizontal)
                {
                    Line line = new Line()
                    {
                        X1 = 0,
                        Y1 = i,
                        X2 = this.backgroundCanvas.ActualWidth,
                        Y2 = i,
                        StrokeThickness = i % (this.boldLineCount_Horizontal * this.interval_Horizontal) == 0 ? this.boldLineThickness_Horizontal : this.lineThickness_Horizontal,
                        Stroke = i % (this.boldLineCount_Horizontal * this.interval_Horizontal) == 0 ? this.girdBoldLineColor : this.girdLineColor,
                        SnapsToDevicePixels = true,
                    };
                    lineCanvas.Children.Add(line);
                }
            }
            else
            {
                // 縦罫線の描画
                for (int i = 0; i < this.backgroundCanvas.ActualHeight; i += this.interval_Horizontal)
                {
                    Line line = new Line()
                    {
                        X1 = 0,
                        Y1 = i,
                        X2 = this.backgroundCanvas.ActualWidth,
                        Y2 = i,
                        StrokeThickness = this.lineThickness_Horizontal,
                        Stroke = this.girdLineColor,
                        SnapsToDevicePixels = true,
                    };

                    lineCanvas.Children.Add(line);
                }
            }
            return 0;
        }

        private int updateVerticalLine()
        {
            if (isBoldLine)
            {
                // 縦罫線の描画
                for (int i = 0; i < this.backgroundCanvas.ActualWidth; i += this.interval_Vertical)
                {
                    Line line = new Line()
                    {
                        X1 = i,
                        Y1 = 0,
                        X2 = i,
                        Y2 = this.backgroundCanvas.ActualHeight,
                    };
                    if (i % (this.boldLineCount_Vertical * this.interval_Vertical) == 0)
                    {
                        line.StrokeThickness = this.boldLineThickness_Vertical;
                        line.Stroke = this.girdBoldLineColor;
                    }
                    else
                    {
                        line.StrokeThickness = this.lineThickness_Vertical;
                        line.Stroke = this.girdLineColor;
                    }
                    line.SnapsToDevicePixels = true;

                    lineCanvas.Children.Add(line);
                }
            }
            else
            {
                // 縦罫線の描画
                for (int i = 0; i < this.backgroundCanvas.ActualWidth; i += this.interval_Vertical)
                {
                    Line line = new Line()
                    {
                        X1 = i,
                        Y1 = 0,
                        X2 = i,
                        Y2 = this.backgroundCanvas.ActualHeight,
                    };
                    line.StrokeThickness = this.lineThickness_Vertical;
                    line.Stroke = this.girdLineColor;
                    line.SnapsToDevicePixels = true;

                    lineCanvas.Children.Add(line);
                }
            }
            return 0;
        }

    }
}
