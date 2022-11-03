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

namespace WpfApp4
{
    
    public partial class MainWindow : Window
    {
        static List<Point> points = new List<Point>();
        static int sizeRengtenle = 1;
        static Point pointTEc;
        public MainWindow()
        {
            InitializeComponent();
            MouseDown += DrawTriangle;

        }


        private void DrawTriangle(object sender,MouseEventArgs e) {

            if (points.Count == 3)
            {

               
                pointTEc.X = e.GetPosition(Canvass).X;
                pointTEc.Y = e.GetPosition(Canvass).Y;
                Random random = new Random();
               
                for (int i = 0; i < 12000; i++)
                {
                    var randpoint = random.Next(0, points.Count);
                    pointTEc = MidPoint(pointTEc, points[randpoint]);
                    Rectangle rectangle = new Rectangle();
                    rectangle.Fill = Brushes.Red;
                    rectangle.Width = sizeRengtenle;
                    rectangle.Height = sizeRengtenle;
                    Canvas.SetLeft(rectangle, pointTEc.X - sizeRengtenle / 2);
                    Canvas.SetTop(rectangle, pointTEc.Y - sizeRengtenle / 2);

                    Canvass.Children.Add(rectangle);

                }
            }
            else
            {
                Rectangle rectangle = new Rectangle();
                Point point = new Point();
                point.X = e.GetPosition(Canvass).X;
                point.Y = e.GetPosition(Canvass).Y;
                points.Add(point);
                rectangle.Fill = Brushes.Red;
                rectangle.Width = sizeRengtenle;
                rectangle.Height = sizeRengtenle;
                Canvas.SetLeft(rectangle, point.X - sizeRengtenle / 2);
                Canvas.SetTop(rectangle, point.Y - sizeRengtenle / 2);

                Canvass.Children.Add(rectangle);
                
            }
           
        

        }
        private Point MidPoint(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);
        }
    }
}
