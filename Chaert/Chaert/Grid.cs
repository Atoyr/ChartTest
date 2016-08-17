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
        private Canvas grid;


        static Grid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Grid)
                , new FrameworkPropertyMetadata(typeof(Grid)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if(this.grid != null)
            {
                grid.Loaded -= this.reWrite;
                grid.SizeChanged -= this.reWrite;
            }
            grid = this.GetTemplateChild("PART_Grid") as Canvas;

            if (this.grid != null)
            {
                grid.Loaded += this.reWrite;
                grid.SizeChanged += this.reWrite;
            }

        }

        private void reWrite(object sender ,RoutedEventArgs e)
        {
            grid.Children.Clear();
 
 
 
            for (int i = 0; i< this.ActualWidth; i += 10)
            {
                Line line = new Line()
                {
                    X1 = i,
                    Y1 = 0,
                    X2 = i,
                    Y2 = this.ActualHeight,
                };
                line.StrokeThickness = 1;
                line.Stroke = Brushes.Red;
                line.SnapsToDevicePixels = true;

                grid.Children.Add(line);
            }
 
            for (int i = 0; i< this.ActualHeight; i += 10)
            {
                Line line = new Line()
                {
                    X1 = 0,
                    Y1 = i,
                    X2 = this.ActualWidth,
                    Y2 = i,
                };

                line.StrokeThickness = 1;
                line.Stroke = Brushes.Red;
                line.SnapsToDevicePixels = true;

                grid.Children.Add(line);
            }
        }
    }
}
