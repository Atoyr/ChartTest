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
    /// <summary>
    /// このカスタム コントロールを XAML ファイルで使用するには、手順 1a または 1b の後、手順 2 に従います。
    ///
    /// 手順 1a) 現在のプロジェクトに存在する XAML ファイルでこのカスタム コントロールを使用する場合
    /// この XmlNamespace 属性を使用場所であるマークアップ ファイルのルート要素に
    /// 追加します:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Chaert"
    ///
    ///
    /// 手順 1b) 異なるプロジェクトに存在する XAML ファイルでこのカスタム コントロールを使用する場合
    /// この XmlNamespace 属性を使用場所であるマークアップ ファイルのルート要素に
    /// 追加します:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Chaert;assembly=Chaert"
    ///
    /// また、XAML ファイルのあるプロジェクトからこのプロジェクトへのプロジェクト参照を追加し、
    /// リビルドして、コンパイル エラーを防ぐ必要があります:
    ///
    ///     ソリューション エクスプローラーで対象のプロジェクトを右クリックし、
    ///     [参照の追加] の [プロジェクト] を選択してから、このプロジェクトを参照し、選択します。
    ///
    ///
    /// 手順 2)
    /// コントロールを XAML ファイルで使用します。
    ///
    ///     <MyNamespace:Grid/>
    ///
    /// </summary>
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
        private int lineThickness_x = 1;        // X軸描画の線の太さ
        private int lineThickness_y = 1;        // Y軸描画の線の太さ
        private int interval_x = 30;            // X軸グリッドの間隔
        private int interval_y = 30;            // Y軸グリッドの間隔
        private bool isBoldLine = false;        // 一定カウントで太線描画するか
        private int boldLineCount_x = 1;        // 太線描画する場合のX軸のカウント数
        private int boldLineCount_y = 1;        // 太線描画する場合のY軸のカウント数
        private int boldLineThickness_x = 2;    // 太線描画する場合のX軸の線の太さ
        private int boldLineThickness_y = 2;    // 太線描画する場合のY軸の線の太さ
        private double backgroundOpacity = 1;   // 背景色の透明度
        private double lineOpacity = 1;         // 罫線の透明度
        private Brush gridBackgroundColor = Brushes.DarkGreen; // 背景色

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
            // 描画クリア
            lineCanvas.Children.Clear();
                        
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
                        line.StrokeThickness = 4;
                    }
                    else
                    {
                        line.StrokeThickness = 1;
                    }
                    line.Stroke = Brushes.Red;
                    line.SnapsToDevicePixels = true;

                    lineCanvas.Children.Add(line);
                }

                // 横罫線の描画
                // 下を基点として描画する
                for (int i = (int)backgroundCanvas.ActualHeight; i > 0; i -= interval_y)
                {
                    Line line = new Line()
                    {
                        X1 = 0,
                        Y1 = i,
                        X2 = backgroundCanvas.ActualWidth,
                        Y2 = i,
                    };

                    line.StrokeThickness = 1;
                    line.Stroke = Brushes.Red;
                    line.SnapsToDevicePixels = true;
                    line.Opacity = this.lineOpacity;

                    lineCanvas.Children.Add(line);
                }
            }
            else
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
                    line.StrokeThickness = this.lineThickness_y;
                    line.Stroke = Brushes.Red;
                    line.SnapsToDevicePixels = true;

                    lineCanvas.Children.Add(line);
                }

                // 横罫線の描画
                // 下を基点として描画する
                for (int i = (int)backgroundCanvas.ActualHeight; i > 0; i -= interval_y)
                {
                    Line line = new Line()
                    {
                        X1 = 0,
                        Y1 = i,
                        X2 = backgroundCanvas.ActualWidth,
                        Y2 = i,
                    };

                    line.StrokeThickness = this.lineThickness_x;
                    line.Stroke = Brushes.Red;
                    line.SnapsToDevicePixels = true;

                    lineCanvas.Children.Add(line);
                }
            }
        }
    }
}
