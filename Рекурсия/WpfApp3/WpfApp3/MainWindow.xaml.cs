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

namespace WpfApp3
{
    
    public partial class MainWindow : Window
    {
        private const int Level = 10;
        private int _width;
        private int _height;
        public MainWindow()
        {
            InitializeComponent();

            _width = (int)fractral2.Width;
            _height = (int)fractral2.Height;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            
      
            Point topPoint = new Point(_width / 2f, 0);
            Point leftPoint = new Point(0, _height);
            Point rightPoint = new Point(_width, _height);
           
            Triangle(topPoint, leftPoint, rightPoint,Level);
            Polygon polygon = new Polygon();
            polygon.Points = new PointCollection();
            polygon.Points.Add(topPoint);
            polygon.Points.Add(leftPoint);
            polygon.Points.Add(rightPoint);
            polygon.Stroke =Brushes.Black;
            fractral2.Children.Add(polygon);
        }
        private Point MidPoint(Point first, Point second)
        {
            return new Point((first.X + second.X) / 2f, (first.Y + second.Y) / 2f);
        }
        private void Triangle(Point _topPoint, Point _leftPoint, Point _rightPoint,int level)
        {
            
            if (level == 0)
            {
                Point[] points = new Point[3]
                {
                    _topPoint, _rightPoint, _leftPoint
                };

                Polygon polygon = new Polygon();
                polygon.Points = new PointCollection();
                polygon.Points.Add(points[0]);
                polygon.Points.Add(points[1]);
                polygon.Points.Add(points[2]);
                polygon.Fill = Brushes.DarkRed;
                fractral2.Children.Add(polygon);
            }
            else
            {
                
                var leftMid = MidPoint(_topPoint, _leftPoint); 
                var rightMid = MidPoint(_topPoint, _rightPoint); 
                var topMid = MidPoint(_leftPoint, _rightPoint);
                
                Triangle(_topPoint, leftMid, rightMid, level - 1);
                Triangle(leftMid, _leftPoint, topMid, level - 1);
                Triangle(rightMid, topMid, _rightPoint, level - 1);
            }
        }
    }
}
