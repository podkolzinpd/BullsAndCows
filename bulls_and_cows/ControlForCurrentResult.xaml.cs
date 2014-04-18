using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bulls_and_cows
{
    /// <summary>
    /// Interaction logic for ControlForCurrentResult.xaml
    /// </summary>
    public partial class ControlForCurrentResult : UserControl
    {
        public static readonly DependencyProperty CurrentNumberProperty = DependencyProperty.Register("CurrentNumber",
            typeof(string), typeof(ControlForCurrentResult),
            new FrameworkPropertyMetadata());
        public string CurrentNumber
        {
            get { return (string)this.GetValue(CurrentNumberProperty); }
            set { this.SetValue(CurrentNumberProperty, value); }
        }

        public static readonly DependencyProperty CountBullProperty = DependencyProperty.Register("CountBull",
            typeof(string), typeof(ControlForCurrentResult),
            new FrameworkPropertyMetadata());
        public string CountBull
        {
            get { return (string)this.GetValue(CountBullProperty); }
            set { this.SetValue(CountBullProperty, value); }
        }

        public static readonly DependencyProperty CountCowProperty = DependencyProperty.Register("CountCow",
            typeof(string), typeof(ControlForCurrentResult),
            new FrameworkPropertyMetadata());
        public string CountCow
        {
            get { return (string)this.GetValue(CountCowProperty); }
            set { this.SetValue(CountCowProperty, value); }
        }

        public static readonly DependencyProperty ColorForBullProperty = DependencyProperty.Register("ColorForBull",
            typeof(Brush), typeof(ControlForCurrentResult),
            new FrameworkPropertyMetadata());
        public Brush ColorForBull
        {
            get { return (Brush)this.GetValue(ColorForBullProperty); }
            set { this.SetValue(ColorForBullProperty, value); }
        }

        public static readonly DependencyProperty ColorForCowProperty = DependencyProperty.Register("ColorForCow",
            typeof(Brush), typeof(ControlForCurrentResult),
            new FrameworkPropertyMetadata());
        public Brush ColorForCow
        {
            get { return (Brush)this.GetValue(ColorForCowProperty); }
            set { this.SetValue(ColorForCowProperty, value); }
        }

        public static readonly DependencyProperty VisibilityImageBullProperty = DependencyProperty.Register("VisibilityImageBull",
            typeof(Visibility), typeof(ControlForCurrentResult),
            new FrameworkPropertyMetadata());
        public Visibility VisibilityImageBull
        {
            get { return (Visibility)this.GetValue(VisibilityImageBullProperty); }
            set { this.SetValue(VisibilityImageBullProperty, value); }
        }

        public static readonly DependencyProperty VisibilityImageCowProperty = DependencyProperty.Register("VisibilityImageCow",
            typeof(Visibility), typeof(ControlForCurrentResult),
            new FrameworkPropertyMetadata());
        public Visibility VisibilityImageCow
        {
            get { return (Visibility)this.GetValue(VisibilityImageCowProperty); }
            set { this.SetValue(VisibilityImageCowProperty, value); }
        }

        public static readonly DependencyProperty HelpImageBullProperty = DependencyProperty.Register("HelpImageBull",
            typeof(string), typeof(ControlForCurrentResult),
            new FrameworkPropertyMetadata());
        public string HelpImageBull
        {
            get { return (string)this.GetValue(HelpImageBullProperty); }
            set { this.SetValue(HelpImageBullProperty, value); }
        }

        public static readonly DependencyProperty HelpImageCowProperty = DependencyProperty.Register("HelpImageCow",
            typeof(string), typeof(ControlForCurrentResult),
            new FrameworkPropertyMetadata());
        public string HelpImageCow
        {
            get { return (string)this.GetValue(HelpImageCowProperty); }
            set { this.SetValue(HelpImageCowProperty, value); }
        }

        public void link(Data d)
        {
            ccCurrentResult.Content = d;
        }

        public void hiding()
        {
            ccCurrentResult.Content = null;
            
            /*if (CountBull == ": 4")
            {
                VisibilityImageBull = Visibility.Hidden;
                VisibilityImageCow = Visibility.Hidden;
            }
            else
            {
                if (VisibilityImageBull != Visibility.Visible)
                {
                    VisibilityImageBull = Visibility.Visible;
                    VisibilityImageCow = Visibility.Visible;
                }
            }*/
        }

        public ControlForCurrentResult()
        {
            /*VisibilityImageBull = Visibility.Hidden;
            VisibilityImageCow = Visibility.Hidden;*/
            

            InitializeComponent();
        }
    }
}
