using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Control
{
    public partial class Chart
    {
        public void ApplySizeChange()
        {
            ApplyChartCanvasSizeChange();
            ApplyGridCanvasSizeChange();
            ApplyBackgroundCanvasSizeChange();
        }

        public void ApplyChartCanvasSizeChange()
        {
            if (chartCanvas != null && baseGrid != null)
            {
                chartCanvas.Width = baseGrid.ColumnDefinitions[1].ActualWidth;
                chartCanvas.Height = baseGrid.RowDefinitions[1].ActualHeight;
            }
        }

        public void ApplyGridCanvasSizeChange()
        {
            if (gridCanvas != null && baseGrid != null)
            {
                gridCanvas.Width = baseGrid.ColumnDefinitions[1].ActualWidth;
                gridCanvas.Height = baseGrid.RowDefinitions[1].ActualHeight;
            }
        }

        public void ApplyBackgroundCanvasSizeChange()
        {
            if (backgroundCanvas != null && baseGrid != null)
            {
                backgroundCanvas.Width = baseGrid.ColumnDefinitions[1].ActualWidth;
                backgroundCanvas.Height = baseGrid.RowDefinitions[1].ActualHeight;
            }
        }

        public int ApplyBackground()
        {
            if (this.gridBackgroundColor != null && chartCanvas != null)
            {
                backgroundCanvas.Background = this.gridBackgroundColor;
                return 0;
            }
            return -1;
        }

        public int ApplyClip()
        {
            Rect gridCanvasRect = new Rect(0, 0, gridCanvas.ActualWidth, gridCanvas.ActualHeight);
            gridCanvas.Clip = new RectangleGeometry() { Rect = gridCanvasRect, RadiusX = 0, RadiusY = 0 };

            Rect chartCanvasRect = new Rect(0, 0, chartCanvas.ActualWidth, chartCanvas.ActualHeight);
            chartCanvas.Clip = new RectangleGeometry() { Rect = chartCanvasRect, RadiusX = 0, RadiusY = 0 };

            return 0;
        }
    }
}
