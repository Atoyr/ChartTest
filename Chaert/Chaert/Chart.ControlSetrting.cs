using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
