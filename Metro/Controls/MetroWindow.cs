using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Metro.Controls
{
    public class MetroWindow : Window
    {
        public static readonly DependencyProperty RectangleColorProperty = DependencyProperty.Register("RectangleColor", typeof(Brush), typeof(MetroWindow),
                                                                                                new PropertyMetadata(Brushes.DarkBlue));
        public static readonly DependencyProperty MaxSizeButtonVisibilityProperty = DependencyProperty.Register("MaxSizeButtonVisibility", typeof(Visibility), typeof(MetroWindow), new PropertyMetadata(Visibility.Collapsed));
        public MetroWindow()
        {
            this.DefaultStyleKey = typeof(MetroWindow);
        }

        public Brush RectangleColor
        {
            get { return (Brush)GetValue(RectangleColorProperty); }
            set { SetValue(RectangleColorProperty, value); }
        }

        public Visibility MaxSizeButtonVisibility
        {
            get { return (Visibility)GetValue(MaxSizeButtonVisibilityProperty); }
            set { SetValue(MaxSizeButtonVisibilityProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Border titleBar = this.Template.FindName("PART_TitleBar", this) as Border;
            if (titleBar != null)
                titleBar.MouseDown +=titleBar_MouseDown;

            Button btnMin = this.Template.FindName("PART_BtnMin", this) as Button;
            if (btnMin != null)
                btnMin.Click += btnMin_Click;


            //TextBlock tb = this.Template.FindName("tbBottom", this) as TextBlock;
            //if (tb != null)
            //{
            //    tb.MouseDown += BottomMouseDown;
            //}

            //Button btnMax = this.Template.FindName("PART_BtnMax", this) as Button;
            //if (btnMax != null)
            //{
            //    btnMax.Click += btnMax_Click;
            //    btnMax.Visibility = (this.ResizeMode == ResizeMode.CanResizeWithGrip) ? Visibility.Collapsed : Visibility.Visible; 
            //}

            Button btnClose = this.Template.FindName("PART_BtnClose", this) as Button;
            if (btnClose != null)
                btnClose.Click += btnClose_Click;

            var windowResizeGrip = this.Template.FindName("WindowResizeGrip", this) as UIElement;
            if(windowResizeGrip!=null)
                windowResizeGrip.Visibility = (this.ResizeMode != ResizeMode.NoResize) ? Visibility.Visible : Visibility.Collapsed; 
        }

        void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void btnMax_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //public MouseButtonEventHandler TitleBarMouseDown;
        //public MouseButtonEventHandler BottomMouseDown;

        private void titleBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

    }
}
