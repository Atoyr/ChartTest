using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    public class Grid : Control
    {
        private Canvas      grid;
        private Canvas      bgGrid;
        private Grid        baseStackPanel;
        private int         interval_x      = 30;
        private int         interval_y      = 30;
        private bool        isBoldLine      = false;
        private int         boldLineCount_x = 1;
        private int         boldLineCount_y = 1;
        private int         lineSize_x      = 1;
        private int         lineSize_y      = 1;
        private int         boldLineSize_x  = 2;
        private int         boldLineSize_y  = 2;
        private double      bgOpacity       = 1;
        private double      lineOpacity     = 1;


        private Brush gridBgColor           = Brushes.DarkGreen;


        static Grid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Grid)
                , new FrameworkPropertyMetadata(typeof(Grid)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this.baseStackPanel != null)
            {
                baseStackPanel.SizeChanged -= this.Grid_SizeChanged;
            }
            if (this.grid != null)
            {
                grid.Loaded -= this.Grid_SizeChanged;
                //grid.SizeChanged -= this.Grid_SizeChanged;
            }
            grid = this.GetTemplateChild("PART_Grid") as Canvas;
            baseStackPanel = this.GetTemplateChild("PART_BaseStackPanel") as Grid;
            if (this.baseStackPanel != null)
            {
                baseStackPanel.SizeChanged += this.Grid_SizeChanged;
            }
            if (this.grid != null)
            {
                grid.Loaded += this.Grid_SizeChanged;
                //grid.SizeChanged += this.Grid_SizeChanged;
            }

            //this.setBgColor(this.gridBgColor);
            this.setBgColor(null);
            //this.grid.Opacity = bgOpacity;
            //this.grid.Opacity = lineOpacity;

            bgGrid = this.GetTemplateChild("PART_BgGrid") as Canvas;
            bgGrid.Background = Brushes.DarkGreen;
            bgGrid.Opacity = 0.5;
            bgGrid.SizeChanged += this.Grid_SizeChanged;

        }

        private int setBgColor(Brush brush)
        {
            if (brush != null && grid != null)
            {
                grid.Background = brush;
                return 0;
            }

            return -1;
        }

        private void Grid_SizeChanged(object sender ,RoutedEventArgs e)
        {
            // 描画クリア
            grid.Children.Clear();

            if (isBoldLine)
            {
                // 縦罫線の描画
                for (int i = 0; i < grid.ActualWidth; i += interval_x)
                {
                    Line line = new Line()
                    {
                        X1 = i,
                        Y1 = 0,
                        X2 = i,
                        Y2 = grid.ActualHeight,
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

                    grid.Children.Add(line);
                }

                // 横罫線の描画
                // 下を基点として描画する
                for (int i = (int)grid.ActualHeight; i > 0; i -= interval_y)
                {
                    Line line = new Line()
                    {
                        X1 = 0,
                        Y1 = i,
                        X2 = grid.ActualWidth,
                        Y2 = i,
                    };

                    line.StrokeThickness = 1;
                    line.Stroke = Brushes.Red;
                    line.SnapsToDevicePixels = true;
                    line.Opacity = this.lineOpacity;

                    grid.Children.Add(line);
                }
            }
            else
            {
                // 縦罫線の描画
                for (int i = 0; i < grid.ActualWidth; i += interval_x)
                {
                    Line line = new Line()
                    {
                        X1 = i,
                        Y1 = 0,
                        X2 = i,
                        Y2 = grid.ActualHeight,
                    };
                    line.StrokeThickness = this.lineSize_y;
                    line.Stroke = Brushes.Red;
                    line.SnapsToDevicePixels = true;

                    grid.Children.Add(line);
                }

                // 横罫線の描画
                // 下を基点として描画する
                for (int i = (int)grid.ActualHeight; i > 0; i -= interval_y)
                {
                    Line line = new Line()
                    {
                        X1 = 0,
                        Y1 = i,
                        X2 = grid.ActualWidth,
                        Y2 = i,
                    };

                    line.StrokeThickness = this.lineSize_x;
                    line.Stroke = Brushes.Red;
                    line.SnapsToDevicePixels = true;

                    grid.Children.Add(line);
                }
            }
        }
    }
}
