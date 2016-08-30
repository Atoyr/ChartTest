using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Control
{
    partial class Chart
    {
        #region 既存のコントロールイベント関連
        private void addInitalizedEvent()
        {
            if (this.chartCanvas != null) { chartCanvas.Loaded += this.chartCanvas_Loaded; }
            if (this.gridCanvas != null) { gridCanvas.Loaded += this.gridCanvas_Loaded; }
            if (this.backgroundCanvas != null) { backgroundCanvas.Loaded += this.backgroundCanvas_Loaded; }
        }

        private void removeInitalizedEvent()
        {
            if (this.chartCanvas != null) { chartCanvas.Loaded -= this.chartCanvas_Loaded; }
            if (this.gridCanvas != null) { gridCanvas.Loaded -= this.gridCanvas_Loaded; }
            if (this.backgroundCanvas != null) { backgroundCanvas.Loaded -= this.backgroundCanvas_Loaded; }
        }
        #endregion

        #region イベントデリゲート
        public delegate void ChartLoader_EventHandler(object sender, RoutedEventArgs e);
        public delegate void GridLoader_EventHandler(object sender, RoutedEventArgs e);
        public delegate void BackgroundLoader_EventHandler(object sender, RoutedEventArgs e);
        #endregion


        #region 自作イベント       
        public event ChartLoader_EventHandler Chart_Loaded;
        public event GridLoader_EventHandler Grid_Loaded;
        public event BackgroundLoader_EventHandler Background_Loaded;
        #endregion

        #region 自作イベント
        private void chartCanvas_Loaded(object sender,RoutedEventArgs e)
        {
            ApplyChartCanvasSizeChange();
            if (Chart_Loaded != null) {
                Chart_Loaded(sender, e);
            }
        }

        private void gridCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            ApplyGridCanvasSizeChange();
            if (Grid_Loaded != null)
            {
                Grid_Loaded(sender, e);
            }
        }

        private void backgroundCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            ApplyBackgroundCanvasSizeChange();
            if (Background_Loaded != null)
            {
                Background_Loaded(sender, e);
            }
        }
        #endregion
    }
}
