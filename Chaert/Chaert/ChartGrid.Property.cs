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
    partial class ChartGrid :Control
    {
        #region 背景透過プロパティ
        // 背景透過プロパティ
        public static readonly DependencyProperty BackgroundOpacityProperty =
            DependencyProperty.Register(
                "BackgroundOpacity",
                typeof(double),
                typeof(ChartGrid),
                new UIPropertyMetadata(
                    1.0d,
                    // PropertyChangedCallback
                    (d, e) =>
                    {
                        (d as ChartGrid).backgroundOpacity = (double)e.NewValue;
                        // プロパティ変更時の処理
                        // 新しい値をリソースのScaleTransformにセットする
                        if ((d as ChartGrid).backgroundCanvas != null)
                        {
                            (d as ChartGrid).backgroundCanvas.Opacity = (d as ChartGrid).backgroundOpacity;
                        }
                    })
            );
        public double BackgroundOpacity
        {
            get
            {
                return (double)GetValue(BackgroundOpacityProperty);
            }
            set
            {
                SetValue(BackgroundOpacityProperty, (double)value);
            }
        }
        #endregion
        #region 罫線透過プロパティ
        // 罫線透過プロパティ
        public static readonly DependencyProperty LineOpacityProperty =
            DependencyProperty.Register(
                "LineOpacity",
                typeof(double),
                typeof(ChartGrid),
                new UIPropertyMetadata(
                    1.0d,
                    // PropertyChangedCallback
                    (d, e) =>
                    {
                        (d as ChartGrid).lineOpacity = (double)e.NewValue;
                        // プロパティ変更時の処理
                        // 新しい値をリソースのScaleTransformにセットする
                        if ((d as ChartGrid).lineCanvas != null)
                        {
                            (d as ChartGrid).lineCanvas.Opacity = (d as ChartGrid).lineOpacity;
                        }
                    })
            );
        public double LineOpacity
        {
            get
            {
                return (double)GetValue(LineOpacityProperty);
            }
            set
            {
                SetValue(LineOpacityProperty, (double)value);
            }
        }
        #endregion
        #region X軸描画の線の太さプロパティ
        // X軸描画の線の太さ
        public static readonly DependencyProperty LineThickness_xProperty =
            DependencyProperty.Register(
                "LineThickness_x",
                typeof(int),
                typeof(ChartGrid),
                new UIPropertyMetadata(
                    1,
                    // PropertyChangedCallback
                    (d, e) =>
                    {
                        (d as ChartGrid).lineThickness_Horizontal = (int)e.NewValue;
                        // プロパティ変更時の処理
                        // 新しい値をリソースのScaleTransformにセットする
                        if ((d as ChartGrid).lineCanvas != null)
                        {
                            (d as ChartGrid).Grid_SizeChanged(null, null);
                        }
                    })
            );
        public double LineThickness_x
        {
            get
            {
                return (int)GetValue(LineThickness_xProperty);
            }
            set
            {
                SetValue(LineThickness_xProperty, (int)value);
            }
        }
        #endregion
    }
}
