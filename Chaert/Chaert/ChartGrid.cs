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
    public partial class ChartGrid : Control
    {
        // UIオブジェクト
        private Grid baseGrid;
        private Canvas      lineCanvas;
        private Canvas      backgroundCanvas;
        private ScrollBar   horizontalScrollBar;
        private ScrollBar   verticalScrollBar;

        private Canvas firstChart;
        private Canvas secondChart;

        // UIプロパティ
        private int lineThickness_Horizontal = 1;        // X軸描画の線の太さ
        private int lineThickness_Vertical = 1;        // Y軸描画の線の太さ
        private int interval_Horizontal = 30;            // X軸グリッドの間隔
        private int interval_Vertical = 30;            // Y軸グリッドの間隔
        private bool isBoldLine = false;        // 一定カウントで太線描画するか
        private int boldLineCount_Horizontal = 1;        // 太線描画する場合のX軸のカウント数
        private int boldLineCount_Vertical = 1;        // 太線描画する場合のY軸のカウント数
        private int boldLineThickness_Horizontal = 2;    // 太線描画する場合のX軸の線の太さ
        private int boldLineThickness_Vertical = 2;    // 太線描画する場合のY軸の線の太さ
        private double backgroundOpacity = 1;   // 背景色の透明度
        private double lineOpacity = 1;         // 罫線の透明度
        private Brush gridBackgroundColor = Brushes.White; // 背景色
        private Brush girdLineColor = Brushes.Gray;
        private Brush girdBoldLineColor = Brushes.DarkGray;

        static ChartGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChartGrid)
                , new FrameworkPropertyMetadata(typeof(ChartGrid)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
            // イベント削除
            //if (this.backgroundCanvas != null) { backgroundCanvas.SizeChanged -= this.Grid_SizeChanged; }
            if (this.lineCanvas != null) { lineCanvas.SizeChanged -= this.Grid_SizeChanged; }
            //if (this.backgroundCanvas != null) { backgroundCanvas.Loaded -= this.Grid_SizeChanged; }

            // オブジェクト再取得
            baseGrid = this.GetTemplateChild("PART_BaseGrid") as Grid;
            lineCanvas = this.GetTemplateChild("PART_LineCanvas") as Canvas;
            backgroundCanvas = this.GetTemplateChild("PART_BackgroundCanvas") as Canvas;
            horizontalScrollBar = this.GetTemplateChild("PART_HorizontalScrollBar") as ScrollBar;
            verticalScrollBar = this.GetTemplateChild("PART_VerticalScrollBar") as ScrollBar;

            this.init();

            // イベント設定
            //if (this.backgroundCanvas != null) { backgroundCanvas.SizeChanged += this.Grid_SizeChanged; }
            if (this.lineCanvas != null) { lineCanvas.SizeChanged += this.Grid_SizeChanged; }
            //if (this.backgroundCanvas != null) { backgroundCanvas.Loaded += this.Grid_SizeChanged; }

        }

        private void init()
        {
            this.lineCanvas.Background = null;
            this.SetBackgroundColor(this.gridBackgroundColor);
            this.backgroundCanvas.Opacity = this.backgroundOpacity;
        }

        public int SetBackgroundColor(Brush brush)
        {
            if (brush != null && backgroundCanvas != null)
            {
                backgroundCanvas.Background = brush;
                return 0;
            }

            return -1;
        }

        private void Grid_SizeChanged(object sender ,RoutedEventArgs e)
        {
            this.drawLine();
        }
    }
}
