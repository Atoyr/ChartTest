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
namespace Control
{
    partial class Chart : System.Windows.Controls.Control
    {
        /// <summary>
        /// 方眼を描画
        /// </summary>
        /// <returns></returns>
        public int DrawGrid()
        {
            DrawGrid(true, true);
            return 0;
        }

        /// <summary>
        /// 方眼を描画
        /// </summary>
        /// <param name="needHorizontalLineDrawing"></param>
        /// <param name="needVerticalLineDrawing"></param>
        /// <returns></returns>
        public int DrawGrid(bool needHorizontalLineDrawing,bool needVerticalLineDrawing)
        {
            this.gridCanvas.Children.Clear();
            if (needHorizontalLineDrawing) { drawHorizontalLine(); }
            if (needVerticalLineDrawing) { drawVerticalLine(); }
            return 0;
        }
        
        /// <summary>
        /// 背景方眼の縦罫線描画
        /// </summary>
        /// <returns></returns>
        private int drawHorizontalLine()
        {
            if (isBoldLine)
            {
                // 縦罫線の描画
                for (int i = 0; i < this.gridCanvas.ActualHeight; i += this.interval_Horizontal)
                {
                    Line line = new Line()
                    {
                        X1 = 0,
                        Y1 = i,
                        X2 = this.gridCanvas.ActualWidth,
                        Y2 = i,
                        StrokeThickness = i % (this.boldLineCount_Horizontal * this.interval_Horizontal) == 0 ? this.boldLineThickness_Horizontal : this.lineThickness_Horizontal,
                        Stroke = i % (this.boldLineCount_Horizontal * this.interval_Horizontal) == 0 ? this.girdBoldLineColor : this.girdLineColor,
                        SnapsToDevicePixels = true,
                    };

                    gridCanvas.Children.Add(line);
                }
            }
            else
            {
                // 縦罫線の描画
                for (int i = 0; i < this.gridCanvas.ActualHeight; i += this.interval_Horizontal)
                {
                    Line line = new Line()
                    {
                        X1 = 0,
                        Y1 = i,
                        X2 = this.gridCanvas.ActualWidth,
                        Y2 = i,
                        StrokeThickness = this.lineThickness_Horizontal,
                        Stroke = this.girdLineColor,
                        SnapsToDevicePixels = true,
                    };

                    gridCanvas.Children.Add(line);
                }
            }
            return 0;
        }

        private int drawVerticalLine()
        {
            if (isBoldLine)
            {
                // 縦罫線の描画
                for (int i = 0; i < this.gridCanvas.ActualWidth; i += this.interval_Vertical)
                {
                    Line line = new Line()
                    {
                        X1 = i,
                        Y1 = 0,
                        X2 = i,
                        Y2 = this.gridCanvas.ActualHeight,
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

                    gridCanvas.Children.Add(line);
                }
            }
            else
            {
                // 縦罫線の描画
                for (int i = 0; i < this.gridCanvas.ActualWidth; i += this.interval_Vertical)
                {
                    Line line = new Line()
                    {
                        X1 = i,
                        Y1 = 0,
                        X2 = i,
                        Y2 = this.gridCanvas.ActualHeight,
                    };
                    line.StrokeThickness = this.lineThickness_Vertical;
                    line.Stroke = this.girdLineColor;
                    line.SnapsToDevicePixels = true;

                    gridCanvas.Children.Add(line);
                }
            }
            return 0;
        }

    }
}
